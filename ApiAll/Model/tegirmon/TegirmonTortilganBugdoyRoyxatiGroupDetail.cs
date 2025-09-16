using ApiAll.Controllers.tegirmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_tortilgan_bugdoy_royxati_group_detail")]
    public class TegirmonTortilganBugdoyRoyxatiGroupDetail : TegirmonBaseModel
    {
        public long? TegirmonTortilganBugdoyRoyxatiGroupid { get; set; }
        public TegirmonTortilganBugdoyRoyxatiGroup bugdoyRoyxatiGroup { get; set; }
        public long? TegirmonTortilganBugdoyRoyxatiid { get; set; }
        public TegirmonTortilganBugdoyRoyxati royxati {get;set;}
        public long TegirmonInvoiceid { get; set; }
        public TegirmonInvoice invoice { get; set; }
        public String name { get; set; }
        public String note { get; set; }
        public long? reverced_note_id { get; set; }

    }
}
