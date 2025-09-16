using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_probniy_darslar")]
    public class OquvMarkazProbniyDarslar:OquvMarkazBaseModel
    {
        public String name { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan begin_time { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan end_time { get; set; }
        public bool finish_group { get; set; } = false;
        public DateTime intermade_date { get; set; }
    }
}
