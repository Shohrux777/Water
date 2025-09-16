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
    public class OquvMarkazInvoiceController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazInvoiceController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazInvoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazInvoice>>> GetOquvMarkazInvoice()
        {
            return await _context.OquvMarkazInvoice.ToListAsync();
        }

        // GET: api/OquvMarkazInvoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazInvoice>> GetOquvMarkazInvoice(long id)
        {
            var oquvMarkazInvoice = await _context.OquvMarkazInvoice.FindAsync(id);

            if (oquvMarkazInvoice == null)
            {
                return NotFound();
            }

            return oquvMarkazInvoice;
        }


        [HttpGet("getAcceptedInvoiceOrReturnBack")]
        public async Task<ActionResult<OquvMarkazInvoice>> getAcceptedInvoiceOrReturnBack([FromQuery] long invoice_id,[FromQuery] bool accepted_status)
        {
            var oquvMarkazInvoice = await _context.OquvMarkazInvoice
                .Include(p =>p.item)
                .Where(p => p.id == invoice_id).ToListAsync();

            if (oquvMarkazInvoice == null || oquvMarkazInvoice.Count == 0)
            {
                return NotFound();
            }

            if (oquvMarkazInvoice.First().inv_accepted_status == accepted_status) {
                return NotFound("Please, update page");
            }

            List<OquvMarkazOstatka> ostatka_list = new List<OquvMarkazOstatka>();
            if (accepted_status)
            {
                foreach (OquvMarkazInvoiceItem item in oquvMarkazInvoice.First().item)
                {
                    List<OquvMarkazOstatka> oquvMarkazOstatkas = await _context.OquvMarkazOstatka.Where(p => p.OquvMarkazProductid == item.OquvMarkazProductid).ToListAsync();
                    if (oquvMarkazOstatkas == null || oquvMarkazOstatkas.Count == 0)
                    {
                        OquvMarkazOstatka ostatka = new OquvMarkazOstatka();
                        ostatka.active_status = true;
                        ostatka.OquvMarkazProductid = item.OquvMarkazProductid;
                        ostatka.qty = item.qty;
                        ostatka.real_qty = item.qty;
                        ostatka_list.Add(ostatka);

                    }
                    else
                    {
                        oquvMarkazOstatkas.First().qty = oquvMarkazOstatkas.First().qty + item.qty;
                        oquvMarkazOstatkas.First().real_qty = oquvMarkazOstatkas.First().real_qty + item.qty;
                        ostatka_list.Add(oquvMarkazOstatkas.First());
                    }

                }
            }
            else {
                foreach (OquvMarkazInvoiceItem item in oquvMarkazInvoice.First().item)
                {
                    List<OquvMarkazOstatka> oquvMarkazOstatkas = await _context.OquvMarkazOstatka.Where(p => p.OquvMarkazProductid == item.OquvMarkazProductid).ToListAsync();
                    if (oquvMarkazOstatkas == null || oquvMarkazOstatkas.Count == 0)
                    {
                        OquvMarkazOstatka ostatka = new OquvMarkazOstatka();
                        ostatka.active_status = true;
                        ostatka.OquvMarkazProductid = item.OquvMarkazProductid;
                        ostatka.qty = -item.qty;
                        ostatka.real_qty = -item.qty;
                        ostatka_list.Add(ostatka);

                    }
                    else
                    {
                        oquvMarkazOstatkas.First().qty = oquvMarkazOstatkas.First().qty - item.qty;
                        oquvMarkazOstatkas.First().real_qty = oquvMarkazOstatkas.First().real_qty - item.qty;
                        ostatka_list.Add(oquvMarkazOstatkas.First());
                    }

                }


            }

            
            _context.OquvMarkazOstatka.UpdateRange(ostatka_list);
            await _context.SaveChangesAsync();

            oquvMarkazInvoice.First().inv_accepted_status = accepted_status;
            _context.OquvMarkazInvoice.Update(oquvMarkazInvoice.First());
            await _context.SaveChangesAsync();

            return oquvMarkazInvoice.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazInvoice> categoryList = await _context.OquvMarkazInvoice.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazInvoice.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationNotAccepted")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotAccepted([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazInvoice> categoryList = await _context.OquvMarkazInvoice.Where(p => p.active_status == true && p.inv_accepted_status == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazInvoice.Where(p => p.active_status == true && p.inv_accepted_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }



        // PUT: api/OquvMarkazInvoice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazInvoice(long id, OquvMarkazInvoice oquvMarkazInvoice)
        {
            if (id != oquvMarkazInvoice.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazInvoiceExists(id))
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

        // POST: api/OquvMarkazInvoice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazInvoice>> PostOquvMarkazInvoice(OquvMarkazInvoice oquvMarkazInvoice)
        {
            _context.OquvMarkazInvoice.Update(oquvMarkazInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazInvoice", new { id = oquvMarkazInvoice.id }, oquvMarkazInvoice);
        }

        // DELETE: api/OquvMarkazInvoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazInvoice>> DeleteOquvMarkazInvoice(long id)
        {
            var oquvMarkazInvoice = await _context.OquvMarkazInvoice.FindAsync(id);
            if (oquvMarkazInvoice == null)
            {
                return NotFound();
            }

            _context.OquvMarkazInvoice.Remove(oquvMarkazInvoice);
            await _context.SaveChangesAsync();

            return oquvMarkazInvoice;
        }

        private bool OquvMarkazInvoiceExists(long id)
        {
            return _context.OquvMarkazInvoice.Any(e => e.id == id);
        }
    }
}
