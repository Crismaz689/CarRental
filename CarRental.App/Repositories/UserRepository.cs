using CarRental.App.Models;
using CarRental.Database;
using CarRental.Database.Entities;
using System.Security.Cryptography;

namespace CarRental.App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext _context;

        public UserRepository(CarRentalDbContext context) => _context = (context);
        public void Register(UserRegistrationViewModel model)
        {
            byte[] hashedPassword;

            var bytes = System.Text.Encoding.UTF8.GetBytes(model.Password);
            using (SHA512 shaM = new SHA512Managed())
            {
                hashedPassword = shaM.ComputeHash(bytes);
            }

            User user = new User
            {
                Username = model.Username,
                FirstName = model.FirstName,
                Surname = model.Surname,
                Balance = model.Balance,
                Gender = model.Gender,
                Pesel = model.Pesel,
                PasswordHash = hashedPassword
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
