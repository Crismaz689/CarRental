using CarRental.Database;
using CarRental.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.App.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly CarRentalDbContext _context;

        public RentRepository(CarRentalDbContext context) => _context = context;

        public async Task<int> RentCar(int carId, int? userId = 0)
        {
            var user =  _context.Users.FirstOrDefault(u => u.UserId == userId);
            var car = _context.Cars.FirstOrDefault(c => c.CarId == carId);

            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(7);

            _context.RentedCars.Add(new RentedCar
            {
                User = user,
                UserId = user.UserId,
                Car = car,
                CarId = car.CarId,
                StartDate = startDate,
                EndDate = endDate
            });

            await _context.SaveChangesAsync();
            await SetRentStatus(car);

            return _context.RentedCars.ToList().Count;
        }

        public async Task<bool> SetRentStatus(Car car)
        {
            car.IsRented = true;
            await _context.SaveChangesAsync();
            return car.IsRented;
        }
    }
}
