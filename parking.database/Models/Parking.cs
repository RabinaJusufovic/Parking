using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking.database.Models
{
    public class Parking
    {
        public int id { get; set; }
        public string address { get; set; }
        public long latitude { get; set; }
        public long longitude { get; set; }
        public int phone { get; set; }
        public int workingHours { get; set; }
        public int price { get; set; }
        public bool availability { get; set; }
        public int rate { get; set; }

        [ForeignKey("parkingRefId")]
        public ICollection<Comments> Comments { get; set; }

        [ForeignKey("parkingsRefId")]
        public ICollection<Favorite> Favorite { get; set; }

        [ForeignKey("parkingId")]
        public ICollection<Reserve> Reserve { get; set; }
    }
}
