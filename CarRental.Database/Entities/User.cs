using System.Collections.Generic;

namespace CarRental.Database.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public bool Gender { get; set; }
        public decimal Balance { get; set; }

        public ICollection<RentedCar> RentedCars { get; set; }
    }
}
