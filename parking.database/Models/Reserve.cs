using System;

namespace parking.database.Models
{
    public class Reserve
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int timeComing { get; set; }
        public int timeLeaving { get; set; }

        public int userId { get; set; }
        public User User { get; set; }

        public int parkingId { get; set; }
        public Parking Parking { get; set; }
    }
}
