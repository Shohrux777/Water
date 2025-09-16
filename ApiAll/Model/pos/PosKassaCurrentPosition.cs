using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{

    [Table("pos_kassa_current_position")]
    public class PosKassaCurrentPosition
    {
        public double? total_sum { get; set; }
        public double? card_sum { get; set; }
        public double? cash_sum { get; set; }
        public double? payme_sum { get; set; }
        public double? click_sum { get; set; }
        public double? online_sum { get; set; }
        public double? humo_sum { get; set; }
        public double? mobil_sum { get; set; }
        public double? discount_sum { get; set; }
        public double? bonus_sum { get; set; }
        public double? xarajat_sum { get; set; }
        public double? profit_sum { get; set; }
    }
}
