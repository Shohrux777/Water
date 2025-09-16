using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_invoice")]
    public class PosInvoice : PosBaseModel
    {
        public DateTime date { get; set; } = DateTime.Now;
        public String note { get; set; }
        public String factura_number { get; set; }
        public long? postavshik_id { get; set; }

        [ForeignKey("postavshik_id")]
        public PosCompany postavshik { get; set; }
        public long sklad_id { get; set; }

        [ForeignKey("sklad_id")]
        public PosSklad sklad { get; set; }
        public long department_id { get; set; }

        [ForeignKey("department_id")]
        public PosDepartment department { get; set; }
        public double summ { get; set; } = 0;
        public double debit_summ { get; set; } = 0;
        public double credit_sum { get; set; } = 0;
        public List<PosInvoiceItem> invoiceItems { get; set; }
        public bool applyment_status { get; set; } = false;
        public String postavshik_name => postavshik != null ? postavshik.name : "";

    }
}
