using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ApiAll.Model.tekistil.raskladki;

namespace ApiAll.Model.tekistil
{
    [Table("tex_raskladki")]
    public class TexRaskladki : TekstilBaseModel
    {
        public String order_name { get; set; }
        public String file_path_name { get; set; }
        public String file_name { get; set; }
        public String user_name { get; set; }
        public String raskladki_name { get; set; }
        public DateTime reg_raskladki_date_time { get; set; } = DateTime.Now;
        public long? TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }
        public long? TexRaskladkiInformationid { get; set; }
        public TexRaskladkiInformation information { get; set; }
        public String name_model { get; set; }
        public String vid_model { get; set; }
        public String zakazchikn_model { get; set; }
        public long? TexContragentid { get; set; }
        public TexContragent contragent { get; set; }
        public String model_str { get; set; }
        public List<TexRaskladkiModelQtyInformation> model_qty_info { get; set; }
        public long? TexRaskladkiModelRasxodInformationid { get; set; }
        public TexRaskladkiModelRasxodInformation rasxod_tkani { get; set; }
        public long? TexRaskladkiKroyInformationid { get; set; }
        public TexRaskladkiKroyInformation kroy_information { get; set; }
        public long? TexRaskladkiDeviceInformationid { get; set; }
        public TexRaskladkiDeviceInformation deviceInformation { get; set; }
        public List<TexRaskladkiStepInformation> stepInformation { get; set; }
        public String image_str { get; set; }
        public String image_url { get; set; }
        public String note { get; set; }
        public long? TexOrderid { get; set; }
        public TexOrder order { get; set; }
    }
}
