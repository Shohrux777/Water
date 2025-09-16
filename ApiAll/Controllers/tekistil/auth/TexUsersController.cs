using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexUsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexUsersController(ApplicationContext context)
        {
            _context = context;
   
        }

        // GET: api/TexUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexUser>>> GetTexUser()
        {
            return await _context.TexUser.Include(p => p.department).Include(p => p.position).OrderByDescending(p => p.id).ToListAsync();
        }

        [HttpGet("geUserInfoById")]
        public async Task<ActionResult<TexUser>> geUserInfoById([FromQuery] long user_id)
        {
            List<TexUser> texUserList =  await _context.TexUser.Where( p => p.id == user_id).Include(p => p.department).Include(p => p.position).OrderByDescending(p => p.id).ToListAsync();
            if (texUserList == null || texUserList.Count == 0) {
                return NotFound("User not found");
            }
            TexUser user = texUserList.First();
            List<TexAuthorization> texAuthorizationList = await _context.TexAuthorization.Where(p => p.user_id == user.id).ToListAsync();
            if (texAuthorizationList != null && texAuthorizationList.Count > 0) {
                user.authorization = texAuthorizationList.First();
            }
            
            return user;

        }

        [HttpGet("getUserByLimitCount")]
        public async Task<ActionResult<IEnumerable<TexUser>>> getUserByLimitCount([FromQuery] int resultCount)
        {
            return await _context.TexUser.Include(p => p.department).Include(p => p.position).OrderByDescending(p => p.id).Take(resultCount).ToListAsync();
        }

        [HttpGet("searchuserByFio")]
        public async Task<ActionResult<IEnumerable<TexUser>>> searchuserByFio([FromQuery] String FIO, [FromQuery]int countResult)
        {
            List<TexUser> usersList =  await _context.TexUser.Include(p => p.department).Include( p =>p.position).Where(p => p.fio.ToLower().Contains(FIO.ToLower())).OrderByDescending(p => p.id).Take(countResult).ToListAsync();
           
            if(usersList != null)
            {
                foreach (TexUser user in usersList)
                {
                    List<TexAuthorization> texAuthorizationList = await _context.TexAuthorization.Where(p => p.user_id == user.id).ToListAsync();
                    if (texAuthorizationList != null && texAuthorizationList.Count > 0)
                    {
                        user.authorization = texAuthorizationList.First();
                        user.auth_id_ex = user.authorization.id; 
                    }

                }

            }

            return usersList;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<IEnumerable<TexUser>>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            return await _context.TexUser.Include(p => p.department).Include(p => p.position).OrderByDescending(p => p.id).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        // GET: api/TexUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexUser>> GetTexUser(long id)
        {
            var texUser = await _context.TexUser.FindAsync(id);

            if (texUser == null)
            {
                return NotFound();
            }

            return texUser;
        }

        // PUT: api/TexUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexUser(long id, TexUser texUser)
        {
            if (id != texUser.id)
            {
                return BadRequest();
            }

            _context.Entry(texUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexUserExists(id))
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

        // POST: api/TexUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        [HttpPost("addUserWithAuth")]
        public async Task<ActionResult<TexUser>> addUserWithAuth(TexUser texUser)
        {
 
            try
            {
                if (!texUser.image.Contains("images")) {

                    texUser.image = saveImageToFolder(texUser.image);
                }
                
                _context.TexUser.Update(texUser);
                await _context.SaveChangesAsync();
                if (texUser.authorization !=null) {
                    TexAuthorization authorization = texUser.authorization;
                    authorization.active_status = true;
                    authorization.user_id = texUser.id;
                    TexDepartment department = await _context.TexDepartment.FindAsync(texUser.department_id);
                    authorization.company_id = department.company_id;
                    _context.TexAuthorization.Update(authorization);
                    await _context.SaveChangesAsync();

                }


                return texUser;
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TexUser>> PostTexUser(TexUser texUser)
        {
            try
            {
                texUser.image = saveImageToFolder(texUser.image);
                if (texUser.authorization  != null) {
                    _context.TexAuthorization.Update(texUser.authorization);
                    await _context.SaveChangesAsync();
                }
                _context.TexUser.Update(texUser);
                await _context.SaveChangesAsync();
                return texUser;
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }

        // DELETE: api/TexUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexUser>> DeleteTexUser(long id)
        {
            var texUser = await _context.TexUser.FindAsync(id);
            if (texUser == null)
            {
                return NotFound();
            }

            _context.TexUser.Remove(texUser);
            await _context.SaveChangesAsync();

            return texUser;
        }

        private bool TexUserExists(long id)
        {
            return _context.TexUser.Any(e => e.id == id);
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
