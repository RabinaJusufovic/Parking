using GraphQL.Types;

namespace parking.types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
            Field<IntGraphType>("day");
            Field<IntGraphType>("month");
            Field<IntGraphType>("year");
        }
    }
}
