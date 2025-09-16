using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_my_checkinout")]
    public class SkudMyCheckinout
    {
        public long userid { get; set; }

        [DataType(DataType.Date)]
        public DateTime sana { get; set; }

        [DataType(DataType.Time)]
        public DateTime checktime { get; set; }

        [StringLength(2)]
        public String checktype { get; set; }
        public String door_name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long code { get; set; }
        public String begona { get;}
    }
}
