using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_debit_detail")]
    public class TegirmonDebitDetail :TegirmonBaseModel
    {
        public DateTime created_date { get; set; } = DateTime.Now;
        public long TegirmonDebitid { get; set; }
        public TegirmonDebit debit { get; set; }
        public long TegirmonInvoiceid { get; set; }
        public TegirmonInvoice invoice { get; set; }
    }
}
