using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_invoice_item")]
    public class TegirmonInvoiceItem : TegirmonBaseModel
    {
        public long TegirmonInvoiceid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TegirmonInvoice invoice { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public double sum { get; set; } = 0.0;
        public double real_sum { get; set; } = 0.0;
    }
}
