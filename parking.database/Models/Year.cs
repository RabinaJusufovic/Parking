using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking.database.Models
{
    public class Year
    {
        public int id { get; set; }
        public int year { get; set; }

        [ForeignKey("yearRefId")]
        public ICollection<User> User { get; set; }
    }
}
