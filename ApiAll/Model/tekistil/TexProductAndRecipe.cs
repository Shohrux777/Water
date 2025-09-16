using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_product_and_recipe")]
    public class TexProductAndRecipe : TekstilBaseModel
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexProduct product { get; set; }

        public long TexProductid { get; set; }


        public TexSize size { get; set; }
        public long? TexSizeid { get; set; }

        public TexColor color { get; set; }
        public long? TexColorid { get; set; }

        public TexUnitmeasurment unitmeasurment { get; set; }
        public long? TexUnitmeasurmentid { get; set; }

        public double? qty { get; set; }
        public double? real_qty { get; set; }

        public double? gramm { get; set; }
        public double? metraj { get; set; }

        public double? pus { get; set; }
        public double? feine { get; set; }

        public String val_note { get; set; }
        public String val_note1 { get; set; }
        public String val_note2 { get; set; }
        public String val_note4 { get; set; }
        public String val_note7 { get; set; }
        public String val_note5 { get; set; }
        public String val_note6 { get; set; }

        public long? val_reserverd_1 { get; set; }
        public long? val_reserverd_2 { get; set; }
        public long? val_reserverd_3 { get; set; }
        public long? val_reserverd_4 { get; set; }
        public long? val_reserverd_5 { get; set; }

        public long? val_reserverd_6 { get; set; }
        public long? val_reserverd_7 { get; set; }
        public long? val_reserverd_8 { get; set; }
        public long? val_reserverd_9 { get; set; }
        public long? val_reserverd_10 { get; set; }
        public long? val_reserverd_11 { get; set; }




        public double? val_reserverd_21 { get; set; }
        public double? val_reserverd_31 { get; set; }
        public double? val_reserverd_41 { get; set; }
        public double? val_reserverd_51 { get; set; }
        public double? val_reserverd_61 { get; set; }
        public double? val_reserverd_71 { get; set; }
        public double? val_reserverd_81 { get; set; }



    }
}
