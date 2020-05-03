using GraphQL.Types;
using parking.types;
using parking.dataAccess.Repositories.Contracts;

namespace parking.Queries
{
    public class CommentQuery : ObjectGraphType
    {
        public CommentQuery(ICommentRepository commentRepository)
        {
            Field<ListGraphType<CommentsType>>(
                "comments",
                resolve: context => commentRepository.GetAllComments());

            Field<ListGraphType<CommentsType>>(
                "parkingComment",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => commentRepository.ParkingComments(context.GetArgument<int>("id")));

            Field<ListGraphType<CommentsType>>(
                "usersComment",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => commentRepository.UserComments(context.GetArgument<int>("id")));
        }
    }
}
