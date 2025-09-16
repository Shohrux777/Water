using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_user")]
    public class PosUser : PosBaseModel
    {
        public String fio { get; set; }
        public String phone_number { get; set; }
        public String address { get; set; }
        public long? bot_id { get; set; }

        [NotMapped]
        public PosAuthorization authorization { get; set; }
    }
}
