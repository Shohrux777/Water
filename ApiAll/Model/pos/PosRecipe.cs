using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_recipe")]
    public class PosRecipe : PosBaseModel
    {
        public long product_id { get; set; }

        [ForeignKey("product_id")]
        public PosProduct product { get; set; }
        public long recipe_product_id { get; set; }

        [ForeignKey("recipe_product_id")]
        public PosProduct recipeProduct { get; set; }
        public double qty { get; set; } = 0.0;
        public double price { get; set; } = 0.0;
           
     }
}
