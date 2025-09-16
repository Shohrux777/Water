using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_kassa_current_position_with_name")]
    public class PosKassaCurrentPositionWithName
    {
        public String user_name { get; set; }
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

        [NotMapped]
        public String total_sum_str => String.Format("{0:N}", total_sum);
        [NotMapped]
        public String card_sum_str => String.Format("{0:N}", card_sum);
        [NotMapped]
        public String cash_sum_str => String.Format("{0:N}", cash_sum);
        [NotMapped]
        public String payme_sum_str => String.Format("{0:N}", payme_sum);
        [NotMapped]
        public String click_sum_str => String.Format("{0:N}", click_sum);
        [NotMapped]
        public String online_sum_str => String.Format("{0:N}", online_sum);
        [NotMapped]
        public String humo_sum_str => String.Format("{0:N}", humo_sum);
        [NotMapped]
        public String mobil_sum_str => String.Format("{0:N}", mobil_sum);
        [NotMapped]
        public String discount_sum_str => String.Format("{0:N}", discount_sum);
        [NotMapped]
        public String bonus_sum_str => String.Format("{0:N}", bonus_sum);
        [NotMapped]
        public String xarajat_sum_str => String.Format("{0:N}", xarajat_sum);
        [NotMapped]
        public String profit_sum_str => String.Format("{0:N}", profit_sum);


    }
}
