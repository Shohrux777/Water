using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("access_levels")]
    public class SkudAccessLevel
    {
        [Required]
        public String acc_name { get; set; }
        public String name_devices { get; set; }
        public String time_zones { get; set; }

    }
}
