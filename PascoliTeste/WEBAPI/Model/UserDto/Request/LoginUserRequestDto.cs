using Core.Model;

namespace WEBAPI.Model.UserDto.Request
{
    public class LoginUserRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public static implicit operator User(LoginUserRequestDto dto)
        {
            if (dto == null) return null;

            return new User
            {
                Email = dto.Email,
                Password = dto.Password,
            };
        }

        public static implicit operator LoginUserRequestDto(User user)
        {
            if (user == null) return null;

            return new LoginUserRequestDto
            {
                Email = user.Email,
                Password = user.Password,
            };
        }
    }
}
