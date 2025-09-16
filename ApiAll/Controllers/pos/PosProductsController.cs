using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosProductsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosProduct>>> GetPosProduct()
        {
            return await _context.PosProduct.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProduct> itemList = await _context.PosProduct
                .Where(p => p.active_status == true && p.main_product_id == null)
                .Include(p => p.measurment)
                .Include(p => p.category)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosProduct>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosProduct
                .Where(p => p.active_status == true && p.main_product_id == null).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosProduct>> GetPosProduct(long id)
        {
            var posProduct = await _context.PosProduct
                .Where(p => p.id == id)
                .Include(p => p.category)
                .Include(p => p.measurment)
                .Include(p => p.brend)
                .ToListAsync();
            
            if (posProduct == null || posProduct.Count == 0)
            {
                return NotFound();
            }

            posProduct.First().barcodeList = await _context.PosProductCode.Where(p => p.product_id == posProduct.First().id).ToListAsync();
            List<PosProduct> subProductList = await _context.PosProduct
                .Include(p =>p.category)
                .Include(p => p.measurment)
                .Where(p => p.main_product_id == id).OrderByDescending(p => p.id).ToListAsync();
                posProduct.First().subProductList = subProductList;

            //get batcode list
            if (subProductList != null && subProductList.Count > 0) {
                foreach (PosProduct item in subProductList) {
                    item.barcodeList = await _context.PosProductCode.Where(p => p.product_id == item.id).ToListAsync();
                }

            }


                List<PosRecipe> recipeList = await _context.PosRecipe
                .Where(p => p.product_id == id)
                .Include( p => p.recipeProduct)
                .ToListAsync();
            posProduct.First().posProductRecipeList = recipeList;
            return posProduct.First();
        }

        [HttpGet("checkProductByBarcode")]
        public async Task<ActionResult<PosProduct>> checkProductByBarcode([FromQuery] String barcode)
        {
            var posProduct = await _context.PosProduct
                .Where(p => p.barcode == barcode)
                .Include(p => p.category)
                .Include(p => p.measurment)
                .Include(p => p.brend)
                .ToListAsync();

            if (posProduct == null || posProduct.Count == 0)
            {
                List<PosProductCode> productCodeList = await _context.PosProductCode
                    .Include(p => p.product)
                    .Where(p => p.barcode == barcode).ToListAsync();
                if (productCodeList == null || productCodeList.Count == 0)
                {
                    return NotFound("PRODUCT NOT FOUND");
                }

                return productCodeList.First().product;
            }


            return posProduct.First();
        }




        [HttpGet("checkProductByBarcodeForSale")]
        public async Task<ActionResult<PosProductPrice>> checkProductByBarcodeForSale([FromQuery] String barcode)
        {
            long? product_id = null;
            var posProduct = await _context.PosProduct
                .Where(p => p.barcode == barcode)
                .Include(p => p.category)
                .Include(p => p.measurment)
                .Include(p => p.brend)
                .ToListAsync();

            if (posProduct == null || posProduct.Count == 0)
            {
                List<PosProductCode> productCodeList = await _context.PosProductCode
                    .Include(p => p.product)
                    .Where(p => p.barcode == barcode).ToListAsync();
                if (productCodeList != null && productCodeList.Count > 0)
                {
                    product_id = productCodeList.First().product_id;
                }
            }

            if (posProduct != null && posProduct.Count > 0)
            {
                product_id = posProduct.First().id;
            }

            if (product_id != null)
            {
                var price = await _context.PosProductPrice
                     .Include(p => p.product)
                     .Where(p => p.product_id == product_id).ToListAsync();
                if (price != null && price.Count > 0)
                {
                    return price.First();
                }
            }

            return NotFound("Product not found");

        }

        [HttpGet("checkProductByIdForSale")]
        public async Task<ActionResult<PosProductPrice>> checkProductByIdForSale([FromQuery] long product_id)
        {
                var price = await _context.PosProductPrice
                .Include(p => p.product)
                .Where(p => p.product_id ==product_id).ToListAsync();
                if (price != null && price.Count > 0) {
                    return price.First();
                }
            return NotFound("Product not found");
                 
        }


        [HttpGet("checkProductByName")]
        public async Task<ActionResult<PosProduct>> checkProductByName([FromQuery] String name)
        {
            var posProduct = await _context.PosProduct
                .Where(p => p.name.ToLower().Contains(name.ToLower()))
                .Include(p => p.category)
                .Include(p => p.measurment)
                .Include(p => p.brend)
                .OrderByDescending(p => p.id).Take(20)
                .ToListAsync();
            return posProduct.First();
        }

        [HttpGet("checkProductByNameList")]
        public async Task<ActionResult<IEnumerable<PosProduct>>> checkProductByNameList([FromQuery] String name)
        {
            var posProduct = await _context.PosProduct
                .Where(p => p.name.ToLower().Contains(name.ToLower()))
                .Include(p => p.category)
                .Include(p => p.measurment)
                .Include(p => p.brend)
                .OrderByDescending(p => p.id).Take(20)
                .ToListAsync();
            return posProduct;
        }

        // PUT: api/PosProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosProduct(long id, PosProduct posProduct)
        {
            if (id != posProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(posProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosProductExists(id))
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

        // POST: api/PosProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosProduct>> PostPosProduct(PosProduct posProduct)
        {
            try
            {
                List<PosProduct> subProductList = posProduct.subProductList;
                List<PosRecipe> productRecipeList = posProduct.posProductRecipeList;
                if (posProduct.image != null && posProduct.image.Contains(".jpg")) {
                    posProduct.image = posProduct.image;

                }
                else {
                    posProduct.image = saveImageToFolder(posProduct.image);
                }
               
                if (subProductList != null && subProductList.Count > 0)
                {
                    posProduct.name = posProduct.name + subProductList.First().name;
                    posProduct.buyed_price = subProductList.First().buyed_price;
                    posProduct.price = subProductList.First().price;
                    posProduct.code = subProductList.First().code;
                    posProduct.percentage = subProductList.First().percentage;
                    posProduct.barcode = subProductList.First().barcode;
                }
                
                _context.PosProduct.Update(posProduct);
                await _context.SaveChangesAsync();
                if (subProductList != null && subProductList.Count > 0)
                {
                    List<PosProductCode> posProductCodeList = subProductList.First().barcodeList;
                    if (posProductCodeList != null && posProductCodeList.Count > 0) {
                        foreach (PosProductCode item_code in posProductCodeList) {
                            item_code.product_id = posProduct.id;
                            item_code.active_status = true;
                            
                                
                            bool checkBarcodeStatus = await checkBarcode(item_code.barcode, posProduct.id);
                            if (checkBarcodeStatus)
                            {
                                _context.PosProductCode.Update(item_code);
                                await _context.SaveChangesAsync();
                            }
                        }

                    }

                    subProductList.RemoveAt(0);
                }

                //sub productlarini qoshish
                if (subProductList != null)
                {
                    foreach (PosProduct item in subProductList)
                    {
                        
                        item.active_status = true;
                        item.main_product_id = posProduct.id;
                        item.image = saveImageToFolder(posProduct.image);
                        if (posProduct.image != null && posProduct.image.Contains(".jpg"))
                        {
                            item.image = posProduct.image;

                        }
                        else
                        {
                            item.image = saveImageToFolder(posProduct.image);
                        }
                        item.brend_id = posProduct.brend_id;
                        item.category_id = posProduct.category_id;
                        item.unitmeasurment_id = posProduct.unitmeasurment_id;
                    }

                    _context.PosProduct.UpdateRange(subProductList);
                    await _context.SaveChangesAsync();

                    foreach (PosProduct item_sub in subProductList)
                    {
                        List<PosProductCode> posProductCodeListSub = item_sub.barcodeList;
                        if (posProductCodeListSub != null && posProductCodeListSub.Count > 0)
                        {
                            foreach (PosProductCode item_code_sub in posProductCodeListSub)
                            {
                                item_code_sub.product_id = item_sub.id;
                                 bool checkBarcodeStatus = await checkBarcode(item_code_sub.barcode, item_sub.id);
                                 if (checkBarcodeStatus) {
                                    _context.PosProductCode.Update(item_code_sub);
                                    await _context.SaveChangesAsync();
                                }
                            }


                        }



                    }

                    //ketadigon receplarni qoshish

                    if (productRecipeList != null)
                    {
                        foreach (PosRecipe res_item in productRecipeList)
                        {
                            res_item.product_id = posProduct.id;
                        }
                        _context.PosRecipe.UpdateRange(productRecipeList);
                        await _context.SaveChangesAsync();
                    }

                }
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return CreatedAtAction("GetPosProduct", new { id = posProduct.id }, posProduct);
        }

        // DELETE: api/PosProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosProduct>> DeletePosProduct(long id)
        {
            var posProduct = await _context.PosProduct.FindAsync(id);
            if (posProduct == null)
            {
                return NotFound();
            }

            _context.PosProduct.Remove(posProduct);
            await _context.SaveChangesAsync();

            return posProduct;
        }

       
        private async Task<bool> checkBarcode(String barcode_str,long productId)
        {
            var posProductCodeList = await _context.PosProductCode.Where(p => p.barcode == barcode_str).ToListAsync();
            if (posProductCodeList == null || posProductCodeList.Count == 0)
            {
                return true;
            }
            return false;
        }

        private bool PosProductExists(long id)
        {
            return _context.PosProduct.Any(e => e.id == id);
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
