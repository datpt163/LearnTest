using Dapper;
using Microsoft.EntityFrameworkCore;
using Product.Models;
using System.Data;

namespace Product.Data.Repository
{
    public class User2Repository : Repository<User>, IUser2Repository
    {
        public User2Repository(CourseContext context) : base(context) { }

        public async Task<List<UserDTO>> GetListUsers()
        {
            var connect = _context.Database.GetDbConnection();
            var sql = @$"SELECT users.id, users.username, users.email, roles.`name` AS roleName
                        FROM users LEFT JOIN user_roles ON users.id = user_roles.user_id
                         LEFT JOIN roles ON user_roles.role_id = roles.id";


            return (await connect.QueryAsync<UserDTO>(sql)).ToList();
        }
    }
}
