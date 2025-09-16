using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_creditor_item")]
    public class PosCreditorItem : PosBaseModel
    {
        public double summ { get; set; }
        public long PosCreditorid { get; set; }
        public PosCreditor inv { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
    }
}
