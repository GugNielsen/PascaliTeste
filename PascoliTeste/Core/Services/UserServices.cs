using Core.Helpers.Token;
using Core.Helpers.Validation;
using Core.Model;
using Core.Services.Interfaces;
using DataAccess.Entites;
using DataAccess.Repository.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;


namespace Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAsync(User user)
        {
            await UserValidatedAsync(user,true);

            user.Password = Hash.HashPassword(user.Password);

            var userdb = await _userRepository.InsertAsync(user);

            if ( userdb == Guid.Empty)
            {
                throw new ValidationException(new List<string> { "Cadastro não efetuado" });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            return await _userRepository.UserDeleteAsync(userId);
        }

        public async Task<User> GetByIdAsync(Guid Id)
        {
            var user = await _userRepository.UserGetByIdAsync(Id);
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _userRepository.UserGetByEmailAsync(email);
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            List<User> usersList = new List<User>();

            foreach (var item in await _userRepository.GetAllAsync())
            {
                usersList.Add(item);
            }

            return usersList;
        }

        public async Task<User> GetByLogin(User user,string key)
        {
            var userdb = await _userRepository.UserGetByEmailAsync(user.Email);

            if (userdb == null) throw new ValidationException(new List<string> { "Email Invalido" });

            if (!Hash.VerifyPassword(user.Password, userdb.Password)) throw new ValidationException(new List<string> { "Senha incorreta" });
         
            user = userdb;
            user.TokenJwt = JwtTokenHelper.GenerateJwtToken(userdb, key);

            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            if (await GetByIdAsync(user.Id) == null) throw new ValidationException(new List<string> { "Usuario não pode fazer atualização ele não foi encontrado no sistema" });

            await UserValidatedAsync(user,false);
            
           return  await _userRepository.UserUpdateAsync(user);
        }

        public async Task<bool> UpdatePasswordAsync(ChangePasswordRequestDto dto)
        {
            if (dto.NewPassword != dto.ConfirmNewPassword)
                throw new ValidationException(new List<string> { "A nova senha e a confirmação da senha não correspondem." });

            var userdb = await GetByIdAsync(dto.UserId);

            if (userdb == null)
                throw new ValidationException(new List<string> { "Usuário não encontrado em nosso sistema. Por favor, tente novamente." });

            if (!Hash.VerifyPassword(dto.OldPassword, userdb.Password))
                throw new ValidationException(new List<string> { "A senha antiga fornecida não é correta. Por favor, tente novamente." });

            if (Hash.VerifyPassword(dto.NewPassword, userdb.Password))
                throw new ValidationException(new List<string> { "A nova senha não pode ser a mesma que a senha atual. Por favor, escolha uma senha diferente." });

            userdb.Password = Hash.HashPassword(dto.NewPassword);

            return await _userRepository.UserUpdatePasswordAsync(userdb);
        }

        private async Task UserValidatedAsync(User user, bool isCreate)
        {
            var validator = isCreate ? (IValidator<User>)new UserCreateValidator() : new UserUpdateValidator();
            var validationResult = await validator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
        }

    }
}
