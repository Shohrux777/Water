using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ApiAll.Model.tekistil.order_item_steps;

namespace ApiAll.Model.tekistil
{


    [Table("tex_order_item")]
    public class TexOrderItem : TekstilBaseModel
    {
       
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
        public long? production_type_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("production_type_id")]
        public TexProductionType productionType { get; set; }
        [NotMapped]
        public String production_type_name => productionType != null ? productionType.name : "";
        public long? service_type_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("service_type_id")]
        public TexServiceType serviceType { get; set; }
        [NotMapped]
        public String service_type_name => serviceType != null ? serviceType.name : "";
        public double qty { get; set; }
        public double? price { get; set; }
        public double? trb_grm_ot { get; set; }
        public double? trb_grm_do { get; set; }
        public double? trb_shir_ot { get; set; }
        public double? trb_shir_do { get; set; }
        public bool ugar { get; set; }
        public String note {get;set;}
        public String pus { get; set; }
        public String fein { get; set; }
        public double? shirina { get; set; }
        public double? grammaj { get; set; }
        public double? metraj { get; set; }
        public String lot { get; set; }
        public long? artikul { get; set; }
        public double? extra_work_price { get; set; }
        public long? product_id { get; set; }

        [ForeignKey("product_id")]
        public TexProduct product { get; set; }
        [NotMapped]
        public String product_name => product != null ? product.name : "";
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
        public long? main_proccess_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_proccess_id")]
        public TexMainProccess mainProccess { get; set; }
        [NotMapped]
        public String main_prosses_name => mainProccess != null ? mainProccess.name : "";
        public long? extra_work_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("extra_work_id")]
        public TexExtrawork extrawork { get; set; }
        [NotMapped]
        public String extrawork_name => extrawork != null ? extrawork.name : "";
        public long? suroviy_vid_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("suroviy_vid_id")]
        public TexSuroviyVid suroviyVid { get; set; }
        [NotMapped]
        public String suroviy_vid_name => suroviyVid != null ? suroviyVid.name : "";
        public long order_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_id")]
        public TexOrder order { get; set; }
        [NotMapped]
        public String orders_number => order != null ? order.order_number : "";
        public DateTime begin_date { get; set; } = DateTime.Now;
        public DateTime end_date { get; set; } = DateTime.Now;
        public long? size_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("size_id")]
        public TexSize size { get; set; }
        public String pantone_code { get; set; }
        [NotMapped]
        public String size_name => size != null ? size.name : "";
        public long? main_order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_order_item_id")]
        public TexOrderItem mainOrderItem { get; set; }

        public long? product_model_id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("product_model_id")]
        public TexProductModel model { get; set; }

        public bool started_status { get; set; } = false;
        [NotMapped]
        public List<TexOrderItem> child_order_item_list { get; set; }
        public List<TexOrderItemSizeAndCount> size_and_count_list { get; set; }
        public List<TexOrderitemStepsAndPersantage> texOrderitemStepsAndPersantageList { get; set; }


        public double ikkinchi_sort { get; set; } = 0.0;
        public double brak_soni { get; set; } = 0.0;
        public double real_soni { get; set; } = 0.0;
        public double finish_soni { get; set; } = 0.0;
        public double otmen_soni { get; set; } = 0.0;

    }
}
