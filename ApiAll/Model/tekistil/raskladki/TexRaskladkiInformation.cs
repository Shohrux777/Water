using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_raskladki_information")]
    public class TexRaskladkiInformation : TekstilBaseModel
    {
        public String dlina { get; set; }
        public String shirina { get; set; }
        public String effect { get; set; }
        public String optsii { get; set; }
        public double qty_project { get; set; } = 0.0;
        public double qty_product { get; set; } = 0.0;
        public double qty_detail { get; set; } = 0.0;
        public double qty_summ { get; set; } = 0.0;
        public long? TexUnitmeasurmentid { get; set; }
        public TexUnitmeasurment ves_name_unit { get; set; }
        public double? gotoviy_ves { get; set; } = 0.0;
        public double? ispolzivinniy_ves { get; set; } = 0.0;
        public double? lichniy_ves { get; set; } = 0.0;

    }
}
