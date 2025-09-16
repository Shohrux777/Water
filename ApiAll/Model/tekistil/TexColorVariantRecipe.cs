using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_colorvariant_recipe")]
    public class TexColorVariantRecipe:TekstilBaseModel
    {
        public long? product_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("product_id")]
        public TexProduct product { get; set; }
        public long? unitmeasurment_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("unitmeasurment_id")]
        public TexUnitmeasurment unitmeasurment { get; set; }
        public long? color_variant_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_variant_id")]
        public TexColorvariant colorvariant { get; set; }
        public long? color_proccess_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_proccess_id")]
        public TexColorproccess colorproccess { get; set; }
        public double qty { get; set; }

    }
}
