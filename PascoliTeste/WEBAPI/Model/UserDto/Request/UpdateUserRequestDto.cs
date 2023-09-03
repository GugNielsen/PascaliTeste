using Core.Model;

namespace WEBAPI.Model.UserDto.Request
{
    public class UpdateUserRequestDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public static implicit operator User(UpdateUserRequestDto dto)
        {
            if (dto == null) return null;

            return new User
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Birthday = dto.Birthday,
            };
        }

        public static implicit operator UpdateUserRequestDto(User user)
        {
            if (user == null) return null;

            return new UpdateUserRequestDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
            };
        }
    }

}

