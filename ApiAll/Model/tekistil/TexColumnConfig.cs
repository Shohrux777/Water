using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_column_config")]
    public class TexColumnConfig:TekstilBaseModel
    {
        public String table_name { get; set; }

        [Column(TypeName = "jsonb")]
        public String columns { get; set; }
        public long auth_id { get; set; }
        public TexAuthorization authorization { get; set; }
        [NotMapped]
        public JArray columns_json  => JsonConvert.DeserializeObject<JArray>(string.IsNullOrEmpty(this.columns) ? "[]" : this.columns);
      
        [NotMapped]
        public JArray column_default_obj { get; set; }

        public long? created_auth_id { get; set; }

        [ForeignKey("created_auth_id")]
        public TexAuthorization created_auth { get; set; }
        public long? updated_user_id { get; set; }

        [ForeignKey("updated_user_id")]
        public TexAuthorization updated_user { get; set; }
    }
}
