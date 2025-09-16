using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiAll.Model.tekistil.raskladki
{
    [Table("tex_raskladki_step_information")]
    public class TexRaskladkiStepInformation : TekstilBaseModel
    {
        public long TexRaskladkiid { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public TexRaskladki raskladki { get; set; }
        public String name1 { get; set; }
        public double qty1 { get; set; } = 0.0;

        public String name2 { get; set; }
        public double qty2 { get; set; } = 0.0;

        public String name3 { get; set; }
        public double qty3 { get; set; } = 0.0;


        public String name4 { get; set; }
        public double qty4 { get; set; } = 0.0;

    }
}
