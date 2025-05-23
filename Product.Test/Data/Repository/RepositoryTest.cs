using Microsoft.EntityFrameworkCore;
using Product.Data.Repository;
using Product.Models;
using Product.Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Test.Data.Repository
{
    public class RepositoryTest
    {
        private readonly CourseContext courseContext;

        public RepositoryTest()
        {
            courseContext = ContextFactory.Create();
        }

        [Fact]
        public async Task AddAsync_ValidEntity_ShouldAddEntityToDbSet()
        {
            // Arrange
            var userRepository = new Repository<User>(courseContext);
            var user = new User() { Id = 1, Email = "dat", Password = "dat", Username = "dat" };
            // Act
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            var actual = (await userRepository.GetAsync(x => x.Id == 1)).FirstOrDefault();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(1, actual.Id);
        }

        [Fact]
        public async Task AddAsync_NullEntity_ShouldThrowArgumentNullException()
        {
            // Arrange
            var userRepository = new Repository<User>(courseContext);
            // Act

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>( async () => await userRepository.AddAsync(null!) );
        }

        [Fact]
        public async Task AddAsync_DuplicatedId_ThrowException()
        {
            // Arrange
            var userRepository = new Repository<User>(courseContext);
            var user = new User() { Id = 1, Email = "dat", Password = "dat", Username = "dat" };
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            // Act
            await userRepository.AddAsync(user);
            // Assert
            await Assert.ThrowsAsync<ArgumentException>( async () => await userRepository.SaveChangesAsync());
        }
    }
}
