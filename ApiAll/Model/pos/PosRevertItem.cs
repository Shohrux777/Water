using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_revert_item")]
    public class PosRevertItem:PosBaseModel
    {
        public long PosRevertid { get; set; }
        public PosRevert revert { get; set; }
        public long PosInvoiceItemid { get; set; }
        public PosInvoiceItem invce_item { get; set; }
        public double qty { get; set; } = 0.0;
        public double qty_in_pack { get; set; } = 0.0;
        public double price { get; set; }
        public long product_id { get; set; }
        [ForeignKey("product_id")]
        public PosProduct product { get; set; }
        public String note { get; set; }
        public long? check_id { get; set; }
        [ForeignKey("check_id")]
        public PosCheck check { get; set; }
    }
}
