using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonClientController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonClientController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonClient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonClient>>> GetTegirmonClient()
        {
            return await _context.TegirmonClient.ToListAsync();
        }

        // GET: api/TegirmonClient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonClient>> GetTegirmonClient(long id)
        {
            var tegirmonClient = await _context.TegirmonClient.FindAsync(id);

            if (tegirmonClient == null)
            {
                return NotFound();
            }

            return tegirmonClient;
        }



        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClient> categoryList = await _context.TegirmonClient
                .Include(p => p.group)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClient.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByBornDate")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByBornDate([FromQuery] int page, [FromQuery] int size,[FromQuery] String born_date_str)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClient> categoryList = await _context.TegirmonClient
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.addiotionala_information.ToLower().Contains(born_date_str.ToLower()))
                
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClient>();
            }


            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClient.Where(p => p.active_status == true 
            && p.addiotionala_information.ToLower().Contains(born_date_str.ToLower())).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByNote")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByNote([FromQuery] int page, [FromQuery] int size, [FromQuery] String note_str)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClient> categoryList = await _context.TegirmonClient
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.note.ToLower().Contains(note_str.ToLower()))

                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClient>();
            }


            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClient.Where(p => p.active_status == true
            && p.note.ToLower().Contains(note_str.ToLower())).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationSearchByFioOrPassportSerailNumberOrHomeOrMobilePhoneNumber")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByFioOrPassportSerailNumberOrHomeOrMobilePhoneNumber([FromQuery] int page, [FromQuery] int size,[FromQuery] String fio_or_serial_number)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClient> categoryList = new List<TegirmonClient>();
            if (fio_or_serial_number.Trim().Length > 0)
            {
                categoryList = await _context.TegirmonClient
                .Include(p => p.group)
                .Where(p => p.active_status == true &&
                (p.fio.ToLower().Contains(fio_or_serial_number.ToLower())
                || p.passport_number.ToLower().Contains(fio_or_serial_number.ToLower())
                 || p.phone_number.ToLower().Contains(fio_or_serial_number.ToLower())
                 || p.home_phone_number.ToLower().Contains(fio_or_serial_number.ToLower())))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }
            else {
                categoryList = await _context.TegirmonClient
                .Include(p => p.group)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }


            if (categoryList == null)
            {
                categoryList = new List<TegirmonClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationClientListByGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationClientListByGroupId([FromQuery] int page, [FromQuery] int size,[FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClient> categoryList = await _context.TegirmonClient
                .Include(p => p.group)
                .Where(p => p.active_status == true && p.TegirmonClientGroupid == group_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClient.Where(p => p.active_status == true && p.TegirmonClientGroupid == group_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TegirmonClient/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonClient(long id, TegirmonClient tegirmonClient)
        {
            if (id != tegirmonClient.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonClientExists(id))
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

        // POST: api/TegirmonClient
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonClient>> PostTegirmonClient(TegirmonClient tegirmonClient)
        {
            _context.TegirmonClient.Update(tegirmonClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonClient", new { id = tegirmonClient.id }, tegirmonClient);
        }

        [HttpPost("getSaveBase64ImageToFolderAndGetImageUrl")]
        public async Task<ActionResult<TegirmonImageTemp>> getSaveBase64ImageToFolderAndGetImageUrl(TegirmonImageTemp image_temp)
        {
            image_temp.image_url_str = saveImageToFolder(image_temp.image_base_64);

            return image_temp;
        }


        // DELETE: api/TegirmonClient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonClient>> DeleteTegirmonClient(long id)
        {
            var tegirmonClient = await _context.TegirmonClient.FindAsync(id);
            if (tegirmonClient == null)
            {
                return NotFound();
            }

            _context.TegirmonClient.Remove(tegirmonClient);
            await _context.SaveChangesAsync();

            return tegirmonClient;
        }

        private bool TegirmonClientExists(long id)
        {
            return _context.TegirmonClient.Any(e => e.id == id);
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
