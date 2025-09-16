using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_category")]
    public class TexCategory : TekstilBaseModel
    {

        public String name { get; set; }
        public String print_name { get; set; }
        public long? producttype_id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("producttype_id")]
        public TexTypeProduct typeProduct { get; set; }
        public long? measurment_type_id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("measurment_type_id")]
        public TexMeasurmentType measurmentType { get; set; }
        public double? kg { get; set; }
        public double? brutto { get; set; }
        public double? litr { get; set; }
        public double? metr { get; set; }
        public double? count{ get; set; }
        public List<long>? xarakteristika_id { get; set; }

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
        public String product_type_name => typeProduct != null ? typeProduct.name : "";
        [NotMapped]
        public String measurment_type_name => measurmentType != null ? measurmentType.name : "";
        [NotMapped]
        public List<TexXarakteristika> texXarakteristikaList { get; set; }


    }
}
