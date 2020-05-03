using GraphQL.Types;
using parking.dataAccess.Repositories.Contracts;
using parking.types;

namespace parking.Queries
{
    public class ParkingQuery : ObjectGraphType
    {
        public ParkingQuery(IParkingRepository parkingRepository)
        {
            Field<ListGraphType<ParkingType>>(
                "availableParkings",
                resolve: context => parkingRepository.GetAvailable());

            Field<ParkingType>(
                "parking",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => parkingRepository.GetParking(context.GetArgument<int>("id")));

            Field<ListGraphType<ParkingType>>(
                "parkings",
                resolve: context => parkingRepository.GetParkings());

            Field<ListGraphType<ParkingType>>(
                "priceParking",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "min" }, new QueryArgument<IntGraphType> { Name = "max" }),
                resolve: context => parkingRepository.PriceRange(context.GetArgument<int>("min"), context.GetArgument<int>("max")));

            Field<ListGraphType<ParkingType>>(
                "rateParking",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "rate" }),
                resolve: context => parkingRepository.Rate(context.GetArgument<int>("rate")));
        }
    }
}
