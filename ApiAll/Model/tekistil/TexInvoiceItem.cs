using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_invoice_item")]
    public class TexInvoiceItem:TekstilBaseModel
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
        public long? invoice_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("invoice_id")]
        public TexInvoice invoice { get; set; }

        public double? qty { get; set; }
        public double? qty2 { get; set; }
        public double? summ { get; set; }
        public double? ostatka { get; set; }
        public double? price { get; set; }
        public double? price_real { get; set; }
        public String pus { get; set; }
        public String fein { get; set; }
        public double? shirina { get; set; }
        public double? grammaj { get; set; }
        public double? metraj { get; set; }
        public bool ugar { get; set; }
        public double? brutto { get; set; }
        public double? netto { get; set; }
        public String note { get; set; }
        public bool brak { get; set; }
        public long? product_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("product_id")]
        public TexProduct product { get; set; }
        [NotMapped]
        public String product_name_real => product != null ? product.name : "";
        public long? color_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("color_id")]
        public TexColor color { get; set; }

        [NotMapped]
        public String color_name_real => color != null ? color.name : "";
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
        public String main_proccess_name_real => mainProccess != null ? mainProccess.name : "";
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
        public String surovid_vid_name => suroviyVid != null ? suroviyVid.name : "";
        public long? main_item_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_item_id")]
        public TexInvoiceItem mainInvoiceItem { get; set; }
        public long? simple_prod_main_id { get; set; }
        public long item_status_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("item_status_id")]
        public TexStatus status { get; set; }
        [NotMapped]
        public String status_name => status != null ? status.name : "";
        public long? sort_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("sort_id")]
        public TexSort sort { get; set; }
        [NotMapped]
        public String sort_name => sort != null ? sort.name : "";
        public long? invoice_type_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("invoice_type_id")]
        public TexInvoiceType invoiceType { get; set; }

        public long? upakovka_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("upakovka_id")]
        public TexUpakovka upakovka { get; set; }
        [NotMapped]
        public String upakovka_name_real => upakovka != null ? upakovka.name : "";

        public String status_type_name { get; set; }
        [NotMapped]
        public String product_name { get; set; }   
        
        [NotMapped]
        public String color_name { get; set; }     
        
        [NotMapped]
        public String color_variant_name { get; set; }  
        
        [NotMapped]
        public String gus_color_name { get; set; }   
        
        [NotMapped]
        public String suroviy_vid_name { get; set; }   
        
        [NotMapped]
        public String main_proccess_name { get; set; }    
        
        [NotMapped]
        public String extra_work_name { get; set; }

        [NotMapped]
        public String upakovka_name { get; set; }
        [NotMapped]
        public double? precentage { get; set; }
        public String lot { get; set; }
        [NotMapped]
        public String unitmeasurment_name { get; set; }
        [NotMapped]
        public double? summa { get; set; }
        public long? order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_item_id")]
        public TexOrderItem orderItem { get; set; }

        [NotMapped]
        public bool? change_status { get; set; }
    

    }
}
