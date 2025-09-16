using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.market;
using Telegram.Bot;
using System.Text;
using ApiAll.Model.hospital;
using ApiAll.Model.hospital.reports;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        //for BUKHORO
        //private readonly TelegramBotClient botClient = new TelegramBotClient("1958356792:AAEDu2gEXvF9llHoU85IdXKg8j2X39JEvRg");
        //private readonly TelegramBotClient botClient = new TelegramBotClient("2076384871:AAGFC1ry359GSHdDJHVkqSTBkRbNS360WdQ");

        //jizzax uchun kerak bu
         private readonly TelegramBotClient botClient = new TelegramBotClient("5051895294:AAH1hf1tzG5Vghm3Hhdw4-l3eUFNm0SUU8Y");



        public PaymentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet("getPaymentsListByContragentAndDateTime")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPaymentsListByContragentAndDateTime([FromQuery] long ContragentId,[FromQuery] DateTime beginDate,[FromQuery] DateTime endDate)
        {
            if (ContragentId == 0)
            {
                return await _context.payments.Where(p => p.ActiveStatus == true && (p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate))
                  .OrderByDescending(p => p.Id)
                  .Include(p => p.serviceType).ThenInclude( p => p.hospitalServiceTypeGroup)
                  .Include(p => p.patients)
                  .Include(p => p.authorization)
                  .Include(p => p.contragent)
                  .ToListAsync();
            }
            else {

                return await _context.payments.Where(p => p.ContragentId == ContragentId && (p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate))
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.serviceType).ThenInclude(p => p.hospitalServiceTypeGroup)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .Include(p => p.contragent)
                    .ToListAsync();
            }

        }


        [HttpGet("getPaginationByPatientId")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size,[FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Payments> categoryList = await _context.payments.Where(p => p.PatientsId == patient_id)
                .Include(p => p.patients)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .ThenInclude(p =>p.users)
                .Skip(page * size).Take(size).OrderByDescending(p => p.Id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<Payments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.payments.Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTimeAndDoctorAuthIdAll")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTimeAndDoctorAuthIdAll([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date,
            [FromQuery] DateTime end_date, [FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Payments> categoryList = await _context.payments.Where(p => p.AuthorizationId == auth_id
            &&(p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date))
                .Include(p => p.patients)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .ThenInclude(p => p.users)
                .Skip(page * size).Take(size).OrderByDescending(p => p.Id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<Payments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTimeAndDoctorAuthIdfinishPaymenttrue")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTimeAndDoctorAuthIdfinishPaymenttrue([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date,
            [FromQuery] DateTime end_date, [FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Payments> categoryList = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date) && p.FinishPayment == true)
                .Include(p => p.patients)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .ThenInclude(p => p.users)
                .Skip(page * size).Take(size).OrderByDescending(p => p.Id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<Payments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date) && p.FinishPayment == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByDateTimeAndDoctorAuthIdfinishPaymentfalse")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTimeAndDoctorAuthIdfinishPaymentfalse([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date,
    [FromQuery] DateTime end_date, [FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Payments> categoryList = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date) && p.FinishPayment == false)
                .Include(p => p.patients)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .ThenInclude(p => p.users)
                .Skip(page * size).Take(size).OrderByDescending(p => p.Id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<Payments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date) && p.FinishPayment == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTimeAndDoctorAuthIdfinishdoktorKoribBolgan")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTimeAndDoctorAuthIdfinishdoktorKoribBolgan([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date,
[FromQuery] DateTime end_date, [FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Payments> categoryList = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date) && p.Finish == true)
                .Include(p => p.patients)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .ThenInclude(p => p.users)
                .Skip(page * size).Take(size).OrderByDescending(p => p.Id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<Payments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.payments.Where(p => p.AuthorizationId == auth_id
            && (p.RegistratedDate >= begin_date && p.RegistratedDate <= end_date) && p.Finish == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaymentsListByKasirIdAndDateTime")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPaymentsListByKasirIdAndDateTime([FromQuery] long authId, [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            if (authId == 0)
            {
                return await _context.payments.Where(p => p.ActiveStatus == true && (p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate))
                  .OrderByDescending(p => p.Id)
                  .Include(p => p.serviceType)
                  .Include(p => p.patients)
                  .Include(p => p.authorization)
                  .Include(p => p.contragent)
                  .ToListAsync();
            }
            else
            {
                return await _context.payments.Where(p => p.creatorAuthId == authId && (p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate))
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.serviceType)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .Include(p => p.contragent)
                    .ToListAsync();
            }

        }

        [HttpGet("getPayedPaymentsListByAndDateTime")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPayedPaymentsListByAndDateTime([FromQuery] long authId, [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            if (authId == 0)
            {
                return await _context.payments.Where(p => p.ActiveStatus == true && (p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate) && p.FinishPayment == true)
                  .OrderByDescending(p => p.Id)
                  .Include(p => p.serviceType)
                  .Include(p => p.patients)
                  .Include(p => p.authorization)
                  .Include(p => p.contragent)
                  .ToListAsync();
            }
            else
            {
                return await _context.payments.Where(p => p.creatorAuthId == authId && (p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate) && p.FinishPayment == true)
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.serviceType)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .Include(p => p.contragent)
                    .ToListAsync();
            }

        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> Getpayments()
        {
            return await _context.payments
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.serviceType)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .Include(p => p.contragent)
                    .ToListAsync();
        }

        [HttpGet("getRealKassirCondition")]
        public async Task<ActionResult<IEnumerable<HospitalDailyKassirReport>>> getRealKassirCondition([FromQuery] long kassirAuthId,[FromQuery] DateTime beginDate,[FromQuery] DateTime endDate)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = endDate.ToString("yyyy-MM-dd hh:mm:ss");
            var result = await _context.HospitalDailyKassirReport.FromSqlRaw(
                " SELECT  sum(\"PaymentInCash\") as naqt, " +
                " sum(\"PaymentInCard\") as plastik, "+
                " (SELECT sum(price) as rasxod " +
                " FROM \"returnMoney\" " +
                " WHERE \"AuthorizationId\" = "+kassirAuthId+" " +
                " and \"RegistratedDate\" " +
                " between '"+ beginDateStr + "' " +
                " and '"+endDateStr+"') " +
                " FROM payments " +
                " WHERE \"creatorAuthId\" = "+kassirAuthId+" " +
                " AND \"FinishPayment\" = true " +
                " AND \"RegistratedDate\" " +
                " between '"+beginDateStr+"' " +
                " and '"+endDateStr+"'; ").ToListAsync();

            return result;

        }

        [HttpGet("getRealPayedServiceTotalInfo")]
        public async Task<ActionResult<IEnumerable<HospitalPaymentsReportFakeModel>>> getRealPayedServiceTotalInfo( [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = endDate.ToString("yyyy-MM-dd hh:mm:ss");
            var result = await _context.HospitalPaymentsReportFakeModel.FromSqlRaw(
                " SELECT hg.name as service_group_name,  \r\nsum(py.\"Summ\") as total, \r\nsum(py.\"PaymentInCash\") as cash, \r\nsum(py.\"PaymentInCard\") as card,\r\ncount(py.\"Id\") as service_count\r\nFROM payments py\r\nLEFT JOIN \"serviceTypes\" st ON st.\"Id\" = py.\"ServiceTypeId\"\r\nLEFT JOIN \"HospitalServiceTypeGroup\" hg ON hg.\"Id\" = st.\"HospitalServiceTypeGroupId\"\r\nWHERE (\"FinishPayment\" = true \r\nAND py.\"ActiveStatus\" = true)\r\nAND py.\"RegistratedDate\" between '"+beginDateStr+"' AND '"+endDateStr+"'\r\nGROUP BY hg.name ").ToListAsync();

            return result;

        }

        [HttpGet("getRealPayedServiceTotalInfoOtkazRejectUchun")]
        public async Task<ActionResult<IEnumerable<HospitalPaymentsReportFakeModel>>> getRealPayedServiceTotalInfoOtkazRejectUchun([FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = endDate.ToString("yyyy-MM-dd hh:mm:ss");
            var result = await _context.HospitalPaymentsReportFakeModel.FromSqlRaw(
                " SELECT \r\n\"HospitalServiceTypeGroupName\" as service_group_name,\r\nsum(\"cashSumm\") as cash, \r\nsum(\"cardSumm\") as card,\r\nsum(count) as service_count,\r\n0 as total\r\nFROM \"HospitalManagerReport\"\r\nWHERE \"createdDateTime\" between '" + beginDateStr+"' and '"+endDateStr+"' \r\nGROUP BY \"HospitalServiceTypeGroupName\"").ToListAsync();

            return result;

        }

        [HttpGet("getRealDnevnikCondition")]
        public async Task<ActionResult<IEnumerable<HospitalDailyKassirReport>>> getRealDnevnikCondition([FromQuery] long kassirAuthId, [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd HH:mm:ss");
            String endDateStr = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            String kassirIdStr = " = "+kassirAuthId;
            if (kassirAuthId  == 0) {
                kassirIdStr = "!= " + kassirAuthId;
            }
            var result = await _context.HospitalDailyKassirReport.FromSqlRaw("" +
                " SELECT serviceGroup.name as groupnomi, "+
                " count(*) as soni, " +
                " sum(\"PaymentInCash\") as naqt, " +
                " sum(\"PaymentInCard\") as plastik, " +
                " \"RegistratedDate\"::timestamp::date as vaqti, "+
                " u.\"FIO\" as kassirnomi " +
                " FROM  authorizations a, \"Users\" u, payments " +
                " LEFT JOIN \"serviceTypes\" as serviceType ON serviceType.\"Id\" = payments.\"ServiceTypeId\" " +
                " LEFT JOIN \"HospitalServiceTypeGroup\" as serviceGroup ON serviceGroup.\"Id\" = serviceType.\"HospitalServiceTypeGroupId\" " +
                " WHERE payments.\"FinishPayment\" = true AND a.\"Id\" = payments.\"creatorAuthId\" AND a.\"UsersId\" = u.\"Id\" " +
                " AND payments.\"creatorAuthId\" "+ kassirIdStr + "  " +
                " AND payments.\"RegistratedDate\" BETWEEN '"+ beginDateStr + "'  AND '"+ endDateStr + "' " +
                " GROUP BY serviceGroup.name, \"RegistratedDate\"::timestamp::date, u.\"FIO\" " +
                " ORDER BY \"RegistratedDate\"::timestamp::date").ToListAsync();

            return result;

        }

        [HttpPost("getRealServiceCountCondition")]
        public async Task<ActionResult<IEnumerable<HospitalServiceTypeGroupContragentReports>>> getRealServiceCountCondition(CustomReportMd customModelReport)
        {

            String beginDateStr = customModelReport.beginDate.Date.ToString("yyyy-MM-dd HH:mm:ss");
            String endDateStr = customModelReport.endDate.Date.AddHours(23.9999).ToString("yyyy-MM-dd HH:mm:ss");
            String distrctIsStr = "=" + customModelReport.districtId;
            String serviceGroupQrCreator = " ";
            if(customModelReport.districtId == 0){
                distrctIsStr = "!=" + customModelReport.districtId;
            }
            if (customModelReport.groupNames != null && customModelReport.groupNames.Count > 0) {
                StringBuilder sb = new StringBuilder();
                sb.Append("AND  (");
                int coun = 0;
                foreach (String item in customModelReport.groupNames) {
                    coun++;
                    sb.Append("serviceGroup.name = '" + item + "' ");
                    if (coun != customModelReport.groupNames.Count) {
                        sb.Append(" OR ");
                    }

                
                }
                sb.Append(" ) ");
                serviceGroupQrCreator = sb.ToString();
            }


            var result = await _context.HospitalServiceTypeGroupContragentReports.FromSqlRaw("" +
                " SELECT serviceGroup.name as groupnomi, "+
                " count(*) as soni, " +
                " sum(\"PaymentInCash\") as naqt, " +
                " sum(\"PaymentInCard\") as plastik, " +
                " c.\"Name\" as vrachnomi, " +
                " d.\"Name\" as tumannomi, " +
                " sum(serviceType.\"contragentPrice\") as vrachxizmati, " +
                " \"RegistratedDate\"::timestamp::date as vaqti " +
                " FROM districts d, contragents c, payments " +
                " LEFT JOIN \"serviceTypes\" as serviceType ON serviceType.\"Id\" = payments.\"ServiceTypeId\" " +
                " LEFT JOIN \"HospitalServiceTypeGroup\" as serviceGroup ON serviceGroup.\"Id\" = serviceType.\"HospitalServiceTypeGroupId\" " +
                " WHERE payments.\"FinishPayment\" = true and c.\"Id\" = \"ContragentId\" AND  d.\"Id\" = c.\"DistrictsId\"  AND c.\"DistrictsId\" "+ distrctIsStr + " " +
                " AND payments.\"RegistratedDate\" BETWEEN '"+beginDateStr+"'  AND '"+endDateStr+"' " +
                " "+serviceGroupQrCreator+"" +
                " GROUP BY c.\"Name\", serviceGroup.name, \"RegistratedDate\"::timestamp::date, d.\"Name\" " +
                " ORDER BY  c.\"Name\"").ToListAsync();


 
            return result;

        }

        [HttpGet("getRealMoneyCondition")]
        public async Task<ActionResult<IEnumerable<HospitalDailyKassirReport>>> getRealMoneyCondition( [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = endDate.ToString("yyyy-MM-dd hh:mm:ss");
            var result = await _context.HospitalDailyKassirReport.FromSqlRaw(
                " SELECT  sum(\"PaymentInCash\") as naqt, " +
                " sum(\"PaymentInCard\") as plastik, " +
                " (SELECT sum(price) as rasxod " +
                " FROM \"returnMoney\" " +
                " WHERE \"RegistratedDate\" " +
                " between '" + beginDateStr + "' " +
                " and '" + endDateStr + "') " +
                " FROM payments " +
                " WHERE  \"FinishPayment\" = true " +
                " AND \"RegistratedDate\" " +
                " between '" + beginDateStr + "' " +
                " and '" + endDateStr + "'; ").ToListAsync();

            return result;

        }

        [HttpGet("getRealEarnedMoneyByDoctors")]
        public async Task<ActionResult<IEnumerable<HospitalDoctorsEarnedMoneyReport>>> getRealEarnedMoneyByDoctors([FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd");
            String endDateStr = endDate.ToString("yyyy-MM-dd");
            var result = await _context.HospitalDoctorsEarnedMoneyReport.FromSqlRaw("" +
                 " SELECT  pos.\"Name\" as pos_name, "+
                 " u.\"FIO\" as fio," +
                 " sum(p.\"Summ\") as summ, "+
                 " sum(p.\"PaymentInCash\") as cash, "+
                 " sum(p.\"PaymentInCard\") as card, "+
                 " (sum(p.\"PaymentInCash\") + sum(p.\"PaymentInCard\")) as real_summ, "+
                 " (sum(p.\"Summ\") - (sum(p.\"PaymentInCash\") + sum(p.\"PaymentInCard\"))) as dolg_summ"+
                 " FROM  payments p"+
                 " LEFT JOIN authorizations a ON a.\"Id\" = p.\"AuthorizationId\" "+
                 " LEFT JOIN \"Users\" u ON u.\"Id\" = a.\"UsersId\" "+
                 " LEFT JOIN positions pos ON pos.\"Id\" = u.\"PositionId\" "+
                 " WHERE(p.\"Finish\" = true AND p.\"FinishPayment\" = true) "+
                 " AND(p.\"PayedDate\" between '"+ beginDateStr + " 00:00:00' AND '"+ endDateStr + " 23:59:59') "+
                 " GROUP BY u.\"FIO\", pos.\"Name\" " +
                "").ToListAsync();

            return result;

        }


        [HttpGet("getRealServiceListMoneyByDoctors")]
        public async Task<ActionResult<IEnumerable<HospitalDoctorsEarnedMoneyReport>>> getRealServiceListMoneyByDoctors([FromQuery] DateTime beginDate, [FromQuery] DateTime endDate,[FromQuery] long doctor_auth_id)
        {
            String beginDateStr = beginDate.ToString("yyyy-MM-dd");
            String endDateStr = endDate.ToString("yyyy-MM-dd");
            String id_str = "!= 0";
            if (doctor_auth_id != 0) {
                id_str = " = " + doctor_auth_id;
            }
            var result = await _context.HospitalDoctorsEarnedMoneyReport.FromSqlRaw("" +
                   " SELECT sum(p.\"Summ\") as summ, "+
                   " sum(p.\"PaymentInCash\") as cash, " +
                   " sum(p.\"PaymentInCard\") as card, " +
                   " (sum(p.\"PaymentInCash\") + sum(p.\"PaymentInCard\")) as real_summ, " +
                   " (sum(p.\"Summ\") - (sum(p.\"PaymentInCash\") + sum(p.\"PaymentInCard\"))) as dolg_summ, " +
                   " ''::text as fio, " +
                   " p.\"ServiceName\" as pos_name " +
                   " FROM payments p " +
                   " WHERE p.\"AuthorizationId\" "+ id_str + " AND(p.\"Finish\" = true AND p.\"FinishPayment\" = true) " +
                   " AND(p.\"PayedDate\" between '"+ beginDateStr + " 00:00:00' AND '"+ endDateStr + " 23:59:59') " +
                   " GROUP BY p.\"ServiceName\"" +
                "").ToListAsync();

            return result;

        }

        [HttpPost("priminitPaymnetsListAsDoctor")]
        public async Task<ActionResult<IEnumerable<Payments>>> priminitPaymnetsListAsDoctor(List<Payments> paymentsList)
        {
            foreach (Payments item in paymentsList)
            {
                await finishPayedServiceByDoctor(item.Id);
            }

            return paymentsList;
        }

        // GET: api/Payments
        [HttpGet("getAllUnfinishedPaymentsListForAdmin")]
        public async Task<ActionResult<IEnumerable<Payments>>> getAllUnfinishedPaymentsListForAdmin()
        {
            return await _context.payments
                .Where( p => p.Finish != true && p.FinishPayment == true )
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.serviceType)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .Include(p => p.contragent)
                    .ToListAsync();
        }

        [HttpGet("sendMessageToAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> sendMessageToAllUsers([FromQuery] String message_str)
        {
            List<Users> usersList = await _context.Users.Where(p => p.userRegistratedBotId != null).ToListAsync();
            foreach (Users item in usersList) {
                try
                {
                    if (item.userRegistratedBotId <= 0) { continue; }
                    await botClient.SendTextMessageAsync(item.userRegistratedBotId, message_str);
                }
                catch (Exception) { }
            }

            return usersList;
        }

        [HttpGet("sendMessageToAllPatients")]
        public async Task<ActionResult<IEnumerable<Patients>>> sendMessageToAllPatients([FromQuery] String message_str)
        {
            List<Patients> usersList = await _context.Patients.Where(p => p.chatBotId != null).ToListAsync();
            foreach (Patients item in usersList)
            {
                try
                {
                    if (item.chatBotId <= 0) { continue; }
                    await botClient.SendTextMessageAsync(item.chatBotId, message_str);
                }
                catch (Exception) { }
            }

            return usersList;
        }

        [HttpGet("sendMessageToAllContragents")]
        public async Task<ActionResult<IEnumerable<Contragent>>> sendMessageToAllContragents([FromQuery] String message_str)
        {
            List<Contragent> usersList = await _context.contragents.Where(p => p.chatBotId != null).ToListAsync();
            foreach (Contragent item in usersList)
            {
                try {
                    if (item.chatBotId <=0) { continue; }
                    await botClient.SendTextMessageAsync(item.chatBotId, message_str);
                }
                catch (Exception) { }
                
            }

            return usersList;
        }



        [HttpGet("getAllUnfinishedPaymentsListForKassir")]
        public async Task<ActionResult<IEnumerable<Payments>>> getAllUnfinishedPaymentsListForKassir([FromQuery] long creatorAuthId)
        {
            return await _context.payments
                .Where(p => p.Finish != true && p.FinishPayment == true && p.creatorAuthId == creatorAuthId)
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.serviceType)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .Include(p => p.contragent)
                    .ToListAsync();
        }


        [HttpGet("getReturnAlreadyPaidMoneyToBackClient")]
        public async Task<ActionResult<Payments>> getReturnAlreadyPaidMoneyToBackClient([FromQuery]long paymentId,[FromQuery] long deletorAuthId)
        {
            var payments = await _context.payments.FindAsync(paymentId);
            //check for null
            if (payments == null){
                return NotFound();
            }

            //Checked finished payment
            if (payments.Finish  == true ) {
                return NotFound();
            }

            if (payments.FinishPayment != true) {
                return NotFound();
            }

            //DELETE 
            String serviceTypeName = "";
            String serviceTypeGroupName = "";
            String serviceContragentName = "";
            String patientName = "";

            ServiceType serviceType = await _context.serviceTypes.FindAsync(payments.ServiceTypeId);
            if (serviceType != null) {
                serviceTypeName = serviceType.Name;
                HospitalServiceTypeGroup serviceTypeGroup = await _context.HospitalServiceTypeGroup.FindAsync(serviceType.HospitalServiceTypeGroupId);
                if (serviceTypeGroup != null) {
                    serviceTypeGroupName = serviceTypeGroup.name;
                }
            }

            Patients patients = await _context.Patients.FindAsync(payments.PatientsId);
            if (patients != null) {
                patientName = patients.FIO;
            }

            Contragent contragent = await _context.contragents.FindAsync(payments.ContragentId);
            if (contragent != null) {
                serviceContragentName = contragent.Name;
            }

            VozvratAlreadyPaidPaymentList vozvrat = new VozvratAlreadyPaidPaymentList();
            vozvrat.ActiveStatus = true;
            vozvrat.dateTime = DateTime.Now;
            vozvrat.summa = payments.PaymentInCard + payments.PaymentInCash;
            vozvrat.paymentCreatorId = payments.creatorAuthId;
            vozvrat.paymentDeletorId = deletorAuthId;
            vozvrat.SerivceTypeName = serviceTypeName;
            vozvrat.ServiceGroupName = serviceTypeGroupName;
            vozvrat.contragentName = serviceContragentName;
            vozvrat.patientName = patientName;
            _context.VozvratAlreadyPaidPaymentList.Update(vozvrat);
            await _context.SaveChangesAsync();


            List<HospitalManagerReport> managerReports = await _context.HospitalManagerReport.Where(p => p.createdDateTime >= DateTime.Now.Date && p.HospitalServiceTypeGroupName == "VOZVRAT" && p.AuthorizationId == deletorAuthId).ToListAsync();
            if (managerReports != null && managerReports.Count > 0)
            {
                HospitalManagerReport hospitalManagerReport = managerReports.First();
                hospitalManagerReport.cashSumm = hospitalManagerReport.cashSumm + vozvrat.summa;
                hospitalManagerReport.count = hospitalManagerReport.count + 1;
                _context.HospitalManagerReport.Update(hospitalManagerReport);
                await _context.SaveChangesAsync();
            }
            else
            {
                HospitalManagerReport hospitalManagerItem = new HospitalManagerReport();
                hospitalManagerItem.ActiveStatus = true;
                hospitalManagerItem.cashSumm = vozvrat.summa;
                hospitalManagerItem.cardSumm = 0;
                hospitalManagerItem.status = 2;
                hospitalManagerItem.count = 1;
                hospitalManagerItem.createdDateTime = DateTime.Now;
                hospitalManagerItem.AuthorizationId = deletorAuthId;
                hospitalManagerItem.HospitalServiceTypeGroupName = "VOZVRAT";
                _context.HospitalManagerReport.Update(hospitalManagerItem);
                await _context.SaveChangesAsync();

            }
            _context.payments.Remove(payments);
            await _context.SaveChangesAsync();

            return payments;
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetPayments(long id)
        {
            var payments = await _context.payments.FindAsync(id);

            if (payments == null)
            {
                return NotFound();
            }

            return payments;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayments(long id, Payments payments)
        {
            if (id != payments.Id)
            {
                return BadRequest();
            }

            _context.Entry(payments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Payments>> PostPayments(Payments payments)
        {

            _context.payments.Update(payments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayments", new { id = payments.Id }, payments);
        }

        [HttpGet("payPaymentsAllCardOrCash")]
        public async Task<ActionResult<IEnumerable<Payments>>> payPayments([FromQuery] long PatientId, [FromQuery] bool Card)
        {
            List<Payments> paymentList = new List<Payments>();
            try
            {
                paymentList = await _context.payments.Where(p => p.FinishPayment == false && p.PatientsId == PatientId).ToListAsync();

                foreach (Payments item in paymentList) {
                    item.ReserveSumm = item.Summ;
                    item.FinishPayment = true;
                    item.PayedDate = DateTime.Now;
                    if (Card == true)
                    {
                        item.PaymentInCard = item.Summ;
                        item.PaymentInCash = 0;
                    }
                    else {
                        item.PaymentInCash = item.Summ;
                        item.PaymentInCard = 0;
                    }

                }
                _context.payments.UpdateRange(paymentList);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
            return paymentList;
        }

        [HttpGet("payPaymentsAllCardAndCashAndDolg")]
        public async Task<ActionResult<IEnumerable<Payments>>> payPaymentsAllCardAndCashAndDolg([FromQuery] long PatientId, [FromQuery] long card_summ, [FromQuery] long cash_sum,[FromQuery] long dolg_sum)
        {
            List<Payments> paymentList = new List<Payments>();
            try
            {
                if (dolg_sum > 0) {
                    List<HospitalDefaultSettings> defaultSettingList = await _context.HospitalDefaultSettings.ToListAsync();
                    if (defaultSettingList == null || defaultSettingList.Count == 0) {
                        return NotFound("Настройки не найдены");
                    }

                    HospitalDefaultSettings hospitalDefaultSettings = defaultSettingList.First();

                    List<HospitalPatientDolg> dolgList = await _context.HospitalPatientDolg.Where(p => p.PatientsId == PatientId).ToListAsync();
                    if (dolgList == null || dolgList.Count == 0) {
                        HospitalPatientDolg dolg = new HospitalPatientDolg();
                        dolg.active_status = true;
                        dolg.PatientsId = PatientId;
                        dolg.qty = dolg_sum;
                        dolg.real_qty = dolg_sum;
                        _context.HospitalPatientDolg.Update(dolg);
                        await _context.SaveChangesAsync();

                        HospitalPatientDolgItem item_dolg = new HospitalPatientDolgItem();
                        item_dolg.active_status = true;
                        item_dolg.PatientsId = PatientId;
                        item_dolg.qty = dolg_sum;
                        item_dolg.real_qty = dolg_sum;
                        item_dolg.HospitalPatientDolgid = dolg.id;
                        _context.HospitalPatientDolgItem.Update(item_dolg);
                        await _context.SaveChangesAsync();
                    }
                    else {
                        dolgList.First().qty = dolgList.First().qty + dolg_sum;
                        dolgList.First().real_qty = dolgList.First().real_qty + dolg_sum;
                        dolgList.First().created_date_time = DateTime.Now;

                        _context.HospitalPatientDolg.Update(dolgList.First());
                        await _context.SaveChangesAsync();

                        HospitalPatientDolgItem item_dolg = new HospitalPatientDolgItem();
                        item_dolg.active_status = true;
                        item_dolg.PatientsId = PatientId;
                        item_dolg.qty = dolg_sum;
                        item_dolg.real_qty = dolg_sum;
                        item_dolg.HospitalPatientDolgid = dolgList.First().id;
                        _context.HospitalPatientDolgItem.Update(item_dolg);
                        await _context.SaveChangesAsync();

                    }
                }



                paymentList = await _context.payments.Where(p => p.FinishPayment == false && p.PatientsId == PatientId).ToListAsync();
                long all_summ = card_summ + cash_sum + dolg_sum;

                foreach (Payments item in paymentList)
                {
                    all_summ = all_summ - item.Summ;
                }

                //
                if (all_summ != 0) {
                    return NotFound("Сумма не равна");
                }


                foreach (Payments item in paymentList)
                {
                    item.ReserveSumm = item.Summ;
                    item.FinishPayment = true;
                    item.PayedDate = DateTime.Now;
                    if (card_summ > 0) {
                        if (card_summ > item.Summ)
                        {
                            item.PaymentInCard = item.Summ;
                            item.PaymentInCash = 0;
                            card_summ = card_summ - item.Summ;
                        }
                        else {
                            item.PaymentInCard = card_summ;
                            item.PaymentInCash = 0;
                            
                            if (cash_sum > 0) {
                                if (cash_sum > (item.Summ - card_summ))
                                {
                                    item.PaymentInCash = item.Summ - card_summ;
                                    cash_sum = cash_sum - (item.Summ - card_summ);
                                }
                                else {
                                    
                                    item.PaymentInCash = cash_sum;
                                    cash_sum = 0;
                                }

                            }
                            card_summ = 0;


                        }


                    } else if (cash_sum > 0) {

                        if (cash_sum > item.Summ)
                        {
                            item.PaymentInCash = item.Summ;
                            item.PaymentInCard = 0;
                            cash_sum = cash_sum - item.Summ;
                        }
                        else
                        {
                            item.PaymentInCash = cash_sum;
                            item.PaymentInCard = 0;

                            if (card_summ > 0)
                            {
                                if (card_summ > (item.Summ - cash_sum))
                                {
                                    item.PaymentInCard = item.Summ - cash_sum;
                                    card_summ = card_summ - (item.Summ - cash_sum);
                                }
                                else
                                {

                                    item.PaymentInCard = card_summ;
                                    card_summ = 0;
                                }

                            }
                            cash_sum = 0;


                        }

                    }

                }


                _context.payments.UpdateRange(paymentList);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
            return paymentList;
        }
        [HttpPost("addPayments")]
        public async Task<ActionResult<IEnumerable<Payments>>> addPayments(List<Payments> paymentsList)
        {
            foreach (Payments item in paymentsList) {
                item.ActiveStatus = true;
                item.Finish = false;
                item.PaymentInCard = 0;
                item.PaymentInCash = 0;
                item.ReserveSumm = 0;
                item.RegistratedDate = DateTime.Now;
                item.PayedDate = DateTime.Now;
                item.FinishPayment = false;
            }
            _context.payments.AddRange(paymentsList);
            await _context.SaveChangesAsync();

            HospitalCheckPatient checkPatient = new HospitalCheckPatient();
            checkPatient.active_status = true;
            checkPatient.summ = 0;
            List<long> payment_ids = new List<long>();
            foreach (Payments item in paymentsList)
            {
                checkPatient.summ = checkPatient.summ + item.Summ;
                checkPatient.PatientsId = item.PatientsId;
                checkPatient.auth_id = item.AuthorizationId;
                payment_ids.Add(item.Id);
            }
            checkPatient.payments_ids_list = payment_ids;
            _context.HospitalCheckPatient.UpdateRange(checkPatient);
            await _context.SaveChangesAsync();


            return paymentsList;
        }


        [HttpPost("finishPaymentsAllFromDoktr")]
        public async Task<ActionResult<IEnumerable<Payments>>> finishPaymentsAllFromDoktr(List<Payments> paymentsList)
        {
            foreach (Payments item in paymentsList)
            {
                await finishPayedServiceByDoctor(item.Id);
            }

            return paymentsList;
        }

        [HttpGet("getUnpaidPatientList")]
        public async Task<ActionResult<IEnumerable<Patients>>> getUnpaidPatientList()
        {
            List<Patients> patientsList = new List<Patients>();
            List<Payments> paymentList = new List<Payments>();
            try
            {
                paymentList = await _context.payments.Where(p => p.FinishPayment == false).OrderBy(p => p.Id).ToListAsync();
                List<long> patientIdList = new List<long>();
                foreach (Payments payment in paymentList)
                {
                    patientIdList.Add(payment.PatientsId);
                }
                List<long> uniqPatientIdList = patientIdList.Distinct().ToList();
                patientsList = await _context.Patients.Where(p => uniqPatientIdList.Any(id => id == p.Id)).ToListAsync();
            }
            catch (Exception)
            {
            }

            return patientsList;
        }

        [HttpGet("getDoctorPatientsListByAuthId")]
        public async Task<ActionResult<IEnumerable<Patients>>> getDoctorPatientList([FromQuery] long AuthId)
        {
            List<Patients> patientsList = new List<Patients>();
            List<Payments> paymentList = new List<Payments>();
            try
            {
                paymentList = await _context.payments.Where(p => p.Finish == false && p.AuthorizationId == AuthId).OrderByDescending(p => p.RegistratedDate).ToListAsync();
                List<long> patientIdList = new List<long>();
                foreach (Payments payment in paymentList)
                {
                    patientIdList.Add(payment.PatientsId);
                }
                List<long> uniqPatientIdList = patientIdList.Distinct().ToList();
                patientsList = await _context.Patients.Where(p => uniqPatientIdList.Any(id => id == p.Id)).ToListAsync();
            }
            catch (Exception)
            {
            }

            return patientsList;
        }


        [HttpGet("getPatientPayedByAuthIdList")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPatientPayedByUserIdList([FromQuery] long AuthId)
        {
            List<Payments> paymentList = new List<Payments>();
            try {
                paymentList = await _context.payments.Where(p => p.AuthorizationId == AuthId && p.Finish == false).OrderBy(p => p.Id).ToListAsync();
            }
            catch (Exception) { 
            }
            return paymentList;
        }



        [HttpGet("getPatientPayedServiceByPatientIdList")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPatientPayedServiceByPatientIdList([FromQuery] long PatientId)
        {
            List<Payments> paymentList = new List<Payments>();
            try
            {
                paymentList = await _context.payments.Where(p => p.PatientsId == PatientId && p.Finish == false).Include( p=>p.serviceType).ThenInclude( p => p.hospitalServiceTypeGroup).OrderBy(p => p.Id).ToListAsync();
            }
            catch (Exception)
            {

            }

            return paymentList;
        }

        [HttpGet("getPatientPayedServiceByPatientIdListByDoctrAuthId")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPatientPayedServiceByPatientIdListByDoctrAuthId([FromQuery] long PatientId,[FromQuery] long doctirAuthId)
        {
            List<Payments> paymentList = new List<Payments>();
            try
            {
                paymentList = await _context.payments.Where(p => p.PatientsId == PatientId && p.Finish == false && p.AuthorizationId == doctirAuthId).Include(p => p.serviceType).ThenInclude(p => p.hospitalServiceTypeGroup).OrderBy(p => p.Id).ToListAsync();
            }
            catch (Exception)
            {

            }

            if (paymentList != null && paymentList.Count > 0) {
                List<Payments> clearedPaymentsList = new List<Payments>();
                foreach (Payments item in paymentList) {
                    ServiceType serviceType = await _context.serviceTypes.FindAsync(item.ServiceTypeId);
                    if (serviceType != null) {
                        List<HospitalServiceTypeByGroupPermission> groupPermissionList = await _context.HospitalServiceTypeByGroupPermission.Where(p => p.HospitalServiceTypeGroupId == serviceType.HospitalServiceTypeGroupId).ToListAsync();
                        if (groupPermissionList != null && groupPermissionList.Count > 0)
                        {
                            //bu doktrda korinmeydigon ekan korsatmiymiz logika uchun qldirdim
                        }
                        else {
                            clearedPaymentsList.Add(item);
                        }
                    }

                }

                return clearedPaymentsList;
            }
            


            return paymentList;
        }

        [HttpGet("getPatientPayedServiceByPatientIdListForPayment")]
        public async Task<ActionResult<IEnumerable<Payments>>> getPatientPayedServiceByPatientIdListForPayment([FromQuery] long PatientId)
        {
            List<Payments> paymentList = new List<Payments>();
            try
            {
                paymentList = await _context.payments.Where(p => p.PatientsId == PatientId && p.FinishPayment == false).OrderBy(p => p.Id).ToListAsync();
            }
            catch (Exception)
            {
            }
            return paymentList;
        }

        [HttpGet("finishPayedServiceByDoctor")]
        public async Task<ActionResult<Payments>> finishPayedServiceByDoctor([FromQuery]long paymentId)
        {
            Payments payments = await _context.payments.FindAsync(paymentId);
            if (payments == null){
                return NotFound();
            }
            payments.Finish = true;
            _context.payments.Update(payments);
            await _context.SaveChangesAsync();

            ///MRT MSKT XIZMAT TURLARINI QOSHISH
            {

                List<HospitalContragentDebitPaymentReport> hospitalContragentDebitsList = new List<HospitalContragentDebitPaymentReport>();
                ServiceType serviceType_n = await _context.serviceTypes.FindAsync(payments.ServiceTypeId);
                if (serviceType_n != null || serviceType_n.paymentable == true)
                {
                  
                HospitalContragentDebitPaymentReport paymentReportContragent = new HospitalContragentDebitPaymentReport();
                paymentReportContragent.ActiveStatus = true;
                Contragent contragent = await _context.contragents.FindAsync(payments.ContragentId);
                paymentReportContragent.contragent = contragent;
                paymentReportContragent.contragentId = payments.ContragentId;
                paymentReportContragent.paymentPayedStatus = false;
                Districts districts = await _context.districts.FindAsync(contragent.DistrictsId);
                paymentReportContragent.regionName = districts.Name;
                paymentReportContragent.createdDate = payments.RegistratedDate;
                paymentReportContragent.contragentAddress = contragent.Address;
                paymentReportContragent.contragentPhoneNumber = contragent.PhoneNumber;
                paymentReportContragent.serviceTypeName = serviceType_n.Name;
                paymentReportContragent.districtsId = contragent.DistrictsId ?? default(long);
                HospitalServiceTypeGroup hospitalServiceType = await _context.HospitalServiceTypeGroup.FindAsync(serviceType_n.HospitalServiceTypeGroupId);
                paymentReportContragent.serviceGroupName = hospitalServiceType.name;
                double contragentPriceSel = serviceType_n.contragentPrice;
                //check additional bonus exit or not 
                List<ContragentServiceTypeBonusAdditanaly> bonusAdditanalyList = await _context.ContragentServiceTypeBonusAdditanaly.Where(p => p.ContragentId == payments.ContragentId && p.ServiceTypeId == payments.ServiceTypeId).ToListAsync();
                if (bonusAdditanalyList != null && bonusAdditanalyList.Count > 0)
                {
                    ContragentServiceTypeBonusAdditanaly bonusAdditanaly = bonusAdditanalyList.First();
                    if (bonusAdditanaly != null)
                    {
                        contragentPriceSel = contragentPriceSel + bonusAdditanaly.bonusSumm;
                    }
                }
                paymentReportContragent.summa = contragentPriceSel;
                paymentReportContragent.contragentName = contragent.Name;
                hospitalContragentDebitsList.Add(paymentReportContragent);
                if (hospitalContragentDebitsList.Count > 0)
                {
                    _context.HospitalContragentDebitPaymentReport.AddRange(hospitalContragentDebitsList);
                    await _context.SaveChangesAsync();

                }

            }
            }

            //hospital manager report functions
            {
                //calculated manager report
                
                ServiceType serviceType_l = await _context.serviceTypes.FindAsync(payments.ServiceTypeId);
                if (serviceType_l != null)
                {
                    HospitalServiceTypeGroup hospitalServiceTypeGroup = await _context.HospitalServiceTypeGroup.FindAsync(serviceType_l.HospitalServiceTypeGroupId);
                    if (hospitalServiceTypeGroup != null)
                    {


                        //add to hospital manager report
                        List<HospitalManagerReport> managerReports = await _context.HospitalManagerReport.Where(p => p.createdDateTime >= payments.RegistratedDate.Date && p.createdDateTime <= payments.RegistratedDate.Date.AddHours(23.9999) &&  p.HospitalServiceTypeGroupName == hospitalServiceTypeGroup.name && p.AuthorizationId == payments.creatorAuthId).ToListAsync();
                        if (managerReports != null && managerReports.Count > 0)
                        {
                                HospitalManagerReport hospitalManagerReport = managerReports.First();
                                hospitalManagerReport.cardSumm = hospitalManagerReport.cardSumm + payments.PaymentInCard;
                                hospitalManagerReport.cashSumm = hospitalManagerReport.cashSumm + payments.PaymentInCash;
                            
                             hospitalManagerReport.count = hospitalManagerReport.count + 1;
                            _context.HospitalManagerReport.Update(hospitalManagerReport);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            HospitalManagerReport hospitalManagerItem = new HospitalManagerReport();
                            hospitalManagerItem.ActiveStatus = true;
                            hospitalManagerItem.cardSumm = payments.PaymentInCard;
                            hospitalManagerItem.cashSumm = payments.PaymentInCash;
                            hospitalManagerItem.status = 0;
                            hospitalManagerItem.count = 1;
                            hospitalManagerItem.createdDateTime = payments.RegistratedDate;
                            hospitalManagerItem.AuthorizationId = payments.creatorAuthId.GetValueOrDefault();
                            hospitalManagerItem.HospitalServiceTypeGroupName = hospitalServiceTypeGroup.name;
                            _context.HospitalManagerReport.Update(hospitalManagerItem);
                            await _context.SaveChangesAsync();

                        }
                    }

                }

            }


            /*tovardan ayrish kerak dorilardi*/
            ServiceType serviceType = await _context.serviceTypes.FindAsync(payments.ServiceTypeId);
            if (serviceType != null) {
                List<HospitalServiceRecipe> hospitalServiceRecipeList = await _context.HospitalServiceRecipe.Where(p => p.ServiceTypeId == payments.ServiceTypeId).ToListAsync();
                if (hospitalServiceRecipeList != null && hospitalServiceRecipeList.Count > 0) {
                    foreach (HospitalServiceRecipe item in hospitalServiceRecipeList) {
                        long marketProductId = item.MarketProductId;
                        double qtyProduct = item.qty;
                        List<MarketProductRealQty> marketProductRealQties = await _context.MarketProductRealQty.Where(p => p.MarketProductId == marketProductId).ToListAsync();
                        if (marketProductRealQties != null && marketProductRealQties.Count > 0) {
                            foreach (MarketProductRealQty itm in marketProductRealQties)
                            {
                                itm.realQty = itm.qty - qtyProduct;
                                itm.qty = itm.qty - qtyProduct;
                                try {
                                    _context.MarketProductRealQty.Update(itm);
                                    await _context.SaveChangesAsync();
                                }
                                catch (Exception ) { }
                            }
                        }

                    }
                }

                /*SEND TO CONTRAGENT OVER TELEEGRAM*/
                try
                {
                    
                    if (serviceType.paymentable == true) {
                        long contrAgentId = payments.ContragentId;
                        Contragent contragentSel = await _context.contragents.FindAsync(contrAgentId);
                        if (contragentSel != null) {
                            long serviceTypeGroupId = serviceType.HospitalServiceTypeGroupId;
                            HospitalServiceTypeGroup hospitalServiceType = await _context.HospitalServiceTypeGroup.FindAsync(serviceTypeGroupId);
                            if (hospitalServiceType != null) {
                                Patients patientSel = await _context.Patients.FindAsync(payments.PatientsId);
                                if (patientSel != null) {

                                    double contragentPriceSel = serviceType.contragentPrice;
                                    //check additional bonus exit or not 
                                    List<ContragentServiceTypeBonusAdditanaly> bonusAdditanalyList = await _context.ContragentServiceTypeBonusAdditanaly.Where(p => p.ContragentId == payments.ContragentId && p.ServiceTypeId == payments.ServiceTypeId).ToListAsync();
                                    if (bonusAdditanalyList != null && bonusAdditanalyList.Count > 0)
                                    {
                                        ContragentServiceTypeBonusAdditanaly bonusAdditanaly = bonusAdditanalyList.SingleOrDefault();
                                        if (bonusAdditanaly != null)
                                        {
                                            contragentPriceSel = contragentPriceSel + bonusAdditanaly.bonusSumm;
                                        }
                                    }

                                    List<ContragentAdditionalPaymentBefohandFullInfo> befohandFullInfos = await _context.ContragentAdditionalPaymentBefohandFullInfo.Where(p => p.ContragentId == payments.ContragentId).ToListAsync();
                                    if (befohandFullInfos != null && befohandFullInfos.Count > 0) {
                                        ContragentAdditionalPaymentBefohandFullInfo contragentAdditionalPayment = befohandFullInfos.SingleOrDefault();
                                        if (contragentAdditionalPayment != null) {
                                            double minusQtyFromBeforeHand = 0;
                                                minusQtyFromBeforeHand = contragentPriceSel;
                                            //update real summa from contragent summa
                                            contragentAdditionalPayment.realQty = contragentAdditionalPayment.realQty - minusQtyFromBeforeHand;
                                             _context.ContragentAdditionalPaymentBefohandFullInfo.Update(contragentAdditionalPayment);
                                             await _context.SaveChangesAsync();
                                              ContragentAdditionalPaymentBefohandDetail befohandDetail = new ContragentAdditionalPaymentBefohandDetail();
                                              befohandDetail.ActiveStatus = true;
                                              befohandDetail.ContragentId = payments.ContragentId;
                                              befohandDetail.ServiceTypeId = payments.ServiceTypeId;
                                              befohandDetail.limitSummLeft = contragentAdditionalPayment.realQty;
                                              befohandDetail.summa = minusQtyFromBeforeHand;
                                              befohandDetail.createdDateTime = payments.RegistratedDate;
                                              befohandDetail.PatientsId = payments.PatientsId;
                                             _context.ContragentAdditionalPaymentBefohandDetail.Update(befohandDetail);
                                              await _context.SaveChangesAsync();
                                        }
                  

                                    }

                                    if (contragentSel.chatBotId != null)
                                    {
                                        //String messageStrTelegramm = "Yo'llanma bo'yicha: Jo'natuvchi: " + contragentSel.Name + "  Bemor: " + patientSel.FIO + " Ko'rsatilgan xizmat turi:" + serviceType.Name + "  Tel: " + (patientSel.PhoneNumber != null ? patientSel.PhoneNumber : "") + "  " + " Sana: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                                        String messageStrTelegramm = "Yo'llanma bo'yicha: Jo'natuvchi: " + contragentSel.Name + "  Bemor: " + patientSel.FIO + " Ko'rsatilgan xizmat turi:" + serviceType.Name  + "  " + " Sana: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                                        Console.WriteLine(messageStrTelegramm + "SMS BOT ID BOR");
                                        await botClient.SendTextMessageAsync(contragentSel.chatBotId, messageStrTelegramm);
                                    }
                                    else {
                                        Console.WriteLine("SMS BOT ID YOQ");
                                    }

                                }
                            }
                        }

                    }
                }
                catch (Exception) { }
                /**/

            }

            return payments;
        }

        [HttpGet("payPaymentOneDividedAsCashAndCardFullPaymentOnly")]
        public async Task<ActionResult<Payments>> payPaymentOneDividedAsCashAndCardFullPaymentOnly([FromQuery] long paymentId, [FromQuery] long cashSumm, [FromQuery] long cardSumm)
        {
            Payments payments = await _context.payments.FindAsync(paymentId);
            if (payments == null)
            {
                return NotFound();
            }
            if (payments.Summ != (cardSumm+cashSumm)) {
                return NotFound();
            }
            payments.FinishPayment = true;
            payments.ReserveSumm = payments.Summ;
            payments.PaymentInCard = cardSumm;
            payments.PaymentInCash = cashSumm;
            payments.PayedDate = DateTime.Now;
            _context.payments.Update(payments);
            await _context.SaveChangesAsync();

          /*  ServiceType serviceType = await _context.serviceTypes.FindAsync(payments.ServiceTypeId);
            if (serviceType == null) {
                return payments;
            }

            HospitalServiceTypeGroup hospitalServiceTypeGroup = await _context.HospitalServiceTypeGroup.FindAsync(serviceType.HospitalServiceTypeGroupId);
            if (hospitalServiceTypeGroup == null)
            {
                return payments;
            }

            //add to hospital manager report
            List<HospitalManagerReport> managerReports = await _context.HospitalManagerReport.Where(p => p.createdDateTime >= DateTime.Now.Date && p.HospitalServiceTypeGroupName == hospitalServiceTypeGroup.name && p.AuthorizationId == payments.creatorAuthId).ToListAsync();
            if (managerReports != null && managerReports.Count > 0)
            {
                HospitalManagerReport hospitalManagerReport = managerReports.First();
                hospitalManagerReport.cashSumm = hospitalManagerReport.cashSumm + cashSumm;
                hospitalManagerReport.cardSumm = hospitalManagerReport.cardSumm + cardSumm;
                hospitalManagerReport.count = hospitalManagerReport.count + 1;
                _context.HospitalManagerReport.Update(hospitalManagerReport);
                await _context.SaveChangesAsync();
            }
            else
            {
                HospitalManagerReport hospitalManagerItem = new HospitalManagerReport();
                hospitalManagerItem.ActiveStatus = true;
                hospitalManagerItem.cashSumm = cashSumm;
                hospitalManagerItem.cardSumm = cardSumm;
                hospitalManagerItem.status = 0;
                hospitalManagerItem.count =  1;
                hospitalManagerItem.createdDateTime = DateTime.Now;
                hospitalManagerItem.AuthorizationId = payments.creatorAuthId.GetValueOrDefault();
                hospitalManagerItem.HospitalServiceTypeGroupName = hospitalServiceTypeGroup.name;
                _context.HospitalManagerReport.Update(hospitalManagerItem);
                await _context.SaveChangesAsync();

            }

            */

            return payments;
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payments>> DeletePayments(long id)
        {
            var payments = await _context.payments.FindAsync(id);
            if (payments == null){
                return NotFound();
            }

            List<HospitalManagerReport> managerReports = await _context.HospitalManagerReport.Where(p => p.createdDateTime >= DateTime.Now.Date && p.HospitalServiceTypeGroupName == "REJECTED" && p.AuthorizationId == payments.creatorAuthId).ToListAsync();
            if (managerReports != null && managerReports.Count > 0)
            {
                HospitalManagerReport hospitalManagerReport = managerReports.First();
                hospitalManagerReport.cashSumm = hospitalManagerReport.cashSumm + payments.Summ;
                hospitalManagerReport.count = hospitalManagerReport.count + 1;
                _context.HospitalManagerReport.Update(hospitalManagerReport);
                await _context.SaveChangesAsync();
            }
            else {
                HospitalManagerReport hospitalManagerItem = new HospitalManagerReport();
                hospitalManagerItem.ActiveStatus = true;
                hospitalManagerItem.cashSumm = payments.Summ;
                hospitalManagerItem.cardSumm = 0;
                hospitalManagerItem.status = 1;
                hospitalManagerItem.count = 1;
                hospitalManagerItem.createdDateTime = DateTime.Now;
                hospitalManagerItem.AuthorizationId = payments.creatorAuthId.GetValueOrDefault();
                hospitalManagerItem.HospitalServiceTypeGroupName = "REJECTED";
                _context.HospitalManagerReport.Update(hospitalManagerItem);
                await _context.SaveChangesAsync();

            }


          

            _context.payments.Remove(payments);
            await _context.SaveChangesAsync();
            return payments;
        }

        private bool PaymentsExists(long id)
        {
            return _context.payments.Any(e => e.Id == id);
        }
    }
}
