using GraphQL;
using parking.Mutations;
using parking.Queries;

namespace parking.Schema
{
    public class ParkingSchema : GraphQL.Types.Schema
    {
        public ParkingSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
            Mutation = resolver.Resolve<UserMutation>();
        }
    }
}
