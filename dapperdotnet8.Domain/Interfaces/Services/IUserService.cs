using dapperdotnet8.Domain.Entity;

namespace dapperdotnet8.Domain.Interfaces.Services
{
    public interface IUserService 
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(string id);
        Task<int> CreateUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
    } 
}