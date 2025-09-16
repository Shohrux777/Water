using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{

    [Table("tex_real_product_remain")]
    public class TexRealProductRemain
    {
      public long? invoice_item_id { get; set; }
        public String product_name { get; set; }
        public long? product_id { get; set; }
        public double? ostatka { get; set; }
        public String color_name { get; set; }
        public long? color_id { get; set; }
        public String unitmeasurment_name { get; set; }
        public long? unitmeasurment_id { get; set; }
        public double? price { get; set; }
        public String suroviy_vid_name { get; set; }
        public long? suroviy_vid_id { get; set; }
        public String real_product_name { get; set; }
        public String date_str { get; set; }
        public String guscolor_name { get; set; }
        public long? guscolor_id { get; set; }
        public String extra_work_name { get; set; }
        public long? extra_work_id { get; set; }
        public String main_proccess_name { get; set; }
        public long? main_proccess_id { get; set; }
        public String upakovka_name { get; set; }
        public long? upakovka_id { get; set; }
        public String sort_name { get; set; }
        public long? sort_id { get; set; }
        [NotMapped]
        public String name => this.product_name != null ? this.product_name : "";

        [NotMapped]
        public TexInvoiceItem invoiceItem_fake { get; set; }

    }
}
