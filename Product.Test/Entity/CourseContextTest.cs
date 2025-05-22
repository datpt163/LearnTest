using Microsoft.EntityFrameworkCore;
using Product.Models;
using Product.Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Test.Entity
{
    public class CourseContextTest
    {
        [Fact]
        public void Constructure_CreateInMemoryDb_Success()
        {
            // Arrange
            var context = ContextFactory.Create();
            // Act
            // Assert

            Assert.True(context.Database.EnsureCreated());
        }
    }
}
