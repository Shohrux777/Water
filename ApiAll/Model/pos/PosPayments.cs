using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_payments")]
    public class PosPayments : PosBaseModel
    {
        public long? product_id { get; set; }
        public PosProduct product { get; set; }
        public double qty { get; set; }
        public double unit_price { get; set; }
        public double summ { get; set; }
        public double real_sum { get; set; }
        public double discount_summ { get; set; }
        public long? PosCheckid { get; set; }
        public PosCheck check { get; set; }
        public bool check_revert_status { get; set; } = false;
        public double qty_in_pack { get; set; }
        public long PosInvoiceItemid { get; set; }
        public PosInvoiceItem item { get; set; }

        [NotMapped]
        public String product_name => product != null ? product.name : "";

    }
}
