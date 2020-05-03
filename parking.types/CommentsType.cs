using GraphQL.Types;
using parking.database.Models;


namespace parking.types
{
    public class CommentsType : ObjectGraphType<Comments>
    {
        public CommentsType()
        {
            Field(x => x.id);
            Field(x => x.comment);
            Field(x => x.date);
            Field(x => x.userRefId);
            Field(x => x.parkingRefId);
        }
    }
}
