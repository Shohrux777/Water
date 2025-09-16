using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_user")]
    public class TexUser:TekstilBaseModel
    {
        public String fio { get; set; }
        public String phone_number { get; set; }
        public String image { get; set; }
        public String cardnumber { get; set; }
        public String note { get; set; }
        public long? custom_user_number { get; set; }
        public DateTime? born_date { get; set; }
        public long department_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("department_id")]
        public TexDepartment department { get; set; }
        [NotMapped]
        public String department_name => department != null ? department.name : "";
        public long? position_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("position_id")]
        public TexPosition position { get; set; }
        [NotMapped]
        public String position_name => position != null ? position.name : "";
        public int pol_type { get; set; }
        public long? bot_id { get; set; }

        public long? created_auth_id { get; set; }
        public long? updated_user_id { get; set; }

        [NotMapped]
        public String login { get; set; }

        [NotMapped]
        public String password { get; set; }
        [NotMapped]
        public String password_not_md5 { get; set; }
        public String address { get; set; }
        public String passport_number { get; set; }

        [NotMapped]
        public TexAuthorization authorization { get; set; }

        [NotMapped]
        public long? auth_id_ex { get; set; }

        public List<long>? tex_category_id_list { get; set; }





    }
}
