using Product.Models;

namespace Product.Data.Repository
{
    public interface IUser2Repository : IRepository<User>
    {
        Task<List<UserDTO>> GetListUsers();
    }
}
