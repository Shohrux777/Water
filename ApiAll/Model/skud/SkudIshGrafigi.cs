using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_ish_grafigi")]
    public class SkudIshGrafigi
    {
        [Key]
        public String nomi { get; set; }
        public int? sikl_soni { get; set; }
        public String kun_hafta { get; set; }
    }
}
