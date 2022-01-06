using CarRental.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.App.Repositories
{
    public interface IUserRepository
    {
        public Task<int> Register(UserRegistrationViewModel model);
    }
}
