using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class FIleCheckersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private IHostingEnvironment _env;

        public FIleCheckersController(ApplicationContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/FIleCheckers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FIleChecker>>> GetFIleChecker()
        {
            return await _context.FIleChecker.ToListAsync();
        }

        // GET: api/FIleCheckers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FIleChecker>> GetFIleChecker(long id)
        {
            var fIleChecker = await _context.FIleChecker.FindAsync(id);

            if (fIleChecker == null)
            {
                return NotFound();
            }

            return fIleChecker;
        }

        [HttpPost("getSaveImageFileToFolder")]
        public async Task<ActionResult<FIleChecker>> getSaveFileToFolder(FIleChecker imageStrBase64)
        {

            String file_name_img = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss_fff");

            Console.WriteLine(file_name_img);

            FIleChecker fIleChecker = new FIleChecker();
            //var webRoot = _env.WebRootPath;

            var PathWithFolderName = Path.Combine(Directory.GetCurrentDirectory(), "images");
  
            Console.WriteLine(file_name_img);

            try
            {
                if (!Directory.Exists(PathWithFolderName))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(PathWithFolderName);

                }
                string Base64String = imageStrBase64.src;//.Replace("data:image/png;base64,", "");
                String[] wordsArr = Base64String.Split(",");
                if (wordsArr != null && wordsArr.Length > 1) {
                     Base64String = imageStrBase64.src.Replace(wordsArr[0]+",", "");
                }


                byte[] bytes = Convert.FromBase64String(Base64String);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                    String image_path = "images/" + file_name_img + ".jpg";
                    Console.WriteLine(image_path);
                    fIleChecker.imageUrl = image_path;
                    image.Save(PathWithFolderName + "/" + file_name_img + ".jpg", ImageFormat.Jpeg);
                }



            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }


            

            return fIleChecker;
        }

        // PUT: api/FIleCheckers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFIleChecker(long id, FIleChecker fIleChecker)
        {
            if (id != fIleChecker.Id)
            {
                return BadRequest();
            }

            _context.Entry(fIleChecker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FIleCheckerExists(id))
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

        // POST: api/FIleCheckers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FIleChecker>> PostFIleChecker(FIleChecker fIleChecker)
        {
            _context.FIleChecker.Update(fIleChecker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFIleChecker", new { id = fIleChecker.Id }, fIleChecker);
        }

        // DELETE: api/FIleCheckers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FIleChecker>> DeleteFIleChecker(long id)
        {
            var fIleChecker = await _context.FIleChecker.FindAsync(id);
            if (fIleChecker == null)
            {
                return NotFound();
            }

            _context.FIleChecker.Remove(fIleChecker);
            await _context.SaveChangesAsync();

            return fIleChecker;
        }

        private bool FIleCheckerExists(long id)
        {
            return _context.FIleChecker.Any(e => e.Id == id);
        }
    }
}
