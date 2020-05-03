using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking.database.Models
{
    public class Month
    {  
        public int id { get; set; }
        public int month { get; set; }

        [ForeignKey("monthRefId")]
        public ICollection<User> User { get; set; }
    }
}
