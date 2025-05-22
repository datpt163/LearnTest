using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Product.Data.Repository;
using Product.Models;
using System.Diagnostics;

namespace Product.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseContext ct;
        private readonly IRepository<Role> _roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IUser2Repository user2Repository;

        public HomeController(ILogger<HomeController> logger, CourseContext courseContext, IRepository<Role> roleRepository, IUserRepository userRepository, IUser2Repository user2Repository)
        {
            _logger = logger;
            ct = courseContext;
            _roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.user2Repository = user2Repository;
        }

        public async Task<IActionResult> Index()
        {
            var rs = await user2Repository.GetListUsers();
            var connect = ct.Database.GetDbConnection();
            using var transaction = await ct.Database.BeginTransactionAsync();


            try
            {
                var sqlInsertRole = "INSERT INTO Roles (name) VALUES (@name)";
                await connect.ExecuteAsync(sqlInsertRole, new { name = "test11" }, transaction.GetDbTransaction());

                var sqlInsertListRole = "INSERT INTO Roles (id,name) VALUES (@id,@name)";

                var roles = new[]
                {
                    new {id = 15, name = "dat3"},
                    new {id = 16, name = "dat4"}
                };

                await connect.ExecuteAsync(sqlInsertListRole, roles, transaction.GetDbTransaction());
                transaction.Commit();

            }
            catch
            {
                transaction.Rollback();
            }


            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
