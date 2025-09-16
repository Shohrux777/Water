using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_real_summ_of_all_products")]
    public class PosRealSummOfAllProducts
    {
        public double? buyed_summa { get; set; }
        public double? saled_summa { get; set; }
    }
}
