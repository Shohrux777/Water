using System;
using System.Collections.Generic;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_credit")]
    public class TegirmonCredit : TegirmonBaseModel
    {
        public double summ { get; set; } = 0.0;
        public double real_summ { get; set; } = 0.0;
        public long TegirmonContragentid { get; set; }
        public TegirmonContragent contragent { get; set; }
        public String note { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
        public List<TegirmonCreditDetail> tegirmonCreditDetailList { get; set; }
    }
}
