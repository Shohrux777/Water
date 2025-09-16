using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ApiAll.Model.tekistil.planning;
using ApiAll.Model.tekistil.seworder;

namespace ApiAll.Model.tekistil.sewextrawork
{
    [Table("tex_sew_extra_work")]
    public class TexSewExtraWork : TekstilBaseModel
    {
        public long? TexSewOrderid { get; set; }
        public TexSewOrder texSewOrder { get; set; }

        public long? TexPlanningid { get; set; }
        public TexPlanning texPlanning { get; set; }

        public long? TexProductid { get; set; }
        public TexProduct texProduct { get; set; }

        public long? TexContragentid { get; set; }
        public TexContragent contragent { get; set; }

        public String note { get; set; }

        public long? TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }

        public DateTime reg_date_time { get; set; } = DateTime.Now;

        public DateTime start_date_time { get; set; } = DateTime.Now;

        public DateTime end_date_time { get; set; } = DateTime.Now;

        public bool start_status { get; set; } = false;

        public bool end_status { get; set; } = false;

        public DateTime tahminiy_tugah_vaqti { get; set; } = DateTime.Now;

        public List<TexSewExtraWorkItem> item_list { get; set; }
    }
}
