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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketProductsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketProduct>>> GetMarketProduct()
        {
            return await _context.MarketProduct.OrderByDescending(p => p.Id).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<PaginationModel>> getPagination()
        {
            List<MarketProduct> marketProductList = await _context.MarketProduct.Include(p => p.marketUnitMeasurment).OrderByDescending(p => p.Id).ToListAsync();
            foreach (MarketProduct marketProduct in marketProductList)
            {
                List<MarketProductGroupDetail> marketProductGroupDetails = await _context.MarketProductGroupDetail.Where(p => p.MarketProductId == marketProduct.Id).ToListAsync();
                if (marketProductGroupDetails != null && marketProductGroupDetails.Count > 0)
                {
                    MarketProductGroup productGroup = await _context.MarketProductGroup.FindAsync(marketProductGroupDetails.First().Id);
                    marketProduct.marketProductGroup = productGroup;
                }
            }
            PaginationModel paginationModel = new PaginationModel();
            paginationModel.marketProductList = marketProductList;
            paginationModel.count = await _context.MarketProduct.CountAsync();
            return paginationModel;
        }


        [HttpGet("getMarketProductListForMarket")]
        public async Task<ActionResult<IEnumerable<MarketProduct>>> getMarketProductListForMarket()
        {
            List<MarketProduct> marketProductList =  await _context.MarketProduct.Include( p =>p.marketUnitMeasurment).OrderByDescending(p => p.Id).ToListAsync();
            foreach (MarketProduct marketProduct in marketProductList) {
                List<MarketProductGroupDetail> marketProductGroupDetails = await _context.MarketProductGroupDetail.Where(p => p.MarketProductId == marketProduct.Id).ToListAsync();
                if (marketProductGroupDetails != null && marketProductGroupDetails.Count > 0)
                {
                    MarketProductGroup productGroup = await _context.MarketProductGroup.FindAsync(marketProductGroupDetails.First().Id);
                    marketProduct.marketProductGroup = productGroup;
                }
            }
            return marketProductList;
        }

        // GET: api/MarketProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProduct>> GetMarketProduct(long id)
        {
            var marketProduct = await _context.MarketProduct.FindAsync(id);

            if (marketProduct == null)
            {
                return NotFound();
            }


            return marketProduct;
        }

        [HttpGet("getMarketProductForMarket")]
        public async Task<ActionResult<MarketProduct>> getMarketProductForMarket( [FromQuery]long marketProductId)
        {
            var marketProduct = await _context.MarketProduct.FindAsync(marketProductId);

            if (marketProduct == null)
            {
                return NotFound();
            }
            MarketUnitMeasurment measurment = await _context.MarketUnitMeasurment.FindAsync(marketProduct.MarketUnitMeasurmentId);
            marketProduct.marketUnitMeasurment = measurment;
            List<MarketProductGroupDetail> marketProductGroupDetails = await _context.MarketProductGroupDetail.Where( p => p.MarketProductId == marketProduct.Id).ToListAsync();
            if (marketProductGroupDetails != null && marketProductGroupDetails.Count > 0) {
                MarketProductGroup productGroup = await _context.MarketProductGroup.FindAsync(marketProductGroupDetails.First().MarketProductGroupId);
                marketProduct.marketProductGroup = productGroup;
            }
            return marketProduct;
        }

        // PUT: api/MarketProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketProduct(long id, MarketProduct marketProduct)
        {
            if (id != marketProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductExists(id))
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

        // POST: api/MarketProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketProduct>> PostMarketProduct(MarketProduct marketProduct)
        {

            _context.MarketProduct.Update(marketProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMarketProduct", new { id = marketProduct.Id }, marketProduct);
        }

        [HttpPost("addProductForMarket")]
        public async Task<ActionResult<MarketProduct>> addProductForMarket(MarketProduct marketProduct)
        {
            bool status = false;
            long marketProductGroupId = 0;
            if (marketProduct.Id == 0)
            {
                status = true;
                if (marketProduct.marketProductGroupId != null)
                {
                    marketProductGroupId = marketProduct.marketProductGroupId ?? default(long);
                }

            }
            else {
                
                if (marketProduct.marketProductGroupId != null) {
                    status = true;
                    List<MarketProductGroupDetail> groupDetailList = await _context.MarketProductGroupDetail.Where(p => p.MarketProductGroupId == marketProduct.marketProductGroupId && p.MarketProductId == marketProduct.Id).ToListAsync();
                    if (groupDetailList != null && groupDetailList.Count > 0) {
                        _context.MarketProductGroupDetail.RemoveRange(groupDetailList);
                        await _context.SaveChangesAsync();
                    }

                    marketProductGroupId = marketProduct.marketProductGroupId ?? default(long);

                }


            }


            /*NEED TO CHECK IMAGE EXITS OR NOT AND NEED TO UPDATE*/
            marketProduct.Image = saveImageToFolder(marketProduct.Image);



            _context.MarketProduct.Update(marketProduct);
            await _context.SaveChangesAsync();
            if (status == true && marketProductGroupId != 0) {
                MarketProductGroupDetail groupDetail = new MarketProductGroupDetail();
                groupDetail.ActiveStatus = true;
                groupDetail.MarketProductGroupId = marketProductGroupId;
                groupDetail.MarketProductId = marketProduct.Id;
                _context.MarketProductGroupDetail.Update(groupDetail);
                await _context.SaveChangesAsync();
            
            }


            return CreatedAtAction("GetMarketProduct", new { id = marketProduct.Id }, marketProduct);
        }

        // DELETE: api/MarketProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketProduct>> DeleteMarketProduct(long id)
        {
            var marketProduct = await _context.MarketProduct.FindAsync(id);
            if (marketProduct == null)
            {
                return NotFound();
            }

            _context.MarketProduct.Remove(marketProduct);
            await _context.SaveChangesAsync();

            return marketProduct;
        }

        private bool MarketProductExists(long id)
        {
            return _context.MarketProduct.Any(e => e.Id == id);
        }

        private  String saveImageToFolder(String imageBase64Str) {
            if (imageBase64Str == null || imageBase64Str.Trim().Length  == 0) {
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
                    try {
                        Bitmap imgbitmap = new Bitmap(image);
                        Image resizedImage = (Image)(new Bitmap(imgbitmap, new Size(200,200)));
                        resizedImage.Save(PathWithFolderName + "/" + file_name_img + ".jpg", ImageFormat.Jpeg);
                    }
                    catch (Exception ) {
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
