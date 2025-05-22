using Microsoft.EntityFrameworkCore;
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
        protected readonly DbSet<User> _dbSet;

        public RepositoryTest()
        {
            courseContext = ContextFactory.Create();
            _dbSet = courseContext.Set<User>();
        }
    }
}
