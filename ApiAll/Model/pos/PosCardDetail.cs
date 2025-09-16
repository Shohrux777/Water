using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_card_detail")]
    public class PosCardDetail:PosBaseModel
    {
        public String card_number { get; set; }
        public long card_type_id { get; set; }

        [ForeignKey("card_type_id")]
        public PosClientCardType cardType { get; set; }
    }
}
