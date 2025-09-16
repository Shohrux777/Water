using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.sewextrawork
{
    [Table("tex_sew_extra_work_item")]
    public class TexSewExtraWorkItem : TekstilBaseModel
    {

        public long TexSewExtraWorkid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexSewExtraWork texSewExtraWork { get; set; }

        public long? TexProductid { get; set; }
        public TexProduct product { get; set; }

        public bool main_item { get; set; } = false;

        public long? TexColorid { get; set; }
        public TexColor color { get; set; }

        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public double brak_qty { get; set; } = 0.0;

        public long? TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }

        public DateTime reg_date_time { get; set; } = DateTime.Now;

        public DateTime start_date_time { get; set; } = DateTime.Now;

        public DateTime end_date_time { get; set; } = DateTime.Now;

        public bool start_status { get; set; } = false;

        public bool end_status { get; set; } = false;


    }
}
