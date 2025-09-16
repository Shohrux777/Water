using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_debitor")]
    public class PosDebitor : PosBaseModel
    {
        public double debitor_price { get; set; } = 0.0;
        public double real_debitor_price { get; set; } = 0.0;
        public DateTime reg_date { get; set; } = DateTime.Now;
        public List<PosDebitorItem> itemList { get; set; }

        public long PosCompanyid { get; set; }
        public PosCompany client { get; set; }
        public String client_name => client != null ? client.name : "";
        [NotMapped]
        public String reg_date_str => reg_date != null ? ((DateTime)reg_date).Date.ToString("dd-MM-yyyy") : "";
        [NotMapped]
        public String creditor_price_str => String.Format("{0:N}", debitor_price);
        [NotMapped]
        public String real_creditor_price_str => String.Format("{0:N}", real_debitor_price);
    }
}
