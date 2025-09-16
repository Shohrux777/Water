using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_order")]
    public class TexOrder:TekstilBaseModel
    {
        public DateTime begin_datetime { get; set; }
        public DateTime end_datetime { get; set; }
        public long? client_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("client_id")]
        public TexContragent client { get; set; }
        [NotMapped]
        public String client_name => client != null ? client.name : "";
        public long? company_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("company_id")]
        public TexContragent company { get; set; }
        [NotMapped]
        public String company_name => company != null ? company.name : "";
        public long? department_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("department_id")]
        public TexDepartment department { get; set; }
        [NotMapped]
        public String department_name => department != null ? department.name : "";
        public String kurs { get; set; }
        public long? valuta_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("valuta_id")]
        public TexValyuta valyuta { get; set; }
        [NotMapped]
        public String valyuta_name => valyuta != null ? valyuta.name : "";
        public String note { get; set; }
        public String order_number { get; set; }
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
        public List<TexOrderItem> orderItemList { get; set; }

    }
}
