using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_check")]
    public class OquvMarkazCheck : OquvMarkazBaseModel
    {
        public double summ { get; set; } = 0.0;
        public double credit { get; set; } = 0.0;
        public double debit { get; set; } = 0.0;
        public double cash { get; set; } = 0.0;
        public double card { get; set; } = 0.0;
        public double online { get; set; } = 0.0;
        public double salary { get; set; } = 0.0;
        public double rasxod { get; set; } = 0.0;
        public double discount { get; set; } = 0.0;
        public double discount_pesantage { get; set; } = 0.0;
        public double discount_summ { get; set; } = 0.0;
        public String note { get; set; }
        public String user_name { get; set; }
        public String reserve { get; set; }
        public double bonus_summ { get; set; } = 0.0;
        public double cashback_summ { get; set; } = 0.0;
        public String cashback_card { get; set; }
        public String cashback_user_phone_number { get; set; }
        public String cassir_name { get; set; }
        public bool kassa_close_status { get; set; } = false;

        public double kam_chiqqan_summ { get; set; } = 0.0;

        public long? OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }

        public List<OquvMarkazPayments> payment_list { get; set; }

        public long? OquvMarkazAuthid { get; set; }
        public OquvMarkazAuth auth { get; set; }

        public long? OquvMarkazUserid{ get; set; }
        public OquvMarkazUser user { get; set; }


    }
}
