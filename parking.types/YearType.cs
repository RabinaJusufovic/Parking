using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class YearType : ObjectGraphType<Year>
    {
        public YearType()
        {
            Field(x => x.id);
            Field(x => x.year);
        }
    }
}
