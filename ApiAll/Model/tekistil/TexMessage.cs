using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_message")]
    public class TexMessage:TekstilBaseModel
    {
        public String message { get; set; }
        public String message_type { get; set; }
        [Column(TypeName = "date")]
        public DateTime message_date { get; set; } = DateTime.Now;
        public DateTime message_send_date { get; set; } = DateTime.Now;
        public DateTime message_receved_date { get; set; } = DateTime.Now;
        public bool readed_status { get; set; }
        public long sender_auth_id { get; set; }
        public long recevier_auth_id { get; set; }
        public long friend_auth_id { get; set; }
        public long owner_auth_id { get; set; }
        public long? main_message_id { get; set; }

        
    }
}
