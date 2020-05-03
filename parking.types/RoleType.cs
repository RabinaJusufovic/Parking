using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class RoleType : ObjectGraphType<Role>
    {
        public RoleType()
        {
            Field(x => x.id);
            Field(x => x.role);
        }
    }
}
