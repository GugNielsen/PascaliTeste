using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Model;
using Core.Services;
using DapperExtensions.Predicate;
using DataAccess.Repository.Interfaces;
using Moq;
using Xunit;

namespace TestUnitPascali.UserTests
{
    public class UserServicesTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserServices _userServices;

        public UserServicesTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userServices = new UserServices(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_UserIsValid_ReturnsTrue()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password",
                Birthday = new DateTime(1990, 1, 1)
            };
            _userRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<DataAccess.Entites.Users>(), null, null)).ReturnsAsync(user.Id);
            var result = await _userServices.CreateAsync(user);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_UserExists_ReturnsTrue()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(repo => repo.UserDeleteAsync(userId)).ReturnsAsync(true);

            var result = await _userServices.DeleteAsync(userId);

            Assert.True(result);
        }

        [Fact]
        public async Task GetByIdAsync_UserExists_ReturnsUser()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password",
                Birthday = new DateTime(1990, 1, 1)
            };
            _userRepositoryMock.Setup(repo => repo.UserGetByIdAsync(userId)).ReturnsAsync(user);

            var result = await _userServices.GetByIdAsync(userId);

            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_UsersExist_ReturnsUsersList()
        {
            var users = new List<DataAccess.Entites.Users>
            {
                new DataAccess.Entites.Users
                {
                     UserId = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "password",
                    Birthday = new DateTime(1990, 1, 1)
                },
                new DataAccess.Entites.Users
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@example.com",
                    Password = "password",
                    Birthday = new DateTime(1990, 1, 1)
                }
            };
            _userRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<DataAccess.Entites.Users, bool>>>(), It.IsAny<IList<ISort>>(), It.IsAny<IDbTransaction>(), It.IsAny<int?>()))
        .ReturnsAsync(users);
          
            var result = await _userServices.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
