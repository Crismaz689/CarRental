using CarRental.App.Models;

namespace CarRental.App.Repositories
{
    public interface IUserRepository
    {
        public void Register(UserRegistrationViewModel model);
    }
}
