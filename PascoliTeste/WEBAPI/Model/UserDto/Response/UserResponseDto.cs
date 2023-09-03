using Core.Model;

public class UserResponseDto
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string TokenJwt { get; set; }
    public DateTime Birthday { get; set; }

    public static implicit operator UserResponseDto(User user)
    {
        if (user == null) return null;
        return new UserResponseDto
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Birthday = user.Birthday,
            TokenJwt = user.TokenJwt
        };
    }

    public static implicit operator User(UserResponseDto dto)
    {
        if (dto == null) return null;
        return new User
        {
            Id = dto.UserId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Birthday = dto.Birthday,
            TokenJwt = dto.TokenJwt
        };
    }
}
