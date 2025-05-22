using Moq;
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
        [Fact]
        public async void Sum_ValidParam_PassingTest()
        {
            // Arrange
            var accountService = new Mock<IAccountService>();
            accountService.Setup(x => x.Sum(2, 2)).ReturnsAsync(4);
            // Act

            // Assert
            Assert.Equal(4, await accountService.Object.Sum(2,2));
        }
    }
}
