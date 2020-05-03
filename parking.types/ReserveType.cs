using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class ReserveType:ObjectGraphType<Reserve>
    {
        public ReserveType()
        {
            Field(x => x.id);
            Field(x => x.date);
            Field(x => x.timeComing);
            Field(x => x.timeLeaving);
            Field(x => x.userId);
            Field(x => x.parkingId);
        }
    }
}
