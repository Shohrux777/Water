using ApiAll.Model;
using ApiAll.Model.settingsmodel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAll.Model.market;
using ApiAll.Model.tekistil;
using ApiAll.Model.skud;
using ApiAll.Model.pos;
using ApiAll.Model.archive;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.hospital;
using ApiAll.Model.hospital.dolg;
using ApiAll.Model.hospital.telegram_bot;
using ApiAll.Model.hospital.reports;
using ApiAll.Model.tegirmon;
using ApiAll.Model.oquv_markaz;
using ApiAll.Controllers.oquv_markaz;
using ApiAll.Controllers.tegirmon;
using ApiAll.Model.hospital.bron;
using ApiAll.Model.water;
using ApiAll.Model.tekistil.raskladki;
using ApiAll.Model.tekistil.planning;
using ApiAll.Model.tekistil.seworder;
using ApiAll.Model.tekistil.sewextrawork;
using ApiAll.Model.tekistil.access;
using ApiAll.Model.tekistil.order_item_steps;
using ApiAll.Model.parking;
using ApiAll.Model.hospital.analiz.analiz_unversal;
using ApiAll.Model.hotel;
using ApiAll.Model.hospital.bron_new;

namespace ApiAll.Contex
{
    public class ApplicationContext : DbContext
    {



        

        public DbSet<WaterMoneyFakeInfo> WaterMoneyFakeInfo { get; set; }
        public DbSet<WaterStatistikaFakeReport> WaterStatistikaFakeReport { get; set; }
        public DbSet<WaterStatistikaFakeReport2> WaterStatistikaFakeReport2 { get; set; }
        public DbSet<WaterCheckFakeModel> WaterCheckFakeModel { get; set; }
        public DbSet<WaterClientAddress> WaterClientAddress { get; set; }
        public DbSet<WaterClientPhoneNumber> WaterClientPhoneNumber { get; set; }
        public DbSet<WaterMessageLog> WaterMessageLog { get; set; }
        public DbSet<WaterOrderedProduct> WaterOrderedProduct { get; set; }

        public DbSet<HospitalOchredByDocotors> HospitalOchredByDocotors { get; set; }
        public DbSet<OquvMarkazGruppagaTolov> OquvMarkazGruppagaTolov { get; set; }
        public DbSet<TegirmonMoneyInfoTemp> TegirmonMoneyInfoTemp { get; set; }
        public DbSet<OquvMarkazKassaCurrentCondition> OquvMarkazKassaCurrentCondition { get; set; }
        public DbSet<OquvMarkazYoqlama> OquvMarkazYoqlama { get; set; }

        public DbSet<HospitalBedsTypeAndPrice> HospitalBedsTypeAndPrice { get; set; }

        public DbSet<HospitalBedsBronPaymnetsInfo> HospitalBedsBronPaymnetsInfo { get; set; }

        public DbSet<OquvMarkazTest> OquvMarkazTest { get; set; }
        public DbSet<OquvMarkazClientType> OquvMarkazClientType { get; set; }
        public DbSet<OquvMarkazContragent> OquvMarkazContragent { get; set; }
        public DbSet<OquvMarkazTestResult> OquvMarkazTestResult { get; set; }

        public DbSet<CustomContragentReport> customContragentReports { get; set; }

        public DbSet<OquvMarkazPupilGroupDetailInfo> OquvMarkazPupilGroupDetailInfo { get; set; }
        public DbSet<OquvMarkazTeachersBonusItem> OquvMarkazTeachersBonusItem { get; set; }
        public DbSet<OquvMarkazTeachersBonus> OquvMarkazTeachersBonus { get; set; }
        public DbSet<OquvMarkazOstatkaRasxodInfo> OquvMarkazOstatkaRasxodInfo { get; set; }
        public DbSet<PosRealSummOfAllProducts> PosRealSummOfAllProducts { get; set; }
        public DbSet<PosKassaCurrentPosition> PosKassaCurrentPosition { get; set; }
        public DbSet<PosKassirInfo> PosKassirInfo { get; set; }
        public DbSet<PosSaledProductsDegreeQty> PosSaledProductsDegreeQty { get; set; }
        public DbSet<PosKassaCurrentPositionWithName> PosKassaCurrentPositionWithName { get; set; }
        public DbSet<HospitalCovidExpress> HospitalCovidExpress { get; set; }

        public DbSet<HospitalPatientDolgItem> HospitalPatientDolgItem { get; set; }

        public DbSet<HospitalPaymentsReportFakeModel> HospitalPaymentsReportFakeModel { get; set; }
        public DbSet<HospitalDoctorsEarnedMoneyReport> HospitalDoctorsEarnedMoneyReport { get; set; }
        public DbSet<TegirmonClientOstatakaSumInfo> TegirmonClientOstatakaSumInfo { get; set; }

        

        public DbSet<TexOrderItemSteps> TexOrderItemSteps { get; set; }
        public DbSet<SkudPictureCheckinout> SkudPictureCheckinout { get; set; }
        public DbSet<MarketProductPrice> MarketProductPrice { get; set; }
        public DbSet<SkudTablename> SkudTablename { get; set; }
        public DbSet<SkudSmena> SkudSmena { get; set; }
        public DbSet<SkudSababli> SkudSababli { get; set; }
        public DbSet<SkudResultGr> SkudResultGr { get; set; }
        public DbSet<SkudPeriod> SkudPeriod { get; set; }
        public DbSet<SkudMyDepartments> SkudMyDepartments { get; set; }
        public DbSet<SkudLk> SkudLk { get; set; }
        public DbSet<SkudMyCheckinout> SkudMyCheckinout { get; set; }
        public DbSet<SkudImages> SkudImages { get; set; }
        public DbSet<SkudGroupAccess> SkudGroupAccess { get; set; }
        public DbSet<SkudForTrenajor> SkudForTrenajor { get; set; }
        public DbSet<SkudGrForEmp> SkudGrForEmp { get; set; }
        public DbSet<SkudFaces> SkudFaces { get; set; }
        public DbSet<SkudDoorCheckinout> SkudDoorCheckinout { get; set; }
        public DbSet<SkudAccessLevel> SkudAccessLevel { get; set; }
        public DbSet<SkudDoors> SkudDoors { get; set; }
        public DbSet<SkudDevices> SkudDevices { get; set; }
        public DbSet<TexColumnConfigRaw> TexColumnConfigRaw { get; set; }
        public DbSet<TexRealProductRemain> TexRealProductRemains { get; set; }
        public DbSet<MarketProfitCustomReport> MarketProfitCustomReport { get; set; }
        public DbSet<MarketOrderFullOrderedProducts> MarketOrderFullOrderedProducts { get; set; }
        public DbSet<HospitalDailyKassirReport> HospitalDailyKassirReport { get; set; }
        public DbSet<HospitalServiceTypeGroupContragentReports> HospitalServiceTypeGroupContragentReports { get; set; }
        public DbSet<MarketLimitCustomItem> MarketLimitCustomItem { get; set; }
        public DbSet<AnalizBakterioskopiya> analizBakterioskopiyas { get; set; }
        public DbSet<AnalizDemodex> analizDemodices { get; set; }
        public DbSet<AnalizKala> analizKalas { get; set; }
        public DbSet<AnalizLeyshmaniy> analizLeyshmaniys { get; set; }
        public DbSet<AnalizLk> analizLks { get; set; }
        public DbSet<AnalizMachi> analizMachis { get; set; }
        public DbSet<AnalizMikroskopiya> analizMikroskopiyas { get; set; }
        public DbSet<AnalizMuhimbelgilar> analizMuhimbelgilars { get; set; }
        public DbSet<AnalizQontahlili> analizQontahlilis { get; set; }
        public DbSet<AnalizRw> analizRws { get; set; }
        public DbSet<AnalizSarcoptes> analizSarcoptes{get;set;}
        public DbSet<AnalizZamburug> analizZamburugs { get; set; }
        public DbSet<Ilness> ilnesses { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Payments> payments { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Province> provinces { get; set; }
        public DbSet<ReturnMoney> returnMoney { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<ServiceType> serviceTypes { get; set; }
        public DbSet<Authorization> authorizations { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Contragent> contragents { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Districts> districts { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Datchik> datchiks { get; set; }
        public DbSet<DatchikItem> datchikItems { get; set; }
        public DbSet<DatchikRealValues> datchikRealValues { get; set; }
        public DbSet<ArchiveWorkingTime> ArchiveWorkingTime { get; set; }

        public DbSet<Menu> menus { get; set; }
        public DbSet<MenuItem> menuItems { get; set; }
        public DbSet<AccessMenu> accessMenus { get; set; }
        public DbSet<AccessMenuItem> accessMenuItems { get; set; }
        public DbSet<RoomColectionInformations> roomColectionInformations { get; set; }
        public DbSet<PatientType> patientTypes { get; set; }
        public DbSet<WaterSelledProductsTemp> WaterSelledProductsTemp { get; set; }
        public DbSet<PatientServiceType> patientServiceTypes { get; set; }

        public DbSet<ApiAll.Model.Users> Users { get; set; }
        public DbSet<ApiAll.Model.ServiceTypeDetail> ServiceTypeDetail { get; set; }

        public DbSet<ApiAll.Model.PatientRegistrationInfo> patientRegistrationInfos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
               protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
            
            modelBuilder.Entity<WaterMoneyFakeInfo>().HasNoKey();
            modelBuilder.Entity<WaterStatistikaFakeReport2>().HasNoKey();
            modelBuilder.Entity<CustomContragentReport>().HasNoKey();
            modelBuilder.Entity<WaterSelledProductsTemp>().HasNoKey();
            modelBuilder.Entity<TegirmonClientOstatakaSumInfo>().HasNoKey();
                     modelBuilder.Entity<WaterOrderedProduct>().HasNoKey();
                     modelBuilder.Entity<TexRealProductRemain>().HasNoKey();
                     modelBuilder.Entity<MarketOrderFullOrderedProducts>().HasNoKey();
                     modelBuilder.Entity<HospitalDailyKassirReport>().HasNoKey();
                     modelBuilder.Entity<HospitalServiceTypeGroupContragentReports>().HasNoKey();
                     modelBuilder.Entity<MarketLimitCustomItem>().HasNoKey();
                     modelBuilder.Entity<MarketProfitCustomReport>().HasNoKey();
                     modelBuilder.Entity<TexColumnConfigRaw>().HasNoKey();
                     modelBuilder.Entity<SkudAccessLevel>().HasNoKey();
                     modelBuilder.Entity<SkudDevices>().HasNoKey();
                     modelBuilder.Entity<SkudDoors>().HasNoKey();
                     modelBuilder.Entity<SkudFaces>().HasNoKey();
                     modelBuilder.Entity<SkudLk>().HasNoKey();
                     modelBuilder.Entity<SkudPictureCheckinout>().HasNoKey();
                     modelBuilder.Entity<SkudResultGr>().HasNoKey();
                     modelBuilder.Entity<SkudSmena>().HasNoKey();
                     modelBuilder.Entity<ArchiveWorkingTime>().HasNoKey();
                     modelBuilder.Entity<PosRealSummOfAllProducts>().HasNoKey();
                     modelBuilder.Entity<PosKassaCurrentPosition>().HasNoKey();
                     modelBuilder.Entity<PosKassirInfo>().HasNoKey();
                     modelBuilder.Entity<PosSaledProductsDegreeQty>().HasNoKey();
                     modelBuilder.Entity<PosKassaCurrentPositionWithName>().HasNoKey();
                     modelBuilder.Entity<HospitalDoctorsEarnedMoneyReport>().HasNoKey();
                     modelBuilder.Entity<HospitalPaymentsReportFakeModel>().HasNoKey();
                     modelBuilder.Entity<OquvMarkazKassaCurrentCondition>().HasNoKey();
                     modelBuilder.Entity<TegirmonMoneyInfoTemp>().HasNoKey();
                     modelBuilder.Entity<HospitalOchredByDocotors>().HasNoKey();
                     modelBuilder.Entity<WaterCheckFakeModel>().HasNoKey();
                     modelBuilder.Entity<WaterStatistikaFakeReport>().HasNoKey();

            //

            modelBuilder.Entity<TexProduct>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexOrderItemSteps>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexDeviceType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexDevice>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexDevice>().HasIndex(u => u.code).IsUnique();
                     modelBuilder.Entity<TexDevice>().HasIndex(u => u.ip).IsUnique();
                     modelBuilder.Entity<TexUser>().HasIndex(u => u.passport_number).IsUnique();
                     modelBuilder.Entity<SkudMyDepartments>().HasIndex(u => u.deptname).IsUnique();
                     modelBuilder.Entity<SkudLk>().HasIndex(u => u.lkey).IsUnique();
                     modelBuilder.Entity<SkudFaces>().HasIndex(u => u.ip).IsUnique();
                     modelBuilder.Entity<SkudFaces>().HasIndex(u => u.nomi).IsUnique();
                     modelBuilder.Entity<TexUpakovka>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexAuthorization>().HasIndex(u => u.login).IsUnique();
                     modelBuilder.Entity<TexCategory>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexColor>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexColorGroup>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexColorproccess>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexColorvariant>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexColorVariantType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexContragent>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexDepartment>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexDevice>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexExtrawork>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexGuscolor>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexInvoiceType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexSize>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexMainProccess>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexMeasurmentType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexPaymentType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexPlaningType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexPosition>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexProductionType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexServiceType>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexSklad>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexSort>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexTypeProduct>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexUnitmeasurment>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexUpakovka>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexXarakteristika>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<TexXarakteristikaTool>().HasIndex(u => u.name).IsUnique();
                     modelBuilder.Entity<SkudDoors>().HasIndex(u => u.dbname).IsUnique();
                     modelBuilder.Entity<SkudDevices>().HasIndex(u => u.device_name).IsUnique();
                     modelBuilder.Entity<SkudDoorCheckinout>().HasIndex(p => new { p.userid, p.sana,p.checktime }).IsUnique();
                     modelBuilder.Entity<SkudMyCheckinout>().HasIndex(p => new { p.userid, p.sana,p.checktime }).IsUnique();
                     modelBuilder.Entity<TexLanguage>().HasIndex(p => new { p.name, p.user_auth_id }).IsUnique();
                     modelBuilder.Entity<TexOrderItemStepPermissions>().HasIndex(p => new { p.auth_id, p.order_steps_id }).IsUnique();
                     modelBuilder.Entity<TexOrderItemStepsDetail>().HasIndex(p => new { p.sort_number, p.order_item_id }).IsUnique();


            base.OnModelCreating(modelBuilder);
            }
               public DbSet<ApiAll.Model.RoomBooking> RoomBooking { get; set; }
               public DbSet<ApiAll.Model.PaymentRooms> PaymentRooms { get; set; }
               public DbSet<ApiAll.Model.PaymentRoomsItem> PaymentRoomsItem { get; set; }
               public DbSet<ApiAll.Model.PaymentRoomsServiceTypesItem> PaymentRoomsServiceTypesItem { get; set; }
               public DbSet<ApiAll.Model.PaymentRoomsServiceTypesItemInfo> PaymentRoomsServiceTypesItemInfo { get; set; }

               public DbSet<ApiAll.Model.market.MarketAuthLimitByMoney> MarketAuthLimitByMoney { get; set; }
               public DbSet<ApiAll.Model.market.MarketAuthLimitByMoneyDetail> MarketAuthLimitByMoneyDetail { get; set; }
               public DbSet<ApiAll.Model.market.MarketAuthLimitByProduct> MarketAuthLimitByProduct { get; set; }
               public DbSet<ApiAll.Model.market.MarketAuthLimitByProductDetail> MarketAuthLimitByProductDetail { get; set; }
               public DbSet<ApiAll.Model.market.MarketClientInfo> MarketClientInfo { get; set; }
               public DbSet<ApiAll.Model.market.MarketOrder> MarketOrder { get; set; }
               public DbSet<ApiAll.Model.market.MarketOrderDeliveriedInfo> MarketOrderDeliveriedInfo { get; set; }
               public DbSet<ApiAll.Model.market.MarketOrderDetail> MarketOrderDetail { get; set; }
               public DbSet<ApiAll.Model.market.MarketProductGroup> MarketProductGroup { get; set; }
               public DbSet<ApiAll.Model.market.MarketProductGroupDetail> MarketProductGroupDetail { get; set; }
               public DbSet<ApiAll.Model.market.MarketProductRealQty> MarketProductRealQty { get; set; }
               public DbSet<ApiAll.Model.market.MarketProductRealQtyTemp> MarketProductRealQtyTemp { get; set; }
               public DbSet<ApiAll.Model.market.MarketProduct> MarketProduct { get; set; }
               public DbSet<ApiAll.Model.market.MarketUnitMeasurment> MarketUnitMeasurment { get; set; }
               public DbSet<ApiAll.Model.market.MarketInvoice> MarketInvoice { get; set; }
               public DbSet<ApiAll.Model.market.MarketInvoiceItem> MarketInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.market.MarketNeedToPayToAgents> MarketNeedToPayToAgents { get; set; }
               public DbSet<ApiAll.Model.market.MarketNeedToPayToAgentDetail> MarketNeedToPayToAgentDetail { get; set; }

               public DbSet<ApiAll.Model.market.MarketAgent> MarketAgent { get; set; }
               public DbSet<ApiAll.Model.HospitalServiceRecipe> HospitalServiceRecipe { get; set; }
               public DbSet<ApiAll.Model.PatientRecipeByDoctor> PatientRecipeByDoctor { get; set; }
               public DbSet<ApiAll.Model.HospitalFullInfo> HospitalFullInfo { get; set; }
               public DbSet<ApiAll.Model.HospitalServiceTypeGroup> HospitalServiceTypeGroup { get; set; }
               public DbSet<ApiAll.Model.HospitalContragentDebitPaymentReport> HospitalContragentDebitPaymentReport { get; set; }
               public DbSet<ApiAll.Model.AnalizCovid> AnalizCovid { get; set; }
               public DbSet<ApiAll.Model.AnalizAgglyutinatsionTest> AnalizAgglyutinatsionTest { get; set; }
               public DbSet<ApiAll.Model.AnalizCovidMazok> AnalizCovidMazok { get; set; }
               public DbSet<ApiAll.Model.AnalizQondagiGarmonlar> AnalizQondagiGarmonlar { get; set; }
               public DbSet<ApiAll.Model.HospitalTelegramBotManager> HospitalTelegramBotManager { get; set; }
               public DbSet<ApiAll.Model.HospitalRegistrationPermissionDoctors> HospitalRegistrationPermissionDoctors { get; set; }
               public DbSet<ApiAll.Model.ContragentServiceTypeBonusAdditanaly> ContragentServiceTypeBonusAdditanaly { get; set; }
               public DbSet<ApiAll.Model.HospitalMrtSorovNoma> HospitalMrtSorovNoma { get; set; }
               public DbSet<ApiAll.Model.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients> HospitelRequiredServiceTypesAllPatcientsAndNotPatcients { get; set; }
               public DbSet<ApiAll.Model.ContragentAdditionalPaymentBefohand> ContragentAdditionalPaymentBefohand { get; set; }
               public DbSet<ApiAll.Model.ContragentAdditionalPaymentBefohandDetail> ContragentAdditionalPaymentBefohandDetail { get; set; }
               public DbSet<ApiAll.Model.ContragentAdditionalPaymentBefohandFullInfo> ContragentAdditionalPaymentBefohandFullInfo { get; set; }
               public DbSet<ApiAll.Model.HospitalManagerReport> HospitalManagerReport { get; set; }
               public DbSet<ApiAll.Model.VozvratAlreadyPaidPaymentList> VozvratAlreadyPaidPaymentList { get; set; }
               public DbSet<ApiAll.Model.HospitalServiceTypeByGroupPermission> HospitalServiceTypeByGroupPermission { get; set; }
               public DbSet<ApiAll.Model.HospitalContragentNotifierReport> HospitalContragentNotifierReport { get; set; }
               public DbSet<ApiAll.Model.MarketPrePaidMoney> MarketPrePaidMoney { get; set; }
               public DbSet<ApiAll.Model.MarketPayments> MarketPayments { get; set; }
               public DbSet<ApiAll.Model.FIleChecker> FIleChecker { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexMainProccess> TexMainProccess { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexAuthorization> TexAuthorization { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexBatch> TexBatch { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexBatchprocess> TexBatchprocess { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexCalcType> TexCalcType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexCategory> TexCategory { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColor> TexColor { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexXarakteristikaTool> TexXarakteristikaTool { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexXarakteristika> TexXarakteristika { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexValyuta> TexValyuta { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexUser> TexUser { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexUpakovka> TexUpakovka { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexUnitmeasurment> TexUnitmeasurment { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexTypeProduct> TexTypeProduct { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexSuroviyVid> TexSuroviyVid { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexStatus> TexStatus { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexSort> TexSort { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexSklad> TexSklad { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexServiceType> TexServiceType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexProductionType> TexProductionType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexProduct> TexProduct { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexPosition> TexPosition { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColorproccess> TexColorproccess { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexPlaningType> TexPlaningType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexPaymentType> TexPaymentType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColorGroup> TexColorGroup { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexGuscolor> TexGuscolor { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColorvariant> TexColorvariant { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColorVariantType> TexColorVariantType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexExtrawork> TexExtrawork { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexLanguage> TexLanguage { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexMeasurmentType> TexMeasurmentType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexInvoiceType> TexInvoiceType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexContragent> TexContragent { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexInvoice> TexInvoice { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexDepartment> TexDepartment { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexDevice> TexDevice { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColumnConfig> TexColumnConfig { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexInvoiceItem> TexInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrder> TexOrder { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrderItem> TexOrderItem { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexColorVariantRecipe> TexColorVariantRecipe { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexSubProccess> TexSubProccess { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexDeviceType> TexDeviceType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexDeviceSubProccessDetail> TexDeviceSubProccessDetail { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexSize> TexSize { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexMessage> TexMessage { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexMessageGroup> TexMessageGroup { get; set; }
               public DbSet<ApiAll.Model.pos.PosAuthorization> PosAuthorization { get; set; }
               public DbSet<ApiAll.Model.pos.PosBrend> PosBrend { get; set; }
               public DbSet<ApiAll.Model.pos.PosCardDetail> PosCardDetail { get; set; }
               public DbSet<ApiAll.Model.pos.PosCategory> PosCategory { get; set; }
               public DbSet<ApiAll.Model.pos.PosCheck> PosCheck { get; set; }
               public DbSet<ApiAll.Model.pos.PosClient> PosClient { get; set; }
               public DbSet<ApiAll.Model.pos.PosCompany> PosCompany { get; set; }
               public DbSet<ApiAll.Model.pos.PosClientCardType> PosClientCardType { get; set; }
               public DbSet<ApiAll.Model.pos.PosDepartment> PosDepartment { get; set; }
               public DbSet<ApiAll.Model.pos.PosInvoice> PosInvoice { get; set; }
               public DbSet<ApiAll.Model.pos.PosInvoiceItem> PosInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.pos.PosMessage> PosMessage { get; set; }
               public DbSet<ApiAll.Model.pos.PosMessageGroup> PosMessageGroup { get; set; }
               public DbSet<ApiAll.Model.pos.PosOrder> PosOrder { get; set; }
               public DbSet<ApiAll.Model.pos.PosOrderItem> PosOrderItem { get; set; }
               public DbSet<ApiAll.Model.pos.PosPayments> PosPayments { get; set; }
               public DbSet<ApiAll.Model.pos.PosProduct> PosProduct { get; set; }
               public DbSet<ApiAll.Model.pos.PosProductCode> PosProductCode { get; set; }
               public DbSet<ApiAll.Model.pos.PosProductTag> PosProductTag { get; set; }
               public DbSet<ApiAll.Model.pos.PosProductType> PosProductType { get; set; }
               public DbSet<ApiAll.Model.pos.PosProductUnitMeasurment> PosProductUnitMeasurment { get; set; }
               public DbSet<ApiAll.Model.pos.PosSklad> PosSklad { get; set; }
               public DbSet<ApiAll.Model.pos.PosSubDepartment> PosSubDepartment { get; set; }
               public DbSet<ApiAll.Model.pos.PosUser> PosUser { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrderItemStepsDetail> TexOrderItemStepsDetail { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrderItemStepPermissions> TexOrderItemStepPermissions { get; set; }
               public DbSet<ApiAll.Model.pos.PosRecipe> PosRecipe { get; set; }
               public DbSet<ApiAll.Model.pos.PosProductPrice> PosProductPrice { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveAccessMenu> ArchiveAccessMenu { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveAccessMenuItem> ArchiveAccessMenuItem { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveDepartment> ArchiveDepartment { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveDatchik> ArchiveDatchik { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveUser> ArchiveUser { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveRoom> ArchiveRoom { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveRoomDatchikDetail> ArchiveRoomDatchikDetail { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveCompany> ArchiveCompany { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveRoomDetail> ArchiveRoomDetail { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveNotificationReciver> ArchiveNotificationReciver { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveDevice> ArchiveDevice { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveUsersCheckInOutReport> ArchiveUsersCheckInOutReport { get; set; }
               public DbSet<ApiAll.Model.pos.PosManifacturer> PosManifacturer { get; set; }
               public DbSet<ApiAll.Model.pos.PosCurrencyType> PosCurrencyType { get; set; }
               public DbSet<ApiAll.Model.pos.PosRevertStatus> PosRevertStatus { get; set; }
               public DbSet<ApiAll.Model.pos.PosRevert> PosRevert { get; set; }
               public DbSet<ApiAll.Model.pos.PosRevertItem> PosRevertItem { get; set; }
               public DbSet<ApiAll.Model.pos.PosCreditorItem> PosCreditorItem { get; set; }
               public DbSet<ApiAll.Model.pos.PosCreditor> PosCreditor { get; set; }
               public DbSet<ApiAll.Model.pos.PosCosts> PosCosts { get; set; }
               public DbSet<ApiAll.Model.pos.PosDebitorInvoice> PosDebitorInvoice { get; set; }
               public DbSet<ApiAll.Model.pos.PosDebitorInvoiceItem> PosDebitorInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.pos.PosDebitorItem> PosDebitorItem { get; set; }
               public DbSet<ApiAll.Model.pos.PosDebitor> PosDebitor { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalBioximyaKrov> HospitalBioximyaKrov { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalCovidQon> HospitalCovidQon { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalExpressGepatitBC> HospitalExpressGepatitBC { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalGepatitBC> HospitalGepatitBC { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalKoagulogramma> HospitalKoagulogramma { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalMazok> HospitalMazok { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalNechiporenko> HospitalNechiporenko { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalOnkomarker> HospitalOnkomarker { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalPeshob> HospitalPeshob { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalQondagiGarmonlar> HospitalQondagiGarmonlar { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalRemaproba> HospitalRemaproba { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalRv> HospitalRv { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalTorch> HospitalTorch { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalVSK> HospitalVSK { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalUmQonTaxlili> HospitalUmQonTaxlili { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalPatientAnalizHistory> HospitalPatientAnalizHistory { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalCreditor> HospitalCreditor { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalCreditorItem> HospitalCreditorItem { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalCheckPatient> HospitalCheckPatient { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalDefaultSettings> HospitalDefaultSettings { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalPatientDolg> HospitalPatientDolg { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalDoctorShablons> HospitalDoctorShablons { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalPatientMessageHistory> HospitalPatientMessageHistory { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalBronRoomAddBeds> HospitalBronRoomAddBeds { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalBronRoomBeds> HospitalBronRoomBeds { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalBronRooms> HospitalBronRooms { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalPatientBronBeds> HospitalPatientBronBeds { get; set; }
               public DbSet<ApiAll.Model.hospital.dolg.HospitalPatientDolgPaymentsHistory> HospitalPatientDolgPaymentsHistory { get; set; }
               public DbSet<ApiAll.Model.hospital.telegram_bot.HospitalTelegramInformationBulider> HospitalTelegramInformationBulider { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexProductModel> TexProductModel { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrderItemRecipeForOneOrderitem> TexOrderItemRecipeForOneOrderitem { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrderItemRecipe> TexOrderItemRecipe { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexOrderItemRecipeReserve> TexOrderItemRecipeReserve { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonAuth> TegirmonAuth { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonCheck> TegirmonCheck { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonCheckInCheckOutDetail> TegirmonCheckInCheckOutDetail { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonClient> TegirmonClient { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonClientGroup> TegirmonClientGroup { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonCompany> TegirmonCompany { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonContragent> TegirmonContragent { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonCredit> TegirmonCredit { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonDebit> TegirmonDebit { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonCreditDetail> TegirmonCreditDetail { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonDebitDetail> TegirmonDebitDetail { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonDebitProductDetail> TegirmonDebitProductDetail { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonDepartment> TegirmonDepartment { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonDistrict> TegirmonDistrict { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonInvoice> TegirmonInvoice { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonInvoiceItem> TegirmonInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonInvoiceType> TegirmonInvoiceType { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonOstatka> TegirmonOstatka { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonPayments> TegirmonPayments { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonProduct> TegirmonProduct { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonTelegramBotMessages> TegirmonTelegramBotMessages { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonUnitMeasurment> TegirmonUnitMeasurment { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonUser> TegirmonUser { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazAuth> OquvMarkazAuth { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazCheck> OquvMarkazCheck { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazClient> OquvMarkazClient { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazCheckInOut> OquvMarkazCheckInOut { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazCompany> OquvMarkazCompany { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazCreditItem> OquvMarkazCreditItem { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazCredit> OquvMarkazCredit { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazDebit> OquvMarkazDebit { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazDebitItem> OquvMarkazDebitItem { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazDepartment> OquvMarkazDepartment { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazFanlar> OquvMarkazFanlar { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazInvoice> OquvMarkazInvoice { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazInvoiceItem> OquvMarkazInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazOstatka> OquvMarkazOstatka { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazPayments> OquvMarkazPayments { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazPosition> OquvMarkazPosition { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazProbniyDarslar> OquvMarkazProbniyDarslar { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazProduct> OquvMarkazProduct { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazPupilGroups> OquvMarkazPupilGroups { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazUser> OquvMarkazUser { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazUserSalary> OquvMarkazUserSalary { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazUserSalaryItem> OquvMarkazUserSalaryItem { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnalizSperma> HospitalAnalizSperma { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalAnalizGepatit> HospitalAnalizGepatit { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalAnalizNumberMark> HospitalAnalizNumberMark { get; set; }
               public DbSet<ApiAll.Model.hospital.HospitalMarkSeviceTyesWithNumber> HospitalMarkSeviceTyesWithNumber { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazFanAndGroupPayment> OquvMarkazFanAndGroupPayment { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazFanAndGroupPaymentLeftLessons> OquvMarkazFanAndGroupPaymentLeftLessons { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonProductToProductPersentageDetail> TegirmonProductToProductPersentageDetail { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonProductToProductPersentage> TegirmonProductToProductPersentage { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazDailyPupilsCalculation> OquvMarkazDailyPupilsCalculation { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazDailyPupilsCalculationInfo> OquvMarkazDailyPupilsCalculationInfo { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazUserSalaryMonthly> OquvMarkazUserSalaryMonthly { get; set; }
               public DbSet<ApiAll.Controllers.tegirmon.TegirmonTortilganBugdoyRoyxati> TegirmonTortilganBugdoyRoyxati { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonClientOstatka> TegirmonClientOstatka { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonClientOstatkaItem> TegirmonClientOstatkaItem { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonTortilganBugdoyRoyxatiGroup> TegirmonTortilganBugdoyRoyxatiGroup { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonTortilganBugdoyRoyxatiGroupDetail> TegirmonTortilganBugdoyRoyxatiGroupDetail { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveQuti> ArchiveQuti { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveJavon> ArchiveJavon { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveTokcha> ArchiveTokcha { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveStelaj> ArchiveStelaj { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveXujjat> ArchiveXujjat { get; set; }
               public DbSet<ApiAll.Model.archive.ArchiveXujjatTuri> ArchiveXujjatTuri { get; set; }
               public DbSet<ApiAll.Model.tegirmon.TegirmonClientDavennost> TegirmonClientDavennost { get; set; }
               public DbSet<ApiAll.Model.hospital.bron.HospitalOchred> HospitalOchred { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_1> HospitalAnaliz_1 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_2> HospitalAnaliz_2 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_3> HospitalAnaliz_3 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_4> HospitalAnaliz_4 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_5> HospitalAnaliz_5 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_6> HospitalAnaliz_6 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_7> HospitalAnaliz_7 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_8> HospitalAnaliz_8 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_10> HospitalAnaliz_10 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_9> HospitalAnaliz_9 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_11> HospitalAnaliz_11 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_12> HospitalAnaliz_12 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_13> HospitalAnaliz_13 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_14> HospitalAnaliz_14 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_15> HospitalAnaliz_15 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_16> HospitalAnaliz_16 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_17> HospitalAnaliz_17 { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazBook> OquvMarkazBook { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazBookUnit> OquvMarkazBookUnit { get; set; }
               public DbSet<ApiAll.Model.water.WaterAuth> WaterAuth { get; set; }
               public DbSet<ApiAll.Model.water.WaterUser> WaterUser { get; set; }
               public DbSet<ApiAll.Model.water.WaterCheck> WaterCheck { get; set; }
               public DbSet<ApiAll.Model.water.WaterClient> WaterClient { get; set; }
               public DbSet<ApiAll.Model.water.WaterClientBottleInfo> WaterClientBottleInfo { get; set; }
               public DbSet<ApiAll.Model.water.WaterClientBottleInfoDetail> WaterClientBottleInfoDetail { get; set; }
               public DbSet<ApiAll.Model.water.WaterClientDolg> WaterClientDolg { get; set; }
               public DbSet<ApiAll.Model.water.WaterClientType> WaterClientType { get; set; }
               public DbSet<ApiAll.Model.water.WaterContragent> WaterContragent { get; set; }
               public DbSet<ApiAll.Model.water.WaterContragentType> WaterContragentType { get; set; }
               public DbSet<ApiAll.Model.water.WaterInvoice> WaterInvoice { get; set; }
               public DbSet<ApiAll.Model.water.WaterInvoiceItem> WaterInvoiceItem { get; set; }
               public DbSet<ApiAll.Model.water.WaterOrder> WaterOrder { get; set; }
               public DbSet<ApiAll.Model.water.WaterOrderItem> WaterOrderItem { get; set; }
               public DbSet<ApiAll.Model.water.WaterProduct> WaterProduct { get; set; }
               public DbSet<ApiAll.Model.water.WaterProductOstatka> WaterProductOstatka { get; set; }
               public DbSet<ApiAll.Model.water.WaterTuman> WaterTuman { get; set; }
               public DbSet<ApiAll.Model.water.WaterViloyat> WaterViloyat { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazBookAndGroup> OquvMarkazBookAndGroup { get; set; }
               public DbSet<ApiAll.Model.oquv_markaz.OquvMarkazBookAndGroupDetil> OquvMarkazBookAndGroupDetil { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexSizeType> TexSizeType { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexRaskladki> TexRaskladki { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexRaskladkiItem> TexRaskladkiItem { get; set; }
               public DbSet<ApiAll.Model.tekistil.raskladki.TexRaskladkiDeviceInformation> TexRaskladkiDeviceInformation { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexRaskladkiInformation> TexRaskladkiInformation { get; set; }
               public DbSet<ApiAll.Model.tekistil.raskladki.TexRaskladkiKroyInformation> TexRaskladkiKroyInformation { get; set; }
               public DbSet<ApiAll.Model.tekistil.raskladki.TexRaskladkiModelInformatation> TexRaskladkiModelInformatation { get; set; }
               public DbSet<ApiAll.Model.tekistil.raskladki.TexRaskladkiModelQtyInformation> TexRaskladkiModelQtyInformation { get; set; }
               public DbSet<ApiAll.Model.tekistil.raskladki.TexRaskladkiModelRasxodInformation> TexRaskladkiModelRasxodInformation { get; set; }
               public DbSet<ApiAll.Model.tekistil.raskladki.TexRaskladkiStepInformation> TexRaskladkiStepInformation { get; set; }
               public DbSet<ApiAll.Model.tekistil.planning.TexProductAndSubDetail> TexProductAndSubDetail { get; set; }
               public DbSet<ApiAll.Model.tekistil.planning.TexSubProduct> TexSubProduct { get; set; }
               public DbSet<ApiAll.Model.tekistil.planning.TexPlanningItems> TexPlanningItems { get; set; }
               public DbSet<ApiAll.Model.tekistil.planning.TexPlanning> TexPlanning { get; set; }
               public DbSet<ApiAll.Model.tekistil.seworder.TexSewOrder> TexSewOrder { get; set; }
               public DbSet<ApiAll.Model.tekistil.seworder.TexSewOrderItem> TexSewOrderItem { get; set; }
               public DbSet<ApiAll.Model.tekistil.seworder.TexSewOrderItemStep> TexSewOrderItemStep { get; set; }
               public DbSet<ApiAll.Model.tekistil.seworder.TexSewOrderItemStepItem> TexSewOrderItemStepItem { get; set; }
               public DbSet<ApiAll.Model.tekistil.seworder.TexStep> TexStep { get; set; }
               public DbSet<ApiAll.Model.tekistil.sewextrawork.TexSewExtraWork> TexSewExtraWork { get; set; }
               public DbSet<ApiAll.Model.tekistil.sewextrawork.TexSewExtraWorkItem> TexSewExtraWorkItem { get; set; }
               public DbSet<ApiAll.Model.tekistil.access.TexWareHouseAccess> TexWareHouseAccess { get; set; }
               public DbSet<ApiAll.Model.tekistil.TexProductAndRecipe> TexProductAndRecipe { get; set; }
               public DbSet<ApiAll.Model.tekistil.order_item_steps.TexOrderItemSizeAndCount> TexOrderItemSizeAndCount { get; set; }
               public DbSet<ApiAll.Model.tekistil.order_item_steps.TexOrderitemStepsAndPersantage> TexOrderitemStepsAndPersantage { get; set; }
               public DbSet<ApiAll.Model.parking.ParkingAuth> ParkingAuth { get; set; }
               public DbSet<ApiAll.Model.parking.ParkingUsers> ParkingUsers { get; set; }
               public DbSet<ApiAll.Model.parking.ParkingPayment> ParkingPayment { get; set; }
               public DbSet<ApiAll.Model.parking.ParkingPlace> ParkingPlace { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_18> HospitalAnaliz_18 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_19> HospitalAnaliz_19 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.HospitalAnaliz_20> HospitalAnaliz_20 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_21> HospitalAnaliz_21 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_22> HospitalAnaliz_22 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_23> HospitalAnaliz_23 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_24> HospitalAnaliz_24 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_25> HospitalAnaliz_25 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_26> HospitalAnaliz_26 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_27> HospitalAnaliz_27 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_28> HospitalAnaliz_28 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_29> HospitalAnaliz_29 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_30> HospitalAnaliz_30 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_31> HospitalAnaliz_31 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_32> HospitalAnaliz_32 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_33> HospitalAnaliz_33 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_34> HospitalAnaliz_34 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_35> HospitalAnaliz_35 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_36> HospitalAnaliz_36 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_37> HospitalAnaliz_37 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_38> HospitalAnaliz_38 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_39> HospitalAnaliz_39 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_40> HospitalAnaliz_40 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_41> HospitalAnaliz_41 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_42> HospitalAnaliz_42 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_43> HospitalAnaliz_43 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_44> HospitalAnaliz_44 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_46> HospitalAnaliz_46 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_47> HospitalAnaliz_47 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_48> HospitalAnaliz_48 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_49> HospitalAnaliz_49 { get; set; }
               public DbSet<ApiAll.Model.hospital.analiz.analiz_unversal.HospitalAnaliz_50> HospitalAnaliz_50 { get; set; }
               public DbSet<ApiAll.Model.hospital.PaymentsDeleted> PaymentsDeleted { get; set; }
               public DbSet<ApiAll.Model.hotel.HotelRoomType> HotelRoomType { get; set; }
               public DbSet<ApiAll.Model.hospital.bron_new.HospitalRoomType> HospitalRoomType { get; set; }
               public DbSet<ApiAll.Model.hospital.bron_new.HospitalBronRoomN> HospitalBronRoomN { get; set; }
               public DbSet<ApiAll.Model.hospital.bron_new.HospitalBronRoomItemN> HospitalBronRoomItemN { get; set; }
               public DbSet<ApiAll.Model.hospital.bron_new.HospitalBronRoomOrBedDateInfo> HospitalBronRoomOrBedDateInfo { get; set; }
               public DbSet<ApiAll.Model.hospital.bron_new.HospitalBronRoomPayments> HospitalBronRoomPayments { get; set; }

        //


        //
    }

    //https://localhost:5001/swagger/index.html
    //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=allapi;Username=postgres;Password=BeK_159753");
}
