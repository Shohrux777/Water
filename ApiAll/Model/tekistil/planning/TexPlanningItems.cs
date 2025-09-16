using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.planning
{
    [Table("tex_planning_items")]
    public class TexPlanningItems : TekstilBaseModel
    {
        
        [ForeignKey("created_auth_id")]
        public TexAuthorization created_auth { get; set; }
        public long? updated_user_id { get; set; }


        public long? TexProductid { get; set; }
        public TexProduct ishalab_chiqariladigon_product { get; set; }

        
        [ForeignKey("retsep_product_id")]
        public TexProduct retsep_product { get; set; }
        public long? retsep_product_id { get; set; }

        public long? TexColorid { get; set; }
        public TexColor color { get; set; }

        public double qty { get; set; } = 0.0;
        public double qty_1 { get; set; } = 0.0;
        public double qty_2 { get; set; } = 0.0;
        public double qty_3 { get; set; } = 0.0;
        public double qty_4 { get; set; } = 0.0;
        public double qty_5 { get; set; } = 0.0;
        public bool main_item { get; set; } = true;

        public long? TexPlanningItemsid { get; set; }
        public TexPlanningItems main_plan_item { get; set; }

        public long? TexSizeid { get; set; }
        public TexSize texSize { get; set; }

        public long? TexSubProductid { get; set; }
        public TexSubProduct subProduct { get; set; }
        public double sub_qty { get; set; } = 0.0;
        public double sub_qty_1 { get; set; } = 0.0;
        public double sub_qty_2 { get; set; } = 0.0;
        public double sub_qty_3 { get; set; } = 0.0;
        public double sub_qty_4 { get; set; } = 0.0;
        public double sub_qty_5 { get; set; } = 0.0;
        public String measurment_name { get; set; }
        public String measurment_name_1 { get; set; }

        public long? TexPlanningid { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexPlanning planning { get; set; }

    }
}
