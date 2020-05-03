using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class MonthType : ObjectGraphType<Month>
    {
        public MonthType()
        {
            Field(x => x.id);
            Field(x => x.month);
        }
    }
}
