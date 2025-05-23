using Product.Data.Repository;
using Product.Dtos;
using Product.Models;

namespace Product.Services.Accounts
{
    public interface IAccountService
    {
        public Task<Result> AddAsync(User user);
    }

    public class AccountService : IAccountService
    {
        private readonly IUser2Repository _userRepository;

        public AccountService(IUser2Repository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> AddAsync(User user)
        {
            if(String.IsNullOrEmpty(user.Username))
                return new Result() { errorMessage = "User name cannot be empty", isSuccess = false };


            if (await _userRepository.ExistsAsync(x => x.Email == user.Email))
                return new Result() { errorMessage = "This email already exists", isSuccess = false};

            if(await _userRepository.ExistsAsync(x => x.Username == user.Username))
                return new Result() { errorMessage = "This user name already exists", isSuccess = false};

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new Result() { isSuccess = true };   
        }
    }
}
