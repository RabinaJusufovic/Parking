using parking.database.Models;
using System.Collections.Generic;

namespace parking.dataAccess.Repositories.Contracts
{
    public interface ICommentRepository
    {
        IEnumerable<Comments> GetAllComments();
        IEnumerable<Comments> ParkingComments(int parkingId);
        IEnumerable<Comments> UserComments(int userId);
        IEnumerable<Comments> ParkingComments(int parkingId, int limit);
        IEnumerable<Comments> UserComments(int userId, int limit);
    }
}
