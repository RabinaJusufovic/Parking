namespace parking.database.Models
{
    public class Like
    {
        public int id { get; set; }
        public int counter { get; set; }

        public int commentRefId { get; set; }
        public Comments Comments { get; set; }
    }
}
