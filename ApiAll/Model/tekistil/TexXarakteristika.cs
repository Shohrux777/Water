using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_xarakteristika")]
    public class TexXarakteristika:TekstilBaseModel
    {

        public String name { get; set; }
        public String print_name { get; set; }

        public long? created_auth_id { get; set; }

        public long tovarlar_farqi { get; set; } = 0;

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
        public List<TexXarakteristikaTool> xarakteristikaToolList { get; set; }
        
    }
}
