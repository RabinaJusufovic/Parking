using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace parking.database.Models
{
    public class Role
    {
        public int id { get; set; } 
        public string role { get; set; }

        [ForeignKey("roleRefId")]
        public ICollection<User> User { get; set; }
    }
}