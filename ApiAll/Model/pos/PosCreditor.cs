using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_creditor")]
    public class PosCreditor : PosBaseModel
    {
        public double creditor_price { get; set; } = 0.0;
        public double real_creditor_price { get; set; } = 0.0;
        public DateTime reg_date { get; set; } = DateTime.Now;
        public List<PosCreditorItem> itemList { get; set; }
        public long PosInvoiceid { get; set; }
        public PosInvoice invoice { get; set; }
        public String postavshik_name => invoice != null ? (invoice.postavshik != null ? invoice.postavshik.name : "") : "";
        [NotMapped]
        public String reg_date_str => reg_date != null ? ((DateTime)reg_date).Date.ToString("dd-MM-yyyy") : "";
        [NotMapped]
        public String creditor_price_str => String.Format("{0:N}", creditor_price);
        [NotMapped]
        public String real_creditor_price_str => String.Format("{0:N}", real_creditor_price);

    }
}

