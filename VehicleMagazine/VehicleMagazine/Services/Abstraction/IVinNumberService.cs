namespace VehicleMagazine.Services.Abstraction
{
    public interface IVinNumberService
    {
        bool IsVinNumberLengthValid(string vinNumber);
    }
}
