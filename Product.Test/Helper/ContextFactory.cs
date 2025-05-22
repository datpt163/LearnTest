using Microsoft.EntityFrameworkCore;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Test.Helper
{
    public  class ContextFactory
    {
        public static CourseContext Create()
        {
            DbContextOptions<CourseContext> options = new DbContextOptionsBuilder<CourseContext>()
                                                        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new CourseContext(options);

            return context;
        }
    }
}
