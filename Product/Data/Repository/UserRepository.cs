using Dapper;
using Microsoft.EntityFrameworkCore;
using Product.Models;
using System.Data;

namespace Product.Data.Repository
{
    public interface IUserRepository
    {
        Task<List<Role>> GetListUserByDapperAsync(int id);
        Task<List<Role>> GetListRoleBySP(string name);
    }

    public class UserRepository : Repository<Role>, IUserRepository
    {
        public UserRepository(CourseContext context) : base(context) { }

        public async Task<List<Role>> GetListRoleBySP(string roleName)
        {
            var connect = _context.Database.GetDbConnection();
            var spName = "GetRoles";

            var roles = await connect.QueryAsync<Role>(spName, new {roleName = roleName}, commandType: CommandType.StoredProcedure);

            return roles.ToList();
        }

        public async Task<List<Role>> GetListUserByDapperAsync(int id)
        {
            var connect = _context.Database.GetDbConnection();
            var sql = "SELECT * FROM Roles";
            var roles =  await connect.QueryAsync<Role>(sql);
            return roles.ToList();

        }

        public async Task<int> ts()
        {
            var users = _context.Users.Where(x => x.Username != null &&  x.Username == "dat").OrderBy(x => x.Id).ToList();

            users.Where(x => x.Username == "dat").OrderBy(x => x.Id)
                .Select(x => new
                {
                    name = x.Username,
                    id = x.Id
                })
                .ToList();

            return 1;
        }
    }
}
