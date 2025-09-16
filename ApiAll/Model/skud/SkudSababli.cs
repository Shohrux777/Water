using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_sababli")]
    public class SkudSababli
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public String sababi { get; set; }

        [DataType(DataType.Date)]
        public DateTime? _begin { get; set; }

        [DataType(DataType.Date)]
        public DateTime _end { get; set; }

        [DataType(DataType.Time)]
        public DateTime b_time { get; set; }

        [DataType(DataType.Time)]
        public DateTime e_time { get; set; }
    }
}
