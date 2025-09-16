using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalPatientAnalizHistoryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPatientAnalizHistoryController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPatientAnalizHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPatientAnalizHistory>>> GetHospitalPatientAnalizHistory()
        {
            return await _context.HospitalPatientAnalizHistory.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientAnalizHistory> itemList = await _context.HospitalPatientAnalizHistory
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientAnalizHistory>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientAnalizHistory.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientAnalizHistory> itemList = await _context.HospitalPatientAnalizHistory
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientAnalizHistory>();
            }

            foreach (HospitalPatientAnalizHistory item in  itemList) {
                item.analiz_base_str = String.Empty;
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientAnalizHistory
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalPatientAnalizHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPatientAnalizHistory>> GetHospitalPatientAnalizHistory(long id)
        {
            var hospitalPatientAnalizHistory = await _context.HospitalPatientAnalizHistory.FindAsync(id);

            if (hospitalPatientAnalizHistory == null)
            {
                return NotFound();
            }


            hospitalPatientAnalizHistory.patients = await _context.Patients.FindAsync(hospitalPatientAnalizHistory.PatientsId);


            return hospitalPatientAnalizHistory;
        }

        // PUT: api/HospitalPatientAnalizHistory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPatientAnalizHistory(long id, HospitalPatientAnalizHistory hospitalPatientAnalizHistory)
        {
            if (id != hospitalPatientAnalizHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPatientAnalizHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPatientAnalizHistoryExists(id))
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

        // POST: api/HospitalPatientAnalizHistory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPatientAnalizHistory>> PostHospitalPatientAnalizHistory(HospitalPatientAnalizHistory hospitalPatientAnalizHistory)
        {
            if (hospitalPatientAnalizHistory.analiz_base_str != null
                && hospitalPatientAnalizHistory.analiz_base_str.Trim().Length > 0) {
                String file_name_str = saveImageToFolder(hospitalPatientAnalizHistory.analiz_base_str);
                hospitalPatientAnalizHistory.analiz_file_name = file_name_str;

            }

            try {
                _context.HospitalPatientAnalizHistory.Update(hospitalPatientAnalizHistory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }


            return hospitalPatientAnalizHistory;
        }

        // DELETE: api/HospitalPatientAnalizHistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPatientAnalizHistory>> DeleteHospitalPatientAnalizHistory(long id)
        {
            var hospitalPatientAnalizHistory = await _context.HospitalPatientAnalizHistory.FindAsync(id);
            if (hospitalPatientAnalizHistory == null)
            {
                return NotFound();
            }

            _context.HospitalPatientAnalizHistory.Remove(hospitalPatientAnalizHistory);
            await _context.SaveChangesAsync();

            return hospitalPatientAnalizHistory;
        }

        private bool HospitalPatientAnalizHistoryExists(long id)
        {
            return _context.HospitalPatientAnalizHistory.Any(e => e.id == id);
        }

        private String saveImageToFolder(String imageBase64Str)
        {
            if (imageBase64Str == null || imageBase64Str.Trim().Length == 0)
            {
                return String.Empty;
            }

            String file_name_img = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss_fff");
            var PathWithFolderName = Path.Combine(Directory.GetCurrentDirectory(), "images");
            try
            {
                if (!Directory.Exists(PathWithFolderName))
                {
                    DirectoryInfo di = Directory.CreateDirectory(PathWithFolderName);

                }
                string Base64String = imageBase64Str;//.Replace("data:image/png;base64,", "");
                String[] wordsArr = Base64String.Split(",");
                if (wordsArr != null && wordsArr.Length > 1)
                {
                    Base64String = imageBase64Str.Replace(wordsArr[0] + ",", "");
                }
                byte[] bytes = Convert.FromBase64String(Base64String);

                Image image;
                String image_path = "images/" + file_name_img + ".jpg";
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                    Console.WriteLine(image_path);
                    try
                    {

                        image.Save(PathWithFolderName + "/" + file_name_img + ".jpg", ImageFormat.Jpeg);
                    }
                    catch (Exception)
                    {
                        image.Save(PathWithFolderName + "/" + file_name_img + ".jpg", ImageFormat.Jpeg);
                    }

                }
                return image_path;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return String.Empty;
            }


        }
    }
}
