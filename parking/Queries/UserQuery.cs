using GraphQL.Types;
using parking.dataAccess.Repositories.Contracts;
using parking.types;

namespace parking.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => userRepository.GetAllUsers());

            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => userRepository.GetUser(context.GetArgument<int>("id")));
        }
    }
}
