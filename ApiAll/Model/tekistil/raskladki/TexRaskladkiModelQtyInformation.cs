using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiAll.Model.tekistil.raskladki
{
    [Table("tex_raskladki_model_qty_information")]
    public class TexRaskladkiModelQtyInformation : TekstilBaseModel
    {
        public long TexRaskladkiid { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public TexRaskladki raskladki { get; set; }

        public double qty { get; set; } = 0.0;
        public double qty_detail { get; set; } = 0.0;
        public long? TexSizeid { get; set; }
        public TexSize size { get; set; }

    }
}
