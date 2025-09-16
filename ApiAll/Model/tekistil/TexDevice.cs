using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_device")]
    public class TexDevice:TekstilBaseModel
    {

        public String name { get; set; }
        [Required]
        public String code { get; set; }
        public String ip { get; set; }
        public long device_type_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("device_type_id")]
        public TexDeviceType deviceType { get; set; }
        [NotMapped]
        public String device_type_name => deviceType != null ? deviceType.name : "";

        public long department_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("department_id")]
        public TexDepartment department { get; set; }
        [NotMapped]
        public String department_name => department != null ? department.name : "";

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

        public List<TexDeviceSubProccessDetail> texSubProccessList { get; set; }
    }
}
