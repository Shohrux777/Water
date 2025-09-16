using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ApiAll.Model.tekistil.planning;


namespace ApiAll.Model.tekistil.seworder
{
    [Table("tex_sew_order")]
    public class TexSewOrder : TekstilBaseModel
    {
        public long? TexContragentid { get; set; }
        public TexContragent contragent { get; set; }

        public long? TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }

        public long? TexPlanningid { get; set; }
        public TexPlanning texPlanning { get; set; }

        public long? TexInvoiceid { get; set; }
        public TexInvoice texInvoice { get; set; }

        public String note { get; set; }
        public String reserved_note { get; set; }

        public long? TexRaskladkiid { get; set; }
        public TexRaskladki raskladki { get; set; }

        public DateTime reg_date_time { get; set; } = DateTime.Now;

        public DateTime rejalashtrilgan_tugash_vaqti_date_time { get; set; } = DateTime.Now;

        public DateTime real_finished_date_time { get; set; } = DateTime.Now;

        public DateTime order_started_date_time { get; set; } = DateTime.Now;

        public bool finish_status { get; set; } = false;

        public bool start_status { get; set; } = false;

        public List<TexSewOrderItem> orderItemList { get; set; }

    }
}
