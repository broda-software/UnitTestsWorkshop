using System;
using VehicleMagazine.Models;
using VehicleMagazine.Repository.Abstraction;

namespace VehicleMagazine.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        public int Create(Vehicle vehicle)
        {
            var random = new Random();
            return random.Next(1, 1000);
        }
    }
}
