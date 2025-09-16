using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tegirmon
{
    [Table("tegirmon_authorization")]
    public class TegirmonAuth : TegirmonBaseModel
    {
          public String login { get; set; }
          public String pasword { get; set; }
          public long TegirmonUserid { get; set; }
          public TegirmonUser user { get; set; }
    }
}
