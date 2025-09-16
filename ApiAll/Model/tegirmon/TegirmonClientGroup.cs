using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_client_group")]
    public class TegirmonClientGroup : TegirmonBaseModel
    {
       public String name { get; set; }
    }
}
