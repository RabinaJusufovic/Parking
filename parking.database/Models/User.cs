using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking.database.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime signUpDate { get; set; }

        [ForeignKey("userRefId")]
        public ICollection<Comments> Comments { get; set; }

        public int dayRefId { get; set; }
        public Day Day { get; set; }

        public int monthRefId { get; set; }
        public Month Month { get; set; }

        public int yearRefId { get; set; }
        public Year Year { get; set; }

        public int roleRefId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("usersRefId")]
        public ICollection<Favorite> Favorite { get; set; }

        [ForeignKey("userId")]
        public ICollection<Reserve> Reserve { get; set; }
    }
}
