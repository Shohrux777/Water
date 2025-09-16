using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.access
{

    [Table("tex_warehouse_access")]
    public class TexWareHouseAccess : TekstilBaseModel
    {
        public long  TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }

        public long TexSkladid { get; set; }
        public TexSklad sklad { get; set; }
    }
}
