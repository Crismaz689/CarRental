using CarRental.Database;
using CarRental.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.App.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _context;

        public CarRepository(CarRentalDbContext context) => _context = context;
         
        public ICollection<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCar(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.CarId == id);
        }
    }
}
