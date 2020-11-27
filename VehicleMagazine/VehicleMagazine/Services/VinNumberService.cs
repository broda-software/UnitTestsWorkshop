using VehicleMagazine.Services.Abstraction;

namespace VehicleMagazine.Services
{
    public class VinNumberService : IVinNumberService
    {
        public bool IsVinNumberLengthValid(string vinNumber)
        {
            if(vinNumber != null)
            {
                var vinNumberLength = vinNumber.Length;
                if(vinNumberLength == 17)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
