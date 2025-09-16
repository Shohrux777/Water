using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_ostatka")]
    public class OquvMarkazOstatka:OquvMarkazBaseModel
    {
        public long OquvMarkazProductid  { get; set; }
        public OquvMarkazProduct product { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
    }
}
