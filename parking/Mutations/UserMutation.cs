using GraphQL.Types;
using parking.dataAccess.Repositories.Contracts;
using parking.database.Models;
using parking.types;

namespace parking.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IUserRepository userRepository)
        {
            Field<UserType>(
                "addUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return userRepository.AddUser(user);
                });
        }
    }
}
