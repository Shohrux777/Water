using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_invoice_type")]
    public class TegirmonInvoiceType : TegirmonBaseModel
    {
      public String name { get; set; }
    }
}
