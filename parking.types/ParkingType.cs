using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class ParkingType : ObjectGraphType<Parking>
    {
        public ParkingType()
        {
            Field(x => x.id);
            Field(x => x.address);
            Field(x => x.latitude);
            Field(x => x.longitude);
            Field(x => x.phone);
            Field(x => x.workingHours);
            Field(x => x.price);
            Field(x => x.availability);
            Field(x => x.rate);
        }
    }
}
