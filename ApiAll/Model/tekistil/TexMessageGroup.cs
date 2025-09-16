using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_message_group")]
    public class TexMessageGroup:TekstilBaseModel
    {
        public long owner_auth_id { get; set; }
        public long friend_auth_id { get; set; }

    }
}
