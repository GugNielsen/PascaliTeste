using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Context;
using DataAccess.Entites;
using DataAccess.Repository.GenereicRepository;
using DataAccess.Repository.Interfaces;

public class UserRepository : BaseRepository<Users>, IUserRepository
{
    private readonly IDataContext _dataContext;

    public UserRepository(IDataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Users> UserGetByIdAsync(Guid userId)
    {
      
            return await _dataContext.Connection.QuerySingleOrDefaultAsync<Users>("SELECT * FROM Users WHERE UserId = @UserId", new { UserId = userId });
       
    }

    public async Task<Users> UserGetByEmailAsync(string email)
    {
       
            return await _dataContext.Connection.QuerySingleOrDefaultAsync<Users>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });
       
    }

    public async Task<bool> UserUpdateAsync(Users user)
    {
            string updateQuery = @"UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Birthday = @Birthday WHERE UserId = @UserId";
            int rowsAffected = await _dataContext.Connection.ExecuteAsync(updateQuery, new { user.FirstName, user.LastName, user.Email, user.Birthday, user.UserId });
            return rowsAffected > 0;
     
    }

    public async Task<bool> UserUpdatePasswordAsync(Users user)
    {

        string updateQuery = @"UPDATE Users SET Password = @Password WHERE UserId = @UserId";
        int rowsAffected = await _dataContext.Connection.ExecuteAsync(updateQuery, new { Password = user.Password, UserId = user.UserId });
        return rowsAffected > 0;
      
    }

    public async Task<bool> UserDeleteAsync(Guid userId)
    {
            string deleteQuery = @"DELETE FROM Users WHERE UserId = @UserId";
            int rowsAffected = await _dataContext.Connection.ExecuteAsync(deleteQuery, new { UserId = userId });
            return rowsAffected > 0;
        
    }

}
