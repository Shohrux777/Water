using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_product")]
    public class PosProduct : PosBaseModel
    {

        public String name { get; set; }
        public String bot_name { get; set; }
        public String print_name { get; set; }
        public String sale_name { get; set; }
        public String manifacturer_name { get; set; }
        public String code { get; set; }
        public String barcode { get; set; }
        public double? price { get; set; } = 0.0;
        public double? buyed_price { get; set; } = 0.0;
        public String image { get; set; }
        public String product_reg_code { get; set; }
        public String info { get; set; }
        public String publisher_name { get; set; }
        public double? percentage { get; set; } = 0.0;
        public long unitmeasurment_id { get; set; }
        public double? contains_number_in_pack { get; set; } = 1.0;
        public String dozirofka { get; set; }
        public String product_type_str { get; set; }
        public String global_name { get; set; }
        public bool retsepniy { get; set; } = false;
        public bool spravichniy { get; set; } = false;
        public String tax_number { get; set; }

        [ForeignKey("unitmeasurment_id")]
        public PosProductUnitMeasurment measurment { get; set; }
   
        public long? brend_id { get; set; }

        [ForeignKey("brend_id")]
        public PosBrend brend { get; set; }
        public long? category_id { get; set; }

        [ForeignKey("category_id")]
        public PosCategory category { get; set; }
        public long? product_type_id { get; set; }

        [ForeignKey("product_type_id")]
        public PosProductType type { get; set; }
        public long? product_tag_id { get; set; }

        [ForeignKey("product_tag_id")]
        public PosProductTag productTag { get; set; }
        public String note { get; set; }
        public long? main_product_id { get; set; }

        [ForeignKey("main_product_id")]
        public PosProduct mainPosProduct { get; set; }
  
        [NotMapped]
        public List<PosProduct> subProductList { get; set; }
        public double? nds { get; set; }
        public double? min_qty { get; set; } = 0.0;
        public bool discount_status { get; set; } = true;
        [NotMapped]
        public List<PosRecipe> posProductRecipeList { get; set; }
        [NotMapped]
        public List<PosProductCode> barcodeList { get; set; }


    }
}
