using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Services
{
    public interface IUserManager
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);

        Task<string> LoginUserAsync(LoginViewModel model);

        Task<IEnumerable<UserEntity>> GetUsers();

        Task<bool> DeleteUserAsync(int userId);
    }
}
