using VehicleMagazine.Models;

namespace VehicleMagazine.Repository.Abstraction
{
    public interface IVehicleRepository
    {
        int Create(Vehicle vehicle);
    }
}
