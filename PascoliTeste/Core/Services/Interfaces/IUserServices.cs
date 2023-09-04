using Core.Model;

namespace Core.Services.Interfaces
{
    public interface IUserServices
    {
        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid userId);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid Id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByLogin(User user,string key);
        Task<bool> UpdatePasswordAsync(ChangePasswordRequestDto dto);

    }
}
