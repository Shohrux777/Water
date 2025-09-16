using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_invoice_item")]
    public class PosInvoiceItem : PosBaseModel
    {
        public long product_id { get; set; }

        [ForeignKey("product_id")]
        public PosProduct product { get; set; }
        public double? unit_buyed_price { get; set; } = 0.0;
        public double? unit_saled_price { get; set; } = 0.0;
        public double qty { get; set; } = 0;
        public double real_qty { get; set; } = 0;
        public double summ { get; set; } = 0;
        public bool finished { get; set; } = false;
        public long PosInvoiceid{get;set;}
        public PosInvoice invoice { get; set; }
        public bool change_price_status { get; set; } = false;
        public double? persantage { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expired_date { get; set; } = DateTime.Now;
        public double qty_in_pack { get; set; }
        public double saved_in_pack { get; set; }
        public double persantage_nds { get; set; } = 0.0;
        public double persantage_discount { get; set; } = 0.0;
        public double unit_discount_price { get; set; } = 0.0;
        public String product_name => product != null ? product.name : "";

        [NotMapped]
        public String summ_of_remind => String.Format("{0:N}", (double)(unit_buyed_price != null ? unit_buyed_price * real_qty : 0.0));
        [NotMapped]
        public double exp_days_count => expired_date != null ? DateTime.Now.Subtract((DateTime)expired_date).TotalDays * -1 : 0;
        [NotMapped]
        public String exp_date_str => expired_date != null ? ((DateTime)expired_date).Date.ToString("dd-MM-yyyy") : "";

    }
}
