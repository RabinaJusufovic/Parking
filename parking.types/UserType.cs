using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.id);
            Field(x => x.name);
            Field(x => x.lastName);
            Field(x => x.email);
            Field(x => x.password);
            Field(x => x.signUpDate);
            Field(x => x.dayRefId);
            Field(x => x.monthRefId);
            Field(x => x.yearRefId);
            Field(x => x.roleRefId);
        }
    }
}
