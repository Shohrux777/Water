using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_client_card_type")]
    public class PosClientCardType:BaseModel
    {
        public String name { get; set; }
        public double discount_persantage { get; set; }
        public String note { get; set; }

    }
}
