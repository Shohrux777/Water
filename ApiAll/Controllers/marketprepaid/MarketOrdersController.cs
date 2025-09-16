using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.market;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketOrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketOrdersController(ApplicationContext context)
        {
            _context = context;
        }
        
        // GET: api/MarketOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketOrder>>> GetMarketOrder()
        {
            return await _context.MarketOrder.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<PaginationModel>> getPagination([FromQuery]int page, [FromQuery] int size, [FromQuery] bool accepted)
        {
            PaginationModel paginationModel = new PaginationModel();
            paginationModel.marketOrdersList = await _context.MarketOrder.OrderByDescending(p => p.Id).Where(p => p.acceptedStatus == accepted).Include(p => p.authorization).ThenInclude(p => p.users).ThenInclude(p => p.department).ThenInclude(p => p.company).Skip((page - 1) * size).Take(size).ToListAsync();
            paginationModel.count = await _context.MarketOrder.Where(p => p.acceptedStatus == accepted).CountAsync();
            return paginationModel;
        }

        [HttpGet("getMarketOrderByDate")]
        public async Task<ActionResult<IEnumerable<MarketOrder>>> getMarketOrderByDate([FromQuery] DateTime beginDate, [FromQuery] DateTime endDate, [FromQuery] bool deliveredStatus)
        {
            return await _context.MarketOrder.Where(p => p.createdDateTime <= beginDate && endDate <= p.createdDateTime).Where(p => p.orderDeliveriedStatus == deliveredStatus).OrderByDescending(p => p.Id).ToListAsync();

        }

        [HttpGet("getMarketOrderNotDeliveredList")]
        public async Task<ActionResult<IEnumerable<MarketOrder>>> getMarketOrderNotDeliveredList()
        {
            return await _context.MarketOrder.Where(p => p.orderDeliveriedStatus != true).OrderByDescending(p => p.Id).ToListAsync();

        }

        [HttpGet("getMarketOrderDetailListByOrderId")]
        public async Task<ActionResult<IEnumerable<MarketOrderDetail>>> getMarketOrderDetailListByOrderId([FromQuery] long orderId)
        {
            return await _context.MarketOrderDetail.Where(p => p.MarketOrderId == orderId).OrderByDescending(p => p.Id).ToListAsync();

        }

        [HttpGet("getMarketOrderNotDeleviredProductList")]
        public async Task<ActionResult<IEnumerable<MarketOrderFullOrderedProducts>>> getMarketOrderNotDeleviredProductList([FromQuery] long companyId)
        {
            
            return await _context.MarketOrderFullOrderedProducts.FromSqlRaw("" +
                " " +
                " SELECT " +
                " sum(\"realQty\") as soni, " +
                " sum(summ) as summa, " +
                " \"productName\" as nomi, " +
                " \"productCode\" as codi, " +
                " \"productUnitMeasurmentName\" as olchovi, " +
                " c.\"Name\" as kompanya_nomi " +
                " FROM \"MarketOrderDetail\" as order_detail " +
                " LEFT JOIN \"MarketOrder\" as order_no_acc ON order_no_acc.\"Id\" = order_detail.\"MarketOrderId\" " +
                " LEFT JOIN authorizations as auth ON auth.\"Id\" = order_no_acc.\"AuthorizationId\" " +
                " LEFT JOIN companies as c ON c.\"Id\" = auth.\"CompanyId\"   " +
                " WHERE c.\"Id\" = "+ companyId + " AND order_no_acc.\"acceptedStatus\" = false " +
                " GROUP BY order_detail.\"productName\", order_detail.\"productCode\", order_detail.\"productUnitMeasurmentName\", c.\"Name\" ").ToListAsync();

        }  
        
        [HttpGet("getMarketProfitCustomReportList")]
        public async Task<ActionResult<IEnumerable<MarketProfitCustomReport>>> getMarketProfitCustomReportList([FromQuery] long companyId, [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate )
        {
            String beginDateStr = beginDate.Date.ToString("yyyy-MM-dd HH:mm:ss");
            String endDateStr = endDate.Date.ToString("yyyy-MM-dd HH:mm:ss");
            String companyIdStr = "!= 0";
            if (companyId != 0) {
                companyIdStr = " = " + companyId;
            }

            return await _context.MarketProfitCustomReport.FromSqlRaw("" +
                " SELECT "+
                " sum(\"saledPrice\") as saled_price, " +
                " sum(\"buyedPrice\") as buyed_price, " +
                " sum(\"profitPrice\") as profit_price, " +
                " \"companyName\" as company_name " +
                " FROM  \"MarketPayments\" " +
                " WHERE \"CompanyId\" "+ companyIdStr + " " +
                " AND  \"createdDateTime\" BETWEEN '"+ beginDateStr + "' AND '"+ endDateStr + "' " +
                " GROUP BY \"companyName\"; " +
                "").ToListAsync();

        }

        [HttpGet("setDeliveredMarkerOrderStatus")]
        public async Task<ActionResult<MarketOrder>> setDeliveredMarkerOrderStatus([FromQuery] long id)
        {
            var marketOrder = await _context.MarketOrder.FindAsync(id);
            MarketOrderDeliveriedInfo deliveriedInfo = new MarketOrderDeliveriedInfo();
            deliveriedInfo.ActiveStatus = true;
            if (marketOrder == null)
            {
                return new MarketOrder();
            }

            return marketOrder;

        }

        



        // GET: api/MarketOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketOrder>> GetMarketOrder(long id)
        {
            var marketOrder = await _context.MarketOrder.FindAsync(id);

            if (marketOrder == null)
            {
                return NotFound();
            }

            return marketOrder;
        }

        [HttpGet("getAcceptOrder")]
        public async Task<ActionResult<MarketOrder>> getAcceptOrder([FromQuery]long orderId)
        {
            var marketOrder = await _context.MarketOrder.FindAsync(orderId);

            if (marketOrder == null)
            {
                return NotFound();
            }

            if (marketOrder.acceptedStatus == true) {
                return NotFound();
            }



            Authorization authorization = await _context.authorizations.FindAsync(marketOrder.AuthorizationId);
            Company company = await _context.companies.FindAsync(authorization.CompanyId);
            Users users = await _context.Users.FindAsync(authorization.UsersId);
            Department department = await _context.departments.FindAsync(users.DepartmenId);
            //BEFORE ACCEPTING CHECK PRODUCT EXITS OR NOT

            //invoice item
            List<MarketInvoiceItem> invoiceItemList = new List<MarketInvoiceItem>();

            //payments item 
            List<MarketPayments> paymentsItemList = new List<MarketPayments>();

            List<MarketOrderDetail> orderDetailsList = await _context.MarketOrderDetail.Where(p => p.MarketOrderId == marketOrder.Id).ToListAsync();
            if (orderDetailsList != null && orderDetailsList.Count > 0) {
                bool no_resourse = false;
                foreach (MarketOrderDetail item in orderDetailsList) {
                    List<MarketInvoiceItem> marketProductInvoiceItemList = await _context.MarketInvoiceItem.Where(p => p.MarketProductId == item.MarketProductId && p.realQty > 0).OrderBy(p =>p.Id).ToListAsync();
                    if (marketProductInvoiceItemList != null && marketProductInvoiceItemList.Count > 0)
                    {
                        double realQty = item.realQty;
                        foreach (MarketInvoiceItem it in marketProductInvoiceItemList) {
                            if (realQty > 0) {
                                if (it.realQty > realQty)
                                {
                                    it.realQty = it.realQty - realQty;
                                    
                                    MarketProduct marketProduct = await _context.MarketProduct.FindAsync(it.MarketProductId);
                                    ///create payments report
                                    MarketPayments payments = new MarketPayments();
                                    payments.ActiveStatus = true;
                                    payments.qty = realQty;
                                    payments.MarketInvoiceItemId = it.Id;
                                    payments.MarketOrderId = marketOrder.Id;
                                    payments.MarketOrderDetailId = item.Id;
                                    payments.MarketProductId = item.MarketProductId;
                                    payments.productCode = marketProduct.Code;
                                    payments.productName = marketProduct.Name;
                                    payments.saledPrice = marketProduct.price * realQty;
                                    payments.buyedPrice = it.unitprice * realQty;
                                    payments.profitPrice = (marketProduct.price * realQty) - (it.unitprice * realQty);
                                    payments.persantage = 0;
                                    payments.UsersId = authorization.UsersId;
                                    payments.authPasswordAsCode = authorization.Password;
                                    payments.userName = users.FIO;
                                    payments.CompanyId = authorization.CompanyId;
                                    payments.companyName = company.Name;
                                    payments.DepartmentId = users.DepartmenId;
                                    payments.departmentName = department.Name;
                                    payments.createdDateTime = DateTime.Now;
                                    payments.AuthorizationId = authorization.Id;
                                    paymentsItemList.Add(payments);

                                    //add for updater
                                    realQty = 0;
                                    invoiceItemList.Add(it);


                                }
                                else {
                                    
                                    realQty = realQty - it.realQty;

                                    MarketProduct marketProduct = await _context.MarketProduct.FindAsync(it.MarketProductId);
                                    ///create payments report
                                    MarketPayments payments = new MarketPayments();
                                    payments.ActiveStatus = true;
                                    payments.qty = it.realQty;
                                    payments.MarketInvoiceItemId = it.Id;
                                    payments.MarketOrderId = marketOrder.Id;
                                    payments.MarketOrderDetailId = item.Id;
                                    payments.MarketProductId = item.MarketProductId;
                                    payments.productCode = marketProduct.Code;
                                    payments.productName = marketProduct.Name;
                                    payments.saledPrice = marketProduct.price * it.realQty;
                                    payments.buyedPrice = it.unitprice * it.realQty;
                                    payments.profitPrice = (marketProduct.price * it.realQty) - (it.unitprice * it.realQty);
                                    payments.persantage = 0;
                                    payments.UsersId = authorization.UsersId;
                                    payments.authPasswordAsCode = authorization.Password;
                                    payments.userName = users.FIO;
                                    payments.CompanyId = authorization.CompanyId;
                                    payments.companyName = company.Name;
                                    payments.DepartmentId = users.DepartmenId;
                                    payments.departmentName = department.Name;
                                    payments.createdDateTime = DateTime.Now;
                                    payments.AuthorizationId = authorization.Id;
                                    paymentsItemList.Add(payments);

                                    it.realQty = 0;
                                    invoiceItemList.Add(it);
                                }
                            }
                        }

                        //tovar yetmey qoldi demak xato
                        if (realQty > 0) {
                            no_resourse = true;
                        }


                    }
                    else {
                        no_resourse = true;

                    }
                }

                //if true need to remove
                if (no_resourse)
                {
                    return NotFound();
                }
                else {
                    //update invoice item
                    _context.MarketInvoiceItem.UpdateRange(invoiceItemList);
                    await _context.SaveChangesAsync();
                    //insert payment item 
                    _context.MarketPayments.UpdateRange(paymentsItemList);
                    await _context.SaveChangesAsync();
                }
            }



            marketOrder.acceptedDateTime = DateTime.Now;
            marketOrder.acceptedStatus = true;
            _context.MarketOrder.Update(marketOrder);
            await _context.SaveChangesAsync();



            return marketOrder;
        }

        // PUT: api/MarketOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketOrder(long id, MarketOrder marketOrder)
        {
            if (id != marketOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MarketOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketOrder>> PostMarketOrder(MarketOrder marketOrder)
        {
            bool st_new_not_update = false;
            if (marketOrder.Id == 0) {
                st_new_not_update = true;
            }
            marketOrder.createdDateTime = DateTime.Now;
            if (marketOrder!= null && marketOrder.Id == 0) {
                if (marketOrder.marketOrderDetails != null && marketOrder.marketOrderDetails.Count > 0)
                {
                    foreach (MarketOrderDetail item in marketOrder.marketOrderDetails) {
                        item.dateTime = DateTime.Now;
                    }
                }
            }
            _context.MarketOrder.Update(marketOrder);
            await _context.SaveChangesAsync();

            if (st_new_not_update) {
                String order_number = marketOrder.Id.ToString();
                marketOrder.orderNumber = order_number;
                _context.MarketOrder.Update(marketOrder);
                await _context.SaveChangesAsync();
            }
            return marketOrder;
        }


        // DELETE: api/MarketOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketOrder>> DeleteMarketOrder(long id)
        {
            var marketOrder = await _context.MarketOrder.FindAsync(id);
            if (marketOrder == null)
            {
                return NotFound();
            }

            List<MarketOrderDetail> marketOrderDetails = marketOrder.marketOrderDetails;
            if (marketOrder.marketOrderDetails == null || marketOrder.marketOrderDetails.Count == 0) {
                marketOrderDetails = await _context.MarketOrderDetail.Where(p => p.MarketOrderId == marketOrder.Id).ToListAsync();
            }

            Authorization authorization = await _context.authorizations.FindAsync(marketOrder.AuthorizationId);
            double returnedsumm = 0;
            if (marketOrderDetails != null && marketOrderDetails.Count > 0) {
                foreach (MarketOrderDetail orderDetail in marketOrderDetails) {
                    returnedsumm = returnedsumm + orderDetail.summ;
                }
            }
            if (returnedsumm != 0) {
                //MONEY RETURNED
                MarketPrePaidMoney marketPrePaid = new MarketPrePaidMoney();
                marketPrePaid.ActiveStatus = true;
                marketPrePaid.note = "отмена заказа";
                marketPrePaid.createdDateTime = DateTime.Now;
                marketPrePaid.realSumm = returnedsumm;
                marketPrePaid.reservedSumm = returnedsumm;
                marketPrePaid.UsersId = authorization.UsersId;
                _context.MarketPrePaidMoney.Update(marketPrePaid);
                await _context.SaveChangesAsync();

                //LIMIT RETURNED
                List<MarketAuthLimitByMoney> marketAuthLimits = await _context.MarketAuthLimitByMoney.Where(p => p.AuthorizationId == authorization.Id).ToListAsync();
                if (marketAuthLimits != null && marketAuthLimits.Count > 0) {
                    MarketAuthLimitByMoney limitByMoney = marketAuthLimits.First();
                    if ((limitByMoney.realSumm + returnedsumm) > limitByMoney.reservedSumm)
                    {
                        limitByMoney.realSumm = limitByMoney.reservedSumm;
                    }
                    else {
                        limitByMoney.realSumm = limitByMoney.realSumm + returnedsumm;
                    }
                    _context.MarketAuthLimitByMoney.Update(limitByMoney);
                    await _context.SaveChangesAsync();
                }

            }

            //remove all invoice item payments
            List<MarketPayments> marketPaymentsList = await _context.MarketPayments.Where( p => p.MarketOrderId == marketOrder.Id).ToListAsync();
            List<MarketInvoiceItem> invoiceItemList = new List<MarketInvoiceItem>();
            foreach (MarketPayments it in marketPaymentsList) {
                MarketInvoiceItem item = await _context.MarketInvoiceItem.FindAsync(it.MarketInvoiceItemId);
                item.realQty = item.realQty + it.qty;
                invoiceItemList.Add(item);
            }

            if (invoiceItemList != null && invoiceItemList.Count > 0) {
                //accept bolgan bolsa udalit qilish uchun kerak

                _context.MarketPayments.RemoveRange(marketPaymentsList);
                await _context.SaveChangesAsync();

                _context.MarketInvoiceItem.UpdateRange(invoiceItemList);
                await _context.SaveChangesAsync();


            }


            _context.MarketOrder.Remove(marketOrder);

            await _context.SaveChangesAsync();

            return marketOrder;
        }

        private bool MarketOrderExists(long id)
        {
            return _context.MarketOrder.Any(e => e.Id == id);
        }
    }
}
