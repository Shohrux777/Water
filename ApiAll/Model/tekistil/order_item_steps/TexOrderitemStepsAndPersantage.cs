using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.order_item_steps
{
    [Table("tex_order_item_steps_and_persantage")]
    public class TexOrderitemStepsAndPersantage : TekstilBaseModel
    {
        public TexOrderItemSteps texOrderItemSteps { get; set; }
        public long TexOrderItemStepsid { get; set; }

        public double persantage { get; set; } = 0.0;
        public long? sort_number { get; set; } = 0;

        public TexOrderItem orderItem { get; set; }
        public long TexOrderItemid { get; set; }

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
        public bool start { get; set; } = false;
        public bool stop { get; set; } = false;
        public bool finish { get; set; } = false;
        public bool remont { get; set; } = false;

        public String window_name { get; set; }
    }
}
