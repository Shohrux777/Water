using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_company")]
    public class PosCompany : PosBaseModel
    {
        public String name { get; set; }
        public String print_name { get; set; }
        public String info { get; set; }
        public String address { get; set; }
        public String note { get; set; }
        public String bot_info { get; set; }
        public String info_bot_key { get; set; }
        public String order_bot_key { get; set; }
        public String orderbot_info { get; set; }
        public double? nds { get; set; } = 0;
        public String location_company { get; set; }
        public String stir { get; set; }
        public bool pastavshik_status { get; set; } = false;
        public bool client_status { get; set; } = false;

    }
}
