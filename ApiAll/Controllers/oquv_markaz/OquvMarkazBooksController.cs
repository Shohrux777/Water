using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazBooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazBooksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazBook>>> GetOquvMarkazBook()
        {
            return await _context.OquvMarkazBook.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBook> categoryList = await _context.OquvMarkazBook.Where(p => p.active_status == true)
               
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBook>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBook.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazBook>> GetOquvMarkazBook(long id)
        {
            var oquvMarkazBook = await _context.OquvMarkazBook.FindAsync(id);

            if (oquvMarkazBook == null)
            {
                return NotFound();
            }

            return oquvMarkazBook;
        }

        // PUT: api/OquvMarkazBooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazBook(long id, OquvMarkazBook oquvMarkazBook)
        {
            if (id != oquvMarkazBook.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazBookExists(id))
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

        // POST: api/OquvMarkazBooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazBook>> PostOquvMarkazBook(OquvMarkazBook oquvMarkazBook)
        {
            _context.OquvMarkazBook.Update(oquvMarkazBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazBook", new { id = oquvMarkazBook.id }, oquvMarkazBook);
        }

        // DELETE: api/OquvMarkazBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazBook>> DeleteOquvMarkazBook(long id)
        {
            var oquvMarkazBook = await _context.OquvMarkazBook.FindAsync(id);
            if (oquvMarkazBook == null)
            {
                return NotFound();
            }

            _context.OquvMarkazBook.Remove(oquvMarkazBook);
            await _context.SaveChangesAsync();

            return oquvMarkazBook;
        }

        private bool OquvMarkazBookExists(long id)
        {
            return _context.OquvMarkazBook.Any(e => e.id == id);
        }
    }
}
