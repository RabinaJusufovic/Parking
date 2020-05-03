namespace parking.database.Models
{
    public class Favorite
    {
        public int id { get; set; }

        public int usersRefId { get; set; }
        public User User { get; set; }

        public int parkingsRefId { get; set; }
        public Parking Parking { get; set; }
    }
}
