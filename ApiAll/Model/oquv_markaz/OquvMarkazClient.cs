using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_client")]
    public class OquvMarkazClient:OquvMarkazBaseModel
    {
        public long? OquvMarkazClientTypeid { get; set; }
        public OquvMarkazClientType client_type { get; set; }
        public long? OquvMarkazContragentid { get; set; }
        public OquvMarkazContragent contragent { get; set; }
        public String fio { get; set; }
        public String address { get; set; }
        public String born_date { get; set; }
        public String phone_number { get; set; }
        public String phone_number_1 { get; set; }
        public String phone_number_2 { get; set; }
        public String image_str { get; set; }
        public String passport_number_str { get; set; }
        public List<int> free_days { get; set; }
        public bool waiting_status { get; set; } = true;
        public String note { get; set; }
        public String free_time { get; set; }
        public TimeSpan free_pupil_time { get; set; } = DateTime.Now.TimeOfDay;
        public long? bot_id { get; set; }
        [NotMapped]
        public String client_type_name => client_type != null ? client_type.name : "";
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.name : "";
    }
}
