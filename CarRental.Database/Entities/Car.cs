using System;
using System.Collections.Generic;

namespace CarRental.Database.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal PricePer24h { get; set; }
        public bool IsRented { get; set; }
        public ICollection<RentedCar> RentedCars { get; set; }
    }
}
