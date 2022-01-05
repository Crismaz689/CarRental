using CarRental.Database.Entities;
using CarRental.Database.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarRental.Database.Seeders
{
    public class CarRentalDbSeeder
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CarRentalDbContext>();

                context.Database.EnsureCreated();

                // Cars
                if(!context.Cars.Any())
                {
                    List<Car> cars = new List<Car>();

                    using (StreamReader sr = new StreamReader(@"..\CarRental.Database\Seeders\SeederResources\Cars.csv"))
                    {
                        string line = "";
                        while((line = sr.ReadLine()) != null)
                        {
                            string[] values = line.Split(",");
                            Car car = new Car
                            {
                                PlateNumber = values[(int)CarProperties.PlateNumber],
                                Brand = values[(int)CarProperties.Brand],
                                Model = values[(int)CarProperties.Model],
                                ProductionDate = Convert.ToDateTime(values[(int)CarProperties.ProductionDate]),
                                PricePer24h = Convert.ToDecimal(values[(int)CarProperties.PricePer24h]),
                                IsRented = Convert.ToBoolean(values[(int)CarProperties.IsRented])
                            };

                            cars.Add(car);
                        }
                    }

                    context.Cars.AddRange(cars);
                    context.SaveChanges();
                }
            }
        }
    }
}
