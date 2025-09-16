using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_message_group")]
    public class PosMessageGroup : PosBaseModel
    {
        public long bot_id { get; set; }
        public String name { get; set; }
        public String phone_number { get; set; }
        public DateTime reg_date_time { get; set; } = DateTime.Now;
        public String bot_name { get; set; }
    }
}
