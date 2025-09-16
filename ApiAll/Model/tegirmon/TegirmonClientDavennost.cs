using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_client_davennost")]
    public class TegirmonClientDavennost : TegirmonBaseModel
    {
        public String fio { get; set; }
        public String adddress { get; set; }
        public String passport_number { get; set; }
        public String phone_number { get; set; }
        public String home_phone_number { get; set; }
        public String note { get; set; }
        public String image_base_64 { get; set; }
        public String image_url { get; set; }
        public String car_number { get; set; }
        public String addiotionala_information { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        public DateTime udate_date { get; set; } = DateTime.Now;
        public String passport_image_base_64 { get; set; }
        public String passport_image_url { get; set; }
        public long TegirmonClientid { get; set; }
        public TegirmonClient client { get; set; }
    }
}
