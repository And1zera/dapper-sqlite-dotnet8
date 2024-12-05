using dapperdotnet8.Domain.Entity;
using dapperdotnet8.Domain.Interfaces.Repository;
using dapperdotnet8.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace dapperdotnet8.Application.Services
{

    public class UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork) : IUserService
    {

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateUserAsync(User user)
        {
            user.Create();
            return await unitOfWork.UserRepository.InsertAsync(user);
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            user.Update();
            return await unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            user.Remove();
            return await unitOfWork.UserRepository.DeleteAsync(user);
        }
    }
}