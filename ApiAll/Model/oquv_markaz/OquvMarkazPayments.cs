using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_payments")]
    public class OquvMarkazPayments:OquvMarkazBaseModel
    {
        public long OquvMarkazCheckid { get; set; }
        public OquvMarkazCheck check { get; set; }

        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }

        public long? OquvMarkazFanlarid { get; set; }
        public OquvMarkazFanlar fanlar { get; set; }

        public double summ { get; set; } = 0.0;
    }
}
