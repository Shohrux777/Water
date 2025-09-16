using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tegirmon
{
    public class TegirmonMoneyInfoTemp
    {
        public double? card { get; set; }
        public double? cash { get; set; }
        public double? summ { get; set; }
        public double? profit_sum { get; set; }
        public double? real_sum { get; set; }
        public double? humo { get; set; }
        public double? uz_card { get; set; }
        public double? perchisleniya { get; set; }
        public double? dolg { get; set; }
        public double? dolg_payed { get; set; }
        public double? creadit_payed { get; set; }
        public double? rasxod { get; set; }
        public double? online { get; set; }
        public double? salary { get; set; }
        public double? for_buy_tovar_rasxod { get; set; }
        public double? srogi_otganlar_uchun_rasxod { get; set; }
    }
}

/*
 SELECT 
sum(card) as card, 
sum(cash) as cash, 
sum(summ) as summ, 
sum(profit_summ) as profit_sum, 
sum(real_sum) as real_sum, 
sum(humo) as humo, 
sum(uz_card) as uz_card, 
sum(perchisleniya) as perchisleniya, 
sum(dolg) as dolg, 
sum(dolg_payed) as dolg_payed, 
sum(creadit_payed) as creadit_payed, 
sum(rasxod) as rasxod, 
sum(online) as online, 
sum(salary) as salary, 
sum(for_buy_tovar_rasxod) as for_buy_tovar_rasxod, 
sum(srogi_otganlar_uchun_rasxod) as srogi_otganlar_uchun_rasxod
FROM public.tegirmon_check WHERE create_date BETWEEN '2022-01-01 00:00:00' AND '2022-08-08 00:00:00'
 
 */