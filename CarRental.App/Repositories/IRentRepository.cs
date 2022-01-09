using CarRental.Database.Entities;
using System.Threading.Tasks;

namespace CarRental.App.Repositories
{
    public interface IRentRepository
    {
        public Task<int> RentCar(int carId, int? userId = 0);
        public Task<bool> SetRentStatus(Car car);
    }
}
