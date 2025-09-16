using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.telegram_bot;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace ApiAll.Controllers.hospital.telegram_bot
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalTelegramInformationBuliderController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalTelegramInformationBuliderController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalTelegramInformationBulider
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalTelegramInformationBulider>>> GetHospitalTelegramInformationBulider()
        {
            return await _context.HospitalTelegramInformationBulider.ToListAsync();
        }

        // GET: api/HospitalTelegramInformationBulider/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalTelegramInformationBulider>> GetHospitalTelegramInformationBulider(long id)
        {
            var hospitalTelegramInformationBulider = await _context.HospitalTelegramInformationBulider.FindAsync(id);

            if (hospitalTelegramInformationBulider == null)
            {
                return NotFound();
            }

            return hospitalTelegramInformationBulider;
        }

        // PUT: api/HospitalTelegramInformationBulider/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalTelegramInformationBulider(long id, HospitalTelegramInformationBulider hospitalTelegramInformationBulider)
        {
            if (id != hospitalTelegramInformationBulider.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalTelegramInformationBulider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalTelegramInformationBuliderExists(id))
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

        // POST: api/HospitalTelegramInformationBulider
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalTelegramInformationBulider>> PostHospitalTelegramInformationBulider(HospitalTelegramInformationBulider hospitalTelegramInformationBulider)
        {
            _context.HospitalTelegramInformationBulider.Update(hospitalTelegramInformationBulider);
            if (hospitalTelegramInformationBulider.image_base_64_list != null) {
                List<String> image_ulr_list = new List<String>();
                foreach (String image_base_64 in hospitalTelegramInformationBulider.image_base_64_list) {
                    if (image_base_64.Trim().Length > 0) {
                        try
                        {
                            String img_saved_url = saveImageToFolder(image_base_64);
                            image_ulr_list.Add(img_saved_url);
                        }
                        catch (FormatException){
                        }
                        catch (Exception) {
                        }
                    }
                }
                hospitalTelegramInformationBulider.images_url_list_after_saving_list = image_ulr_list;


            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalTelegramInformationBulider", new { id = hospitalTelegramInformationBulider.id }, hospitalTelegramInformationBulider);
        }

        // DELETE: api/HospitalTelegramInformationBulider/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalTelegramInformationBulider>> DeleteHospitalTelegramInformationBulider(long id)
        {
            var hospitalTelegramInformationBulider = await _context.HospitalTelegramInformationBulider.FindAsync(id);
            if (hospitalTelegramInformationBulider == null)
            {
                return NotFound();
            }

            _context.HospitalTelegramInformationBulider.Remove(hospitalTelegramInformationBulider);
            await _context.SaveChangesAsync();

            return hospitalTelegramInformationBulider;
        }

        private bool HospitalTelegramInformationBuliderExists(long id)
        {
            return _context.HospitalTelegramInformationBulider.Any(e => e.id == id);
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
