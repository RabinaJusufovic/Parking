namespace parking.database.Models
{
    public class Subcomments
    {
        public int id { get; set; }
        public string comment { get; set; }
        public int commentsRefId { get; set; }
        public Comments Comments { get; set; }
    }
}
