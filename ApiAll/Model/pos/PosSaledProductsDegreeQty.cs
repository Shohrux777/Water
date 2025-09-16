using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [NotMapped]
    [Table("pos_saled_products_degree_qty")]
    public class PosSaledProductsDegreeQty
    {
        public String product_name { get; set; }
        public double? total_qty { get; set; } = 0.0;
        public double? total_saled_sum { get; set; } = 0.0;
        public double? total_prixod_price { get; set; } = 0.0;
        public double? profit_price { get; set; } = 0.0;

        [NotMapped]
        public String total_qty_str => String.Format("{0:N}", total_qty);
        [NotMapped]
        public String total_saled_sum_str => String.Format("{0:N}", total_saled_sum);

        [NotMapped]
        public String total_prixod_price_str => String.Format("{0:N}", total_prixod_price);
        [NotMapped]
        public String profit_price_str => String.Format("{0:N}", profit_price);
    }
}
