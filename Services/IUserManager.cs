using Raythos_Aerospace.Models.ViewModels;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Services
{
    public interface IUserManager
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
    }
}
