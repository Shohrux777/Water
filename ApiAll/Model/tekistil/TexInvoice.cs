using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_invoice")]
    public class TexInvoice : TekstilBaseModel
    {
        public DateTime date { get; set; } = DateTime.Now;
        public long? contraget_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("contraget_id")]
        public TexContragent contragent { get; set; }
        [NotMapped]
        public String company_name => contragent != null ? contragent.name : "";

        public long? created_auth_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("created_auth_id")]
        public TexAuthorization created_auth { get; set; }
        public long? updated_auth_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("updated_auth_id")]
        public TexAuthorization updated_auth { get; set; }
        public long? valyuta_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("valyuta_id")]
        public TexValyuta valyuta { get; set; }
        [NotMapped]
        public String valyuta_name => valyuta != null ? valyuta.name : "";

        public double? kurs_valyut { get; set; }
        public long? sklad_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("sklad_id")]
        public TexSklad sklad { get; set; }
        [NotMapped]
        public String sklad_name => sklad != null ? sklad.name : "";

        public long? filial_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("filial_id")]
        public TexContragent filial { get; set; }
        [NotMapped]
        public String filial_name => filial != null ? filial.name : "";
        public double? summa { get; set; }
        public double? count { get; set; }
        public long? service_type_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("service_type_id")]
        public TexServiceType serviceType { get; set; }
        public long? payment_type_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("payment_type_id")]
        public TexPaymentType paymentType { get; set; }
        [NotMapped]
        public String paymen_type_name => paymentType != null ? paymentType.name : "";
        public long? department_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("department_id")]
        public TexDepartment department { get; set; }

        [NotMapped]
        public String department_name => department != null ? department.name : "";
        public long? calc_type_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("calc_type_id")]
        public TexCalcType calcType { get; set; }

        [NotMapped]
        public String calctype_name => calcType != null ? calcType.name : "";

        public long? invoice_type_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("invoice_type_id")]
        public TexInvoiceType invoiceType { get; set; }
        [NotMapped]
        public String invoice_type_name => invoiceType != null ? invoiceType.name : "";
        public long? main_sklad_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_sklad_id")]
        public TexSklad mainSklad { get; set; }

        [NotMapped]
        public String main_sklad_name => mainSklad != null ? mainSklad.name : "";
        public long? main_department_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_department_id")]
        public TexDepartment maindepartment { get; set; }
        [NotMapped]
        public String main_department_name => maindepartment != null ? maindepartment.name : "";
        public long? main_company_id { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_company_id")]
        public TexContragent maincompany { get; set; }
        [NotMapped]
        public String main_company_name => maincompany != null ? maincompany.name : "";
        public bool accepted_user { get; set; } = false;

        [NotMapped]
        public List<TexInvoiceItem> invoiceItemList { get; set; }

        public String status_type_name { get; set; }

        public DateTime? begin_date_time { get; set; } = DateTime.Now;
        public DateTime? end_date_time { get; set; } = DateTime.Now;
        public long? order_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_id")]
        public TexOrder order { get; set; }

        [NotMapped]
        public String order_number => order != null ? order.order_number : "";
        [NotMapped]
        public TexInvoiceItem simple_production_item { get; set; }

        [NotMapped]
        public TexInvoiceItem service_item { get; set; }
        [NotMapped]
        public double? precentage { get; set; }
        [NotMapped]
        public String order_number_main { get; set; }
        public String invoice_filter_status { get; set; }
        public long? receved_auth_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("receved_auth_id")]
        public TexAuthorization receved_auth { get; set; }

        [NotMapped]
        public bool can_change_status { get; set; } = true;


        //yangi qoshildi rasxod qilish uchun kerak boladi
        public String partiya_number { get; set; }
        public long? TexProductid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexProduct product { get; set; }

        [NotMapped]
        public String product_name => product != null ? product.name : "";

        public long? TexUserid { get; set; }
        public TexUser user { get; set; }

        public String zakaz_model_name { get; set; }

        public double zakaz_qty { get; set; } = 0.0;

        [NotMapped]
        public String user_name => user != null ? user.fio : "";

    }
}
