using Moq;
using Product.Data.Repository;
using Product.Models;
using Product.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Test.Services.Accounts
{
    public class AccountServiceTest
    {
        private readonly Mock<IUser2Repository> _mockUser2Repository;

        public AccountServiceTest()
        {
            _mockUser2Repository = new Mock<IUser2Repository>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void AddAsync_UserNameIsNullorEmpty_ReturnErrorResult(string? userName)
        {
            // Arrange
            var user = new User() { Username = userName};
            var accountService = new AccountService(_mockUser2Repository.Object);

            // Act
            var result = await accountService.AddAsync(user);


            // Assert
            Assert.NotNull(result);
            Assert.Equal("User name cannot be empty", result.errorMessage);
            Assert.False(result.isSuccess);
        }

        [Fact]
        public async void AddAsync_EmailAlreadyExists_ReturnErrorResult()
        {
            // Arrange
            var user = new User() { Username = "dat", Email = "dat@gmail.com" };
            _mockUser2Repository.Setup(r => r.ExistsAsync(x => x.Email == user.Email)).Returns(Task.FromResult(true));
            var accountService = new AccountService(_mockUser2Repository.Object);

            // Act
            var result = await accountService.AddAsync(user);


            // Assert
            Assert.NotNull(result);
            Assert.Equal("This email already exists", result.errorMessage);
            Assert.False(result.isSuccess);
        }

        [Fact]
        public async void AddAsync_UserNameAlreadyExists_ReturnErrorResult()
        {
            // Arrange
            var user = new User() { Username = "dat", Email = "dat@gmail.com" };
            _mockUser2Repository.Setup(r => r.ExistsAsync(x => x.Username == user.Username)).Returns(Task.FromResult(true));
            var accountService = new AccountService(_mockUser2Repository.Object);

            // Act
            var result = await accountService.AddAsync(user);


            // Assert
            Assert.NotNull(result);
            Assert.Equal("This user name already exists", result.errorMessage);
            Assert.False(result.isSuccess);
        }

        [Fact]
        public async void AddAsync_ValidUser_ReturnSuccessResult()
        {
            // Arrange
            var user = new User() { Username = "dat", Email = "dat@gmail.com" };
            _mockUser2Repository.Setup(r => r.ExistsAsync(x => x.Username == user.Username)).Returns(Task.FromResult(false));
            _mockUser2Repository.Setup(r => r.ExistsAsync(x => x.Email == user.Email)).Returns(Task.FromResult(false));
            var accountService = new AccountService(_mockUser2Repository.Object);

            // Act
            var result = await accountService.AddAsync(user);


            // Assert
            Assert.NotNull(result);
            Assert.True(result.isSuccess);
        }
    }
}
