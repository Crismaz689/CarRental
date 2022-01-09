using CarRental.App.Models;
using CarRental.Database.Entities;
using System.Threading.Tasks;

namespace CarRental.App.Repositories
{
    public interface IUserRepository
    {
        public Task<int> Register(UserRegistrationViewModel model);
        public User Login(LoginViewModel user);
        public User GetUser(int id);
    }
}
