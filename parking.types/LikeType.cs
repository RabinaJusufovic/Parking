using GraphQL.Types;
using parking.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace parking.types
{
    public class LikeType : ObjectGraphType<Like>
    {
        public LikeType()
        {
            Field(x => x.id);
            Field(x => x.counter);
            Field(x => x.commentRefId);
        }
    }
}
