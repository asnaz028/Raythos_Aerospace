using Microsoft.IdentityModel.Tokens;
using Raythos_Aerospace.Data;
using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Raythos_Aerospace.Services
{
    public class UserManager : IUserManager
    {
        private readonly RaythosContext _context;

        public UserManager(RaythosContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterUserAsync(RegisterViewModel model)
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

            return userEntity.Id;
        }

        public async Task<int> LoginUserAsync(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserEmail == model.UserEmail);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return 0;
            }

            _context.Orders.RemoveRange(_context.Orders);

            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            // Retrieve all users from the database
           var users =  await _context.Users.ToListAsync();
            Console.WriteLine(users);
            return users;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return false; // User not found
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true; // User deleted successfully
        }
    }
}
