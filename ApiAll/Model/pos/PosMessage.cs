using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_message")]
    public class PosMessage : PosBaseModel
    {
        public long pos_message_group_id { get; set; }
        public PosMessageGroup group { get; set; }
        public String message { get; set; }
        public bool send_or_recive_status { get; set; }
        public bool readed_statatus { get; set; } = false;
        public bool sended_ower_bot_status { get; set; } = false;
        public long? answered_auth_id { get; set; }
    }
}
