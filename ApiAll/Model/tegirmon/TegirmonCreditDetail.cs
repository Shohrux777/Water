using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_credit_detail")]
    public class TegirmonCreditDetail : TegirmonBaseModel
    {
        public String note { get; set; }
        public long TegirmonCreditid{ get; set; }
        public TegirmonCredit credit { get; set; }
        public double summ { get; set; } = 0.0;
        public DateTime create_date { get; set; } = DateTime.Now;
        public long TegirmonInvoiceid { get; set; }
        public TegirmonInvoice invoice { get; set; }
        public long? auth_id { get; set; }
    }
}
