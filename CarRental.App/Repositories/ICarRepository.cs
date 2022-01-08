using CarRental.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.App.Repositories
{
    public interface ICarRepository
    {
        public ICollection<Car> GetAllCars();
        public Car GetCar(int id);
    }
}
