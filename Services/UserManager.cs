using Raythos_Aerospace.Data;
using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Services
{
    public class UserManager : IUserManager
    {
        private readonly RaythosContext _context;

        public UserManager(RaythosContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
           
            var userEntity = new UserEntity
            {
                UserName = model.UserName,
                UserEmail = model.UserEmail,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                ContactNumber = model.ContactNumber,
                Address = model.Address
            };

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
