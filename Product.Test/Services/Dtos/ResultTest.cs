using Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Test.Services.Dtos
{
    public class ResultTest
    {
        [Fact]
        public void Constructor_CreateObjectNotNull_ObjectNotNull()
        {
            // Arrange
            var result = new Result();
            // Act

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Constructor_ErrorMessageHasValue_ValidObject()
        {
            // Arrange
            var result = new Result("dat");
            // Act

            // Assert
            Assert.False(result.isSuccess);
            Assert.Equal("dat", result.errorMessage);
        }
    }
}
