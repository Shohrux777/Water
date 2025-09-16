using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosManifacturerController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosManifacturerController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosManifacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosManifacturer>>> GetPosManifacturer()
        {
            return await _context.PosManifacturer.ToListAsync();
        }

        [HttpGet("searchManifacturerByName")]
        public async Task<ActionResult<IEnumerable<PosManifacturer>>> searchManifacturerByName([FromQuery] String name)
        {
            return await _context.PosManifacturer.Where(p =>p.name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        [HttpGet("updateAllDefaultSettings")]
        public async Task<ActionResult<IEnumerable<PosManifacturer>>> updateAllDefaultSettings()
        {
            //create default user
            List<PosUser> userList = await _context.PosUser.ToListAsync();
            if (userList == null || userList.Count == 0) {
                PosCompany posCompany = new PosCompany();
                List<PosCompany> companieList = await _context.PosCompany.ToListAsync();
                if (companieList == null || companieList.Count == 0)
                {
                    posCompany.active_status = true;
                    posCompany.name = "Аптека";
                    _context.PosCompany.Update(posCompany);
                    await _context.SaveChangesAsync();


                }
                else {

                    posCompany = companieList.First();
                }

                PosUser posUser = new PosUser();
                posUser.active_status = false;
                posUser.address = "`Extremesoft SS` OOO";
                posUser.fio = "EXTREMESOFT";
                posUser.phone_number = "+998974247024";
                posUser.real_company_id = 0;

                _context.PosUser.Update(posUser);
                await _context.SaveChangesAsync();

                PosAuthorization pos = new PosAuthorization();
                pos.real_company_id = 0;
                pos.login = "root";
                pos.password = "63a9f0ea7bb98050796b649e85481845";
                pos.active_status = true;
                pos.user_id = posUser.id;
                pos.user = posUser;
                pos.access_type = 1;
                pos.company_id = posCompany.id;

                _context.PosAuthorization.Update(pos);
                await _context.SaveChangesAsync();

                List<PosDepartment> departments = await _context.PosDepartment.ToListAsync();
                if (departments == null || departments.Count  == 0) {
                    PosDepartment department = new PosDepartment();
                    department.active_status = true;
                    department.real_company_id = 0;
                    department.name = "Главный отдел";
                    department.company_id = posCompany.id;

                    _context.PosDepartment.Update(department);
                    await _context.SaveChangesAsync();

                    List<PosSklad> skladList = await _context.PosSklad.ToListAsync();

                    if (skladList == null || skladList.Count == 0) {
                        PosSklad sklad = new PosSklad();
                        sklad.active_status = true;
                        sklad.real_company_id = posCompany.id;
                        sklad.department_id = department.id;
                        sklad.name = "Основной склад";
                        sklad.real_company_id = 0;

                        _context.PosSklad.Update(sklad);
                        await _context.SaveChangesAsync();

                    }
                }


              
            }




            List<PosProductUnitMeasurment> posProductUnitMeasurmentList = await _context.PosProductUnitMeasurment.ToListAsync();
            if (posProductUnitMeasurmentList == null || posProductUnitMeasurmentList.Count == 0) {
                List<String> nameList = new List<String>();
                nameList.Add("Уп");
                nameList.Add("Шт");
                nameList.Add("Гр");
                nameList.Add("Литр");
                foreach (String item in nameList) {
                    PosProductUnitMeasurment ms = new PosProductUnitMeasurment();
                    ms.active_status = true;
                    ms.real_company_id = 0;
                    ms.name = item;
                    _context.PosProductUnitMeasurment.Update(ms);
                    await _context.SaveChangesAsync();
                }
            }
            
            //Валютная
            //Суммовой
            //НДС
            List<PosCurrencyType> currencyList = await _context.PosCurrencyType.ToListAsync();
            if (currencyList == null || currencyList.Count == 0) {
                //USD
                PosCurrencyType posCurrency1= new PosCurrencyType();
                posCurrency1.active_status = true;
                posCurrency1.real_company_id = 0;
                posCurrency1.nds_persantage = 0.0;
                posCurrency1.name = "Валютная";
            
                _context.PosCurrencyType.Update(posCurrency1);
                await _context.SaveChangesAsync();

                //SUMM
                PosCurrencyType posCurrency2 = new PosCurrencyType();
                posCurrency2.active_status = true;
                posCurrency2.real_company_id = 0;
                posCurrency2.nds_persantage = 0.0;
                posCurrency2.name = "Суммовой";

                _context.PosCurrencyType.Update(posCurrency2);
                await _context.SaveChangesAsync();

                //NDS
                PosCurrencyType posCurrency3 = new PosCurrencyType();
                posCurrency3.active_status = true;
                posCurrency3.real_company_id = 0;
                posCurrency3.nds_persantage = 15.0;
                posCurrency3.name = "НДС";

                _context.PosCurrencyType.Update(posCurrency3);
                await _context.SaveChangesAsync();

            }

            //vozvartalardi tanlaydigonlari
            //Списания товары 1
            //Возврат товары  2
            //Возврат от пакупатели  3
            List<PosRevertStatus> revertsList = await _context.PosRevertStatus.ToListAsync();
            if (revertsList == null || revertsList.Count == 0) {

                //1
                PosRevertStatus rev1 = new PosRevertStatus();
                rev1.active_status = true;
                rev1.real_company_id = 0;
                rev1.name = "Списания товары";
                rev1.status = 1;
                _context.PosRevertStatus.Update(rev1);
                await _context.SaveChangesAsync();

                //2
                PosRevertStatus rev2 = new PosRevertStatus();
                rev2.active_status = true;
                rev2.real_company_id = 0;
                rev2.name = "Возврат товары";
                rev2.status = 2;
                _context.PosRevertStatus.Update(rev2);
                await _context.SaveChangesAsync();

                //3
                PosRevertStatus rev3 = new PosRevertStatus();
                rev3.active_status = true;
                rev3.real_company_id = 0;
                rev3.name = "Возврат от пакупатели";
                rev3.status = 3;
                _context.PosRevertStatus.Update(rev2);
                await _context.SaveChangesAsync();


            }

            
            


            List<PosManifacturer> manifacturerNameList = await _context.PosManifacturer.ToListAsync();
            if (manifacturerNameList != null && manifacturerNameList.Count > 0) {
                _context.PosManifacturer.RemoveRange(manifacturerNameList);
                await _context.SaveChangesAsync();
            }
            List<PosProduct> productList = await _context.PosProduct.ToListAsync();
            HashSet<String> manifacturerNameListForAdd = new HashSet<String>();
            foreach (PosProduct item in productList) {
                if (item.manifacturer_name != null && item.manifacturer_name.Trim().Length > 0) {
                    manifacturerNameListForAdd.Add(item.manifacturer_name);
                }
            }

            List<PosManifacturer> manrealList = new List<PosManifacturer>();
            foreach (String nm in manifacturerNameListForAdd) {
                PosManifacturer manf = new PosManifacturer();
                manf.active_status = true;
                manf.real_company_id = 0;
                manf.name = nm;
                manrealList.Add(manf);
            }

            _context.PosManifacturer.UpdateRange(manrealList);
            await _context.SaveChangesAsync();
            return manrealList;
        }

        // GET: api/PosManifacturer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosManifacturer>> GetPosManifacturer(long id)
        {
            var posManifacturer = await _context.PosManifacturer.FindAsync(id);

            if (posManifacturer == null)
            {
                return NotFound();
            }

            return posManifacturer;
        }

        // PUT: api/PosManifacturer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosManifacturer(long id, PosManifacturer posManifacturer)
        {
            if (id != posManifacturer.id)
            {
                return BadRequest();
            }

            _context.Entry(posManifacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosManifacturerExists(id))
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

        // POST: api/PosManifacturer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosManifacturer>> PostPosManifacturer(PosManifacturer posManifacturer)
        {
            _context.PosManifacturer.Update(posManifacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosManifacturer", new { id = posManifacturer.id }, posManifacturer);
        }

        // DELETE: api/PosManifacturer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosManifacturer>> DeletePosManifacturer(long id)
        {
            var posManifacturer = await _context.PosManifacturer.FindAsync(id);
            if (posManifacturer == null)
            {
                return NotFound();
            }

            _context.PosManifacturer.Remove(posManifacturer);
            await _context.SaveChangesAsync();

            return posManifacturer;
        }

        private bool PosManifacturerExists(long id)
        {
            return _context.PosManifacturer.Any(e => e.id == id);
        }
    }
}
