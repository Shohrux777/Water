using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_invoice")]
    public class OquvMarkazInvoice:OquvMarkazBaseModel
    {
        public String note { get; set; }
        public String inv_number { get; set; }
        public DateTime date_time { get; set; } = DateTime.Now;
        public double summ { get; set; } = 0.0;
        public List<OquvMarkazInvoiceItem> item { get; set; }
    }
}
