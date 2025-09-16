using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class MarketProfitCustomReport
    {
        public double? saled_price { get; set; }
        public double? buyed_price { get; set; }
        public double? profit_price { get; set; }
        public String company_name { get; set; }


    }
}


/*
 SELECT  
sum("saledPrice") as saled_price, 
sum("buyedPrice") as buyed_price, 
sum("profitPrice") as profit_price, 
"companyName" as company_name
FROM "MarketPayments"
WHERE "CompanyId" != 0  
AND  "createdDateTime" BETWEEN '2021-09-29 00:00:00' AND '2021-09-30 23:59:59'
GROUP BY "companyName";

 */