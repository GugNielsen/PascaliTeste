using DataAccess.Entites;

namespace DataAccess.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<Users>
    {
        Task<Users> UserGetByEmailAsync(string email);
        Task<Users> UserGetByIdAsync(Guid userId);
        Task<bool> UserUpdatePasswordAsync(Users user);
        Task<bool> UserDeleteAsync(Guid userId);
        Task<bool> UserUpdateAsync(Users user);
    }
}
