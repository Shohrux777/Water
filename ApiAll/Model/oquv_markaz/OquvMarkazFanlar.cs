using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_fanlar")]
    public class OquvMarkazFanlar:OquvMarkazBaseModel
    {
        public String name { get; set; }
        public double price { get; set; } = 0.0;
        public double summ_for_teacher { get; set; } = 0.0;
      
    }
}
