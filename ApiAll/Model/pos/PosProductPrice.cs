using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_product_price")]
    public class PosProductPrice:PosBaseModel
    {
        public long product_id { get; set; }

        [ForeignKey("product_id")]
        public PosProduct product { get; set; }
        public double? price { get; set; }
        public double? buyed_price { get; set; }
        public double? percantage { get; set; }
        public double real_qty { get; set; }
        public double qty { get; set; }
        public double qty_in_pack { get; set; } = 0.0; 
        [NotMapped]
        public String product_name => product.name;
        
    }
}
