using System;
using System.Collections.Generic;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_check")]
    public class TegirmonCheck : TegirmonBaseModel
    {
         public DateTime create_date { get; set; } = DateTime.Now;
         public long? TegirmonClientid { get; set; }
         public TegirmonClient client { get; set; }
         public List<TegirmonPayments> payments { get; set; }
         public double card { get; set; } = 0.0;
         public double cash { get; set; } = 0.0;
         public double summ { get; set; } = 0.0;
         public double profit_summ { get; set; } = 0.0;
         public double real_sum { get; set; } = 0.0;
         public double humo { get; set; } = 0.0;
         public double uz_card { get; set; } = 0.0;
         public double perchisleniya { get; set; } = 0.0;
         public double dolg { get; set; } = 0.0;
         public double dolg_payed { get; set; } = 0.0;
         public double creadit_payed { get; set; } = 0.0;
         public double rasxod { get; set; } = 0.0;
         public double online { get; set; } = 0.0;
         public double salary { get; set; } = 0.0;
         public double for_buy_tovar_rasxod { get; set; } = 0.0;
         public double srogi_otganlar_uchun_rasxod { get; set; } = 0.0;
         public DateTime reg_date_time { get; set; } = DateTime.Now;
         public bool  change_status { get; set; } = false;
         public String image_base_64 { get; set; }
         public String image_url { get; set; }
         public long? TegirmonContragentid { get; set; }
         public TegirmonContragent contragent { get; set; }
         public long? TegirmonCreditid { get; set; }
         public TegirmonCredit credit { get; set; }
         public bool dolg_status { get; set; } = false;
         public bool credit_status { get; set; } = false;
         public long? TegirmonAuthid { get; set; }
         public TegirmonAuth auth { get; set; }
    }
}
