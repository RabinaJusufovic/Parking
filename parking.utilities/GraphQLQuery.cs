using Newtonsoft.Json.Linq;

namespace parking.utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; } //name of the query
        public string Query { get; set; } //body of the request
        public JObject Variables { get; set; } //variables passed by the user
    }
}
