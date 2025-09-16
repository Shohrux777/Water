using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_order_item_step_permissions")]
    public class TexOrderItemStepPermissions:TekstilBaseModel
    {
        public long order_steps_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_steps_id")]
        public TexOrderItemSteps itemSteps { get; set; }
        public long auth_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("auth_id")]
        public TexAuthorization authorization { get; set; }
        public bool edit { get; set; } = false;
        public bool delete { get; set; } = false;
        public bool update { get; set; } = false;
        public bool view { get; set; } = true;
    }
}
