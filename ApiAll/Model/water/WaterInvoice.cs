using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_invoice")]
    public class WaterInvoice : WaterBaseModel
    {
        public String note { get; set; }
        public String invoice_number { get; set; }
        public WaterUser user { get; set; }
        public long? WaterUserid { get; set; }
        public WaterAuth auth { get; set; }
        public long? WaterAuthid { get; set; } = 0;
        public List<WaterInvoiceItem> items { get; set; }
    }
}
