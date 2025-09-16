using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.order_item_steps
{
    [Table("tex_order_item_size_and_count")]
    public class TexOrderItemSizeAndCount : TekstilBaseModel
    {

        public TexSize size { get; set; }
        public long TexSizeid { get; set; }
        public double? qty { get; set; } = 0.0;
        public double? real_qty { get; set; } = 0.0;
        public double? brak_qty { get; set; } = 0.0;
        public double? finish_qty { get; set; } = 0.0;
        public double? otmen_qty { get; set; } = 0.0;
        public double? reserved_qty { get; set; } = 0.0;
        public double? reserved_qty_1 { get; set; } = 0.0;
        public double? reserved_qty_2 { get; set; } = 0.0;
        public double? reserved_qty_3 { get; set; } = 0.0;
        public double? reserved_qty_4 { get; set; } = 0.0;
        public TexOrderItem TexOrderItem { get; set; }
        public long TexOrderItemid { get; set; }

    }
}
