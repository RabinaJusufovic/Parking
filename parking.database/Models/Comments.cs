using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking.database.Models
{
    public class Comments
    {
        public int id { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
        public int userRefId { get; set; }
        public User User { get; set; }

        public int parkingRefId { get; set; }
        public Parking Parking { get; set; }

        [ForeignKey("commentRefId")]
        public ICollection<Like> Like { get; set; }

        [ForeignKey("commentsRefId")]
        public ICollection<Subcomments> Subcomments { get; set; }
    }
}
