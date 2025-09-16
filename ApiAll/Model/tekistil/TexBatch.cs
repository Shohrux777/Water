using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_batch")]
    public class TexBatch : TekstilBaseModel
    {
        public DateTime begin_date { get; set; }
        public DateTime end_date { get; set; }

        public long? color_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_id")]
        public TexColor color { get; set; }
        [NotMapped]
        public String color_name => color != null ? color.name : "";

        public long? gus_color_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("gus_color_id")]
        public TexGuscolor guscolor { get; set; }
        [NotMapped]
        public String guscolor_name => guscolor != null ? guscolor.name : "";

        public long? color_variant_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_variant_id")]
        public TexColorvariant colorvariant { get; set; }


        [NotMapped]
        public String colorvariant_name => colorvariant != null ? colorvariant.name : "";

        public long? created_auth_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("created_auth_id")]
        public TexAuthorization created_auth { get; set; }
        public long? updated_user_id { get; set; }

        [ForeignKey("updated_user_id")]
        public TexAuthorization updated_user { get; set; }

        public long? device_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("device_id")]
        public TexDevice device { get; set; }
        [NotMapped]
        public String device_name => device != null ? device.name : "";

        public long? order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_item_id")]
        public TexOrderItem orderItem { get; set; }
        [NotMapped]
        public String order_number => orderItem != null ?(orderItem.order != null ? orderItem.order.order_number: "") : "";
    }
}
