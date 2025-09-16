using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAll.Model.market;

namespace ApiAll.Model
{
    public class MarketPayments : BaseModel
    {
        public DateTime createdDateTime { get; set; }
        public long MarketProductId { get; set; }
        public MarketProduct product { get; set; }
        public String productName { get; set; }
        public String productCode { get; set; }
        public long MarketInvoiceItemId { get; set; }
        public MarketInvoiceItem invoiceItem { get; set; }
        public double saledPrice { get; set; }
        public double buyedPrice { get; set; }
        public double profitPrice { get; set; }
        public double persantage { get; set; }
        public long CompanyId { get; set; }
        public Company company { get; set; }
        public String companyName { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public String departmentName { get; set; }
        public long UsersId { get; set; }
        public Users users { get; set; }
        public String userName { get; set; }
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public String authPasswordAsCode { get; set; }
        public long MarketOrderId{get;set;}
        public MarketOrder marketOrder { get; set; }
        public long MarketOrderDetailId{get;set;}
        public MarketOrderDetail orderDetail { get; set; }
        public double qty { get; set; }

    }
}
