using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_invlice_item")]
    public class OquvMarkazInvoiceItem:OquvMarkazBaseModel
    {
        public double qty { get; set; } = 0.0;
        public double unit_price { get; set; } = 0.0;
        public double summ { get; set; } = 0.0;
        public long OquvMarkazProductid  { get; set; }
        public OquvMarkazProduct product { get; set; }
        public long OquvMarkazInvoiceid { get; set; }
        public OquvMarkazInvoice invoice { get; set; }
    }
}
