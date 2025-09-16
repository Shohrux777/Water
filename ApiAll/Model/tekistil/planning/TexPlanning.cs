using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.planning
{
    [Table("tex_planning")]
    public class TexPlanning : TekstilBaseModel
    {
        public String planning_number { get; set; }
        public long? TexOrderid { get; set; }
        public TexOrder order { get; set; }
        public long? TexRaskladkiid { get; set; }
        public TexRaskladki raskladki { get; set; }
        public DateTime reg_date { get; set; }
        public String note { get; set; }
        public String note_1 { get; set; }
        public String note_2 { get; set; }
        public long? TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }
        public long? TexContragentid{ get; set; }
        public TexContragent contragent { get; set; }
        public String info { get; set; }
        public List<TexPlanningItems> items_list { get; set; }
    }
}
