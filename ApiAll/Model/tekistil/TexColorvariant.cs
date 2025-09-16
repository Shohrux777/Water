using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_colorvariant")]
    public class TexColorvariant:TekstilBaseModel
    {

        public String name { get; set; }
        public String note { get; set; }
        public long? color_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_id")]
        public TexColor texColor { get; set; }
        [NotMapped]
        public String color_name => texColor != null ? texColor.name : "";

        public long? guscolor_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("guscolor_id")]
        public TexGuscolor texGuscolor { get; set; }
        [NotMapped]
        public String gus_color_name => texGuscolor != null ? texGuscolor.name : "";
        public long? color_variant_type_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_variant_type_id")]
        public TexColorVariantType colorVariantType { get; set; }
        [NotMapped]
        public String color_varian_type_name => colorVariantType != null ? colorVariantType.name : "";
        public long? product_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("product_id")]
        public TexProduct product { get; set; }
        [NotMapped]
        public String product_name => product != null ? product.name : "";

        public long? rpt_sequence { get; set; }
        public long? parent_colorvariant_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("parent_colorvariant_id")]
        public TexColorvariant parent_colorvariant { get; set; }
        [NotMapped]
        public String parent_colorvariant_name => parent_colorvariant != null ? parent_colorvariant.name : "";

        public long? batchprocess_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("batchprocess_id")]
        public TexBatchprocess batchprocess { get; set; }

        [NotMapped]
        public String batchprocess_name => batchprocess != null ? batchprocess.name : "";


        public DateTime date { get; set; } = DateTime.Now;
        public int? color_number { get; set; }

        public long? created_auth_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("created_auth_id")]
        public TexAuthorization created_auth { get; set; }
        public long? updated_user_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("updated_user_id")]
        public TexAuthorization updated_user { get; set; }
    }
}
