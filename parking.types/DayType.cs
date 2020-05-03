using GraphQL.Instrumentation;
using GraphQL.Types;
using parking.database.Models;


namespace parking.types
{
    public class DayType : ObjectGraphType<Day>
    {
        public DayType()
        {
            Field(x => x.id);
            Field(x => x.day);
        }
    }
}
