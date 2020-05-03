using parking.dataAccess.Repositories.Contracts;
using parking.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace parking.dataAccess.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly MyWebApiContext _dbContext;
        public ParkingRepository(MyWebApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Parking> GetAvailable()
        {
            return _dbContext.Parking.Where(x => x.availability == true);
        }

        public IEnumerable<Parking> GetClosest(int latitude, int longitude)
        {
            throw new NotImplementedException();
        }

        public Parking GetParking(int id)
        {
            return _dbContext.Parking.SingleOrDefault(x => x.id == id);
        }

        public IEnumerable<Parking> GetParkings()
        {
            return _dbContext.Parking;
        }

        public IEnumerable<Parking> GetParkings(string address)
        {
            return _dbContext.Parking.Where(x => x.address == address);
        }

        public IEnumerable<Parking> PriceRange(int min, int max)
        {
            return _dbContext.Parking.Where(x => x.price <= max && x.price >= min);
        }

        public IEnumerable<Parking> Rate(int rate)
        {
            return _dbContext.Parking.Where(x => x.rate >= rate);
        }
    }
}
