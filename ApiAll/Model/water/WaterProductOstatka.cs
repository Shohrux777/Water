using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_product_ostatka")]
    public class WaterProductOstatka : WaterBaseModel
    {
        public WaterProduct product { get; set; }
        public long WaterProductid { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;


    }
}
