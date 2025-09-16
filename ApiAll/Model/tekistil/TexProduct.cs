using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_product")]
    public class TexProduct:TekstilBaseModel
    {

        public String name { get; set; }
        public String print_name { get; set; }
        public long? barcode { get; set; }
        public long? category_id { get; set; }

        public long tovarlar_farqi { get; set; } = 0;
        public List<long>? tovar_xarakteristikasi_listi_ids { get; set; }
        public List<long>? tovar_ketadigon_product_listi_ids { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("category_id")]
        public TexCategory category { get; set; }

        [NotMapped]
        public String category_name => category != null ? category.name : "";

        public List<long>? selected_xarakteristika_ids { get; set; }
        public List<long>? planning_type_id { get; set; }
        public String note { get; set; }
        public String code { get; set; }
        public String code_2 { get; set; }

        public long? unitmeasurment_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("unitmeasurment_id")]
        public TexUnitmeasurment unitmeasurment { get; set; }
        [NotMapped]
        public String unitmeasurment_name => unitmeasurment != null ? unitmeasurment.name : "";
        public long? unitmeasurment_id_2 { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("unitmeasurment_id_2")]
        public TexUnitmeasurment unitmeasurment_2 { get; set; }
        [NotMapped]
        public String unitmeasurment_2_name => unitmeasurment_2 != null ? unitmeasurment_2.name : "";

        public long? production_type_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("production_type_id")]
        public TexProductionType productionType { get; set; }
        [NotMapped]
        public String production_type_name => productionType != null ? productionType.name : "";
        public double? kg  { get; set; }
        public double? brutto { get; set; }
        public double? litr { get; set; }
        public double? metr { get; set; }
        public double? count { get; set; }
        public String image { get; set; }

        public long? created_auth_id { get; set; }

        public List<TexProductAndRecipe> texProductAndRecipes { get; set; }

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
        public List<TexPlaningType> texPlaningTypeList { get; set; }
        [NotMapped]
        public List<TexXarakteristika> texXarakteristikaList { get; set; }
        [NotMapped]
        public List<TexXarakteristikaTool> texXarakteristikaToolList { get; set; }
    }
}
