using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_debit_item")]
    public class OquvMarkazDebitItem:OquvMarkazBaseModel
    {
        public long OquvMarkazCheckid { get; set; }
        public OquvMarkazCheck check { get; set; }
        public double summ { get; set; }
        public long OquvMarkazDebitid { get; set; }
        public OquvMarkazDebit debit { get; set; }
    }
}
