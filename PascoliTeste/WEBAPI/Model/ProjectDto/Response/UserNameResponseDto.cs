using Core.Model;
using WEBAPI.Model.UserDto.Request;

namespace WEBAPI.Model.ProjectDto.Response
{
    public class UserNameResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static implicit operator User(UserNameResponseDto dto)
        {
            if (dto == null) return null;

            return new User
            {
               FirstName = dto.FirstName,
               LastName = dto.LastName
            };
        }

        public static implicit operator UserNameResponseDto(User user)
        {
            if (user == null) return null;

            return new UserNameResponseDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}

