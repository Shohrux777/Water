using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_authorization")]
    public class TexAuthorization:TekstilBaseModel
    {
        public String login { get; set; }
        public String password { get; set; }
        public String password_not_md5 { get; set; }
        public long company_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("company_id")]
        public  TexContragent company { get; set; }
        public long user_id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("user_id")]
        public TexUser user { get; set; }
        public int user_type { get; set; }

        [NotMapped]
        public String user_name => user != null ? user.fio : "";

        [NotMapped]
        public String company_name => company != null ? company.name : "";

        public List<long>? tex_category_id_list { get; set; }
    }
}
