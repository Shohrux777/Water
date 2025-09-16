using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.telegram_bot
{
    [Table("hospital_telegram_bot_information_builder")]
    public class HospitalTelegramInformationBulider : HospitalBaseStandartModel
    {
        public List<String> image_base_64_list { get; set; }
        public List<String> images_url_list_after_saving_list { get; set; }
        public String title_name { get; set; }
        public String info { get; set; }
    }
}
