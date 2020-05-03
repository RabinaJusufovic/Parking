using GraphQL.Types;
using parking.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parking.types
{
    public class FavoriteType : ObjectGraphType<Favorite>
    {
       public FavoriteType()
       {
            Field(x => x.id);
            Field(x => x.usersRefId);
            Field(x => x.parkingsRefId);
       }
    }
}
