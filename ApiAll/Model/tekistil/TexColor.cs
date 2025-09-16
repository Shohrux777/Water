using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_color")]
    public class TexColor : TekstilBaseModel
    {

        public String name { get; set; }
        public String color_code { get; set; }
        public long? contraget_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("contraget_id")]
        public TexContragent contragent{ get; set; }
        public long? color_group_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_group_id")]
        public TexColorGroup colorgroup { get; set; }
        public String pantone_code { get; set; }
        public String dieing_code { get; set; }

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

        [NotMapped]
        public String company_name => contragent != null ? contragent.name : "";

        [NotMapped]
        public String color_group_name => colorgroup != null ? colorgroup.name : "";
        [NotMapped]
        public List<TexColorvariant> texColorvariantsList { get; set; }

    }
}
