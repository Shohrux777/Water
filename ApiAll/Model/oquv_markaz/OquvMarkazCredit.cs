using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_credit")]
    public class OquvMarkazCredit:OquvMarkazBaseModel
    {
        public double summ { get; set; } = 0.0;
        public double real_summ { get; set; } = 0.0;
        public List<OquvMarkazCreditItem> items { get; set; }
        public String note { get; set; }
        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }
    }
}
