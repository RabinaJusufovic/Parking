using GraphQL.Types;
using parking.database.Models;

namespace parking.types
{
    public class SubcommentsType : ObjectGraphType<Subcomments>
    {
        public SubcommentsType()
        {
            Field(x => x.id);
            Field(x => x.commentsRefId);
            Field(x => x.comment);
        }
    }
}
