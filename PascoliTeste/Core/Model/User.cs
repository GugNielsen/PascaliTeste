using System.Data;

namespace Core.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string TokenJwt { get; set; }

     
        public static implicit operator User(DataAccess.Entites.Users dataUser)
        {
            if (dataUser == null) return null;
    
            return new User
            {
                Id = dataUser.UserId,
                FirstName = dataUser.FirstName,
                LastName = dataUser.LastName,
                Email = dataUser.Email,
                Password = dataUser.Password,
                Birthday = dataUser.Birthday
            };
        }

        public static implicit operator DataAccess.Entites.Users(User coreUser)
        {
            if (coreUser == null) return null;

            return new DataAccess.Entites.Users
            {
                UserId = coreUser.Id,
                FirstName = coreUser.FirstName,
                LastName = coreUser.LastName,
                Email = coreUser.Email,
                Password = coreUser.Password,
                Birthday = coreUser.Birthday
            };
        }

    }
}

