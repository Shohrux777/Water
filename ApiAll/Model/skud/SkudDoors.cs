using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_doors")]
    public class SkudDoors
    {
        public String dbname { get; set; }
        public String device { get; set; }
        public String drivertime { get; set; }
        public int? detectortime { get; set; }
        public int? intertime { get; set; }
        public String sensortype { get; set; }
        public int? nomer { get; set; }
        public String acc_name { get; set; }
        public int door_opentzid { get; set; } = 0;
        public String inout { get; set; }
        public String login { get; set; }
        public String password { get; set; }

    }
}
