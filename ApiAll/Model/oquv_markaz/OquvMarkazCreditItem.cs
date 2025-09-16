using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_credit_item")]
    public class OquvMarkazCreditItem:OquvMarkazBaseModel
    {
        public long OquvMarkazCheckid  { get; set; }
        public OquvMarkazCheck check { get; set; }
        public double summ { get; set; }
        public long OquvMarkazCreditid { get; set; }
        public OquvMarkazCredit credit { get; set; }

    }
}
