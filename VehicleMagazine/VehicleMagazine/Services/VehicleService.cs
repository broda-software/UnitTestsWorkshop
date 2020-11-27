using System;
using VehicleMagazine.Models;
using VehicleMagazine.Repository.Abstraction;
using VehicleMagazine.Services.Abstraction;
using VehicleMagazine.Validators.Abstraction;

namespace VehicleMagazine.Services
{
    public class VehicleService : IVehicleService
    {
        public readonly IVehicleRepository vehicleRepository;
        public readonly IVehicleValidator vehicleValidator;

        public VehicleService(IVehicleRepository vehicleRepository, IVehicleValidator vehicleValidator)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleValidator = vehicleValidator;
        }

        public int CreateVehicle(Vehicle vehicle)
        {
            var isValid = vehicleValidator.Validate(vehicle);
            if (!isValid)
            {
                throw new Exception("Vehicle data are not valid!");
            }

            var result = this.vehicleRepository.Create(vehicle);

            return result;
        }
    }
}
