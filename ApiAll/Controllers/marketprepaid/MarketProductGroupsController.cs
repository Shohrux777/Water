using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.market;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketProductGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketProductGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketProductGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketProductGroup>>> GetMarketProductGroup()
        {
            return await _context.MarketProductGroup.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getMainProductGroup")]
        public async Task<ActionResult<IEnumerable<MarketProductGroup>>> getMainProductGroup()
        {
            return await _context.MarketProductGroup.Where(p => p.MainProductGroup == true).ToListAsync();
        }

        [HttpGet("getNotMainProductGroup")]
        public async Task<ActionResult<IEnumerable<MarketProductGroup>>> getNotMainProductGroup()
        {
            return await _context.MarketProductGroup.Where(p => p.MainProductGroup == false).ToListAsync();
        }

        [HttpGet("getSubProductGroupByMainId")]
        public async Task<ActionResult<IEnumerable<MarketProductGroup>>> getSubProductGroupByMainId([FromQuery] long ProductGroupId)
        {
            return await _context.MarketProductGroup.Where(p => p.MarketProductGroupId == ProductGroupId).ToListAsync();
        }

        [HttpGet("getSubProductGroupAndProductsByProductGroupId")]
        public async Task<ActionResult<MarketProductGroupAndProducts>> getSubProductGroupAndProductsByProductGroupId([FromQuery] long ProductGroupId,[FromQuery] long authId)
        {
            List<MarketProductGroup> marketProductGroupList =  await _context.MarketProductGroup.Where(p => p.MarketProductGroupId == ProductGroupId).ToListAsync();
            List<MarketProductGroupDetail> marketProductGroupDetailList = await _context.MarketProductGroupDetail.Where(p => p.MarketProductGroupId == ProductGroupId).Include(p => p.product).ToListAsync();
            foreach (MarketProductGroupDetail item in marketProductGroupDetailList) {
                List<MarketProductRealQty> marketProductRealQties = await _context.MarketProductRealQty.Where(m => m.MarketProductId == item.MarketProductId).ToListAsync();
                List<MarketAuthLimitByProduct> marketAuthLimitByProducts = await _context.MarketAuthLimitByProduct.Where(l => l.MarketProductId == item.MarketProductId && (l.beginDateTime <= DateTime.Now && l.endDateTime>= DateTime.Now) && l.AuthorizationId == authId).ToListAsync();
                if(marketProductRealQties != null && marketProductRealQties.Count > 0)
                {
                    item.marketProductRealQty = marketProductRealQties.SingleOrDefault();
                }
                if (marketAuthLimitByProducts != null && marketAuthLimitByProducts.Count > 0) {
                    item.marketAuthLimitByProduct = marketAuthLimitByProducts.SingleOrDefault();
                }
            }
            MarketProductGroupAndProducts marketProductGroupAndProducts = new MarketProductGroupAndProducts();
            marketProductGroupAndProducts.marketProductGroupDetailList = marketProductGroupDetailList;
            marketProductGroupAndProducts.marketProductGroupList = marketProductGroupList;

            return marketProductGroupAndProducts;

        }

        // GET: api/MarketProductGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProductGroup>> GetMarketProductGroup(long id)
        {
            var marketProductGroup = await _context.MarketProductGroup.FindAsync(id);

            if (marketProductGroup == null)
            {
                return NotFound();
            }
            return marketProductGroup;
        }

        // PUT: api/MarketProductGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketProductGroup(long id, MarketProductGroup marketProductGroup)
        {
            if (id != marketProductGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketProductGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductGroupExists(id))
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

        // POST: api/MarketProductGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketProductGroup>> PostMarketProductGroup(MarketProductGroup marketProductGroup)
        {
            marketProductGroup.PictureStr = saveImageToFolder(marketProductGroup.PictureStr);
            _context.MarketProductGroup.Update(marketProductGroup);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMarketProductGroup", new { id = marketProductGroup.Id }, marketProductGroup);
        }

        // DELETE: api/MarketProductGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketProductGroup>> DeleteMarketProductGroup(long id)
        {
            var marketProductGroup = await _context.MarketProductGroup.FindAsync(id);
            if (marketProductGroup == null)
            {
                return NotFound();
            }

            _context.MarketProductGroup.Remove(marketProductGroup);
            await _context.SaveChangesAsync();

            return marketProductGroup;
        }

        private bool MarketProductGroupExists(long id)
        {
            return _context.MarketProductGroup.Any(e => e.Id == id);
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
                        Bitmap imgbitmap = new Bitmap(image);
                        Image resizedImage = (Image)(new Bitmap(imgbitmap, new Size(200, 200)));
                        resizedImage.Save(PathWithFolderName + "/" + file_name_img + ".jpg", ImageFormat.Jpeg);
                    }
                    catch (Exception){
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
