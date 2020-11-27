using VehicleMagazine.Models;
using VehicleMagazine.Validators.Abstraction;

namespace VehicleMagazine.Validators
{
    public class VehicleValidator : IVehicleValidator
    {
        public bool Validate(Vehicle vehicle)
        {
            var result = vehicle.FirstRegYear > 1900 && vehicle.FirstRegYear <= 2020;
            
            return result;
        }
    }
}
