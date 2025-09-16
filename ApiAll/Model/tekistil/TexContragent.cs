using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{

    [Table("tex_contragent")]
    public class TexContragent:TekstilBaseModel
    {

        public String name { get; set; }
        public bool type_client { get; set; }
        public bool type_postavshik { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
        public String note { get; set; }
        public String image { get; set; }
        public bool type_maincompany { get; set; }
        public long? created_auth_id { get; set; }
        public long? updated_user_id { get; set; }

    }
}
