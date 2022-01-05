using System;

namespace CarRental.Database.Entities
{
    public class RentedCar
    {
        public int RentedCarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
