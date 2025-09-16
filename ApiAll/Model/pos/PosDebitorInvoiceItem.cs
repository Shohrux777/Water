using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_debitor_invoice_item")]
    public class PosDebitorInvoiceItem : PosBaseModel
    {

        public long product_id { get; set; }

        [ForeignKey("product_id")]
        public PosProduct product { get; set; }
        public double price { get; set; } = 0.0;
        public double saled_price { get; set; } = 0.0;
        public double qty { get; set; } = 0;
        public double summ { get; set; } = 0;
        public long PosDebitorInvoiceid { get; set; }
        public PosDebitorInvoice invoice { get; set; }
        [Column(TypeName = "date")]
        public DateTime reg_date { get; set; } = DateTime.Now;
        public long PosInvoiceItemid { get; set; }
        public PosInvoiceItem item { get; set; }
        [NotMapped]
        public String product_name => product != null ? product.name : "";

        [NotMapped]
        public String sum_formatted => String.Format("{0:N}", ( price * qty ));

    }
}
