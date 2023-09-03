using Core.Model;

namespace WEBAPI.Model.UserDto.Request
{
    public class CreateUserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        public static implicit operator User(CreateUserRequestDto dto)
        {
            if (dto == null) return null;

            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Birthday = dto.Birthday,
            };
        }

        public static implicit operator CreateUserRequestDto(User user)
        {
            if (user == null) return null;
            return new CreateUserRequestDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Birthday = user.Birthday,
            };
        }
    }

}

