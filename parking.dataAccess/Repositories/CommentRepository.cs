using parking.database.Models;
using parking.dataAccess.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace parking.dataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MyWebApiContext _dbContext;
        public CommentRepository(MyWebApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Comments> GetAllComments()
        {
            return _dbContext.Comments;
        }

        public IEnumerable<Comments> ParkingComments(int parkingId)
        {
            return _dbContext.Comments.Where(x => x.parkingRefId == parkingId);
        }

        public IEnumerable<Comments> ParkingComments(int parkingId, int limit)
        {
            return _dbContext.Comments.Where(x => x.parkingRefId == parkingId)
                .OrderByDescending(x => x.date)
                .Take(limit);
        }

        public IEnumerable<Comments> UserComments(int userId)
        {
            return _dbContext.Comments.Where(x => x.userRefId == userId);
        }

        public IEnumerable<Comments> UserComments(int userId, int limit)
        {
            return _dbContext.Comments.Where(x => x.userRefId == userId)
                .OrderByDescending(x => x.date)
                .Take(limit);
        }
    }
}
