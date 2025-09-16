using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_order_item_recipe_reserve")]
    public class TexOrderItemRecipeReserve : TekstilBaseModel
    {

        public long? main_order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_order_item_id")]
        public TexOrderItem mainOrderItem { get; set; }

        public long? sub_order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("sub_order_item_id")]
        public TexOrderItem subOrderItem { get; set; }

        public double qty { get; set; }
        public double real_qty { get; set; }

        public long invoice_item_id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("invoice_item_id")]
        public TexInvoiceItem mainInvoiceItem { get; set; }
    }
}
