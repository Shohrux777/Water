using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_debitor_item")]
    public class PosDebitorItem : PosBaseModel
    {
        public double summ { get; set; } = 0.0;
        public long PosDebitorid { get; set; }
        public PosDebitor inv { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
        public double card_sum { get; set; } = 0.0;
        public double cash_sum { get; set; } = 0.0;
        public double payme_sum { get; set; } = 0.0;
        public double click_sum { get; set; } = 0.0;
        public double online_sum { get; set; } = 0.0;
        public double humo_sum { get; set; } = 0.0;
        public double mobil_sum { get; set; } = 0.0;
        public double discount_summ { get; set; } = 0.0;
        public double bonus_summ { get; set; } = 0.0;
        public double profit_summ { get; set; } = 0.0;
        public long PosAuthorizationid { get; set; }
        public PosAuthorization auth { get; set; }
        public bool closed_status { get; set; } = false;
    }
}
