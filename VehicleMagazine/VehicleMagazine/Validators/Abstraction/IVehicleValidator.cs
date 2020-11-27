using VehicleMagazine.Models;

namespace VehicleMagazine.Validators.Abstraction
{
    public interface IVehicleValidator
    {
        bool Validate(Vehicle vehicle);
    }
}
