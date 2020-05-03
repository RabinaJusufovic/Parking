using parking.database.Models;
using System.Collections.Generic;

namespace parking.dataAccess.Repositories.Contracts
{
    public interface IParkingRepository
    {
        IEnumerable<Parking> GetParkings();
        Parking GetParking(int id);
        IEnumerable<Parking> GetClosest(int latitude, int longitude);
        IEnumerable<Parking> GetParkings(string address);
        IEnumerable<Parking> GetAvailable();
        IEnumerable<Parking> PriceRange(int min, int max);
        IEnumerable<Parking> Rate(int rate);
    }
}
