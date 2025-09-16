using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_for_trenajor")]
    public class SkudForTrenajor
    {
        [Key]
        public long userid { get; set; }
        public int active_days { get; set; } = 0;

        [DataType(DataType.Date)]
        public DateTime b_date { get; set; }   
        
        [DataType(DataType.Date)]
        public DateTime e_date { get; set; }

    }
}
