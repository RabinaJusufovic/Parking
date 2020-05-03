using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking.database.Models
{
    public class Day
    {
        public int id { get; set; }
        public int day { get; set; }

        [ForeignKey("dayRefId")]
        public ICollection<User> User { get; set; }
    }
}
