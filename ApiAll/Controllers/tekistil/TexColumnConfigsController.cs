using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexColumnConfigsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColumnConfigsController(ApplicationContext context)
        {
            _context = context;
           
        }


        // GET: api/TexColumnConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColumnConfig>>> GetTexColumnConfig()
        {
           
           // authorizationService.getColumnConfig("");
 

            return await _context.TexColumnConfig.ToListAsync();
        }

        [HttpGet("getAllTableNamesList")]
        public async Task<ActionResult<IEnumerable<TexColumnConfigRaw>>> getAllTableNamesList()
        {
           List<TexColumnConfigRaw>  tableNamesList = await _context.TexColumnConfigRaw.FromSqlRaw("SELECT table_name as column_name FROM information_schema.tables WHERE table_schema='public' AND table_type='BASE TABLE';").ToListAsync();
            List<string> customTableList = new List<string>();
            customTableList.Add("tex_buy_invoice_list");
            customTableList.Add("tex_sale_invoice_list");
            customTableList.Add("tex_movement_invoice_list");
            customTableList.Add("tex_simple_production_invoice_list");
            customTableList.Add("tex_for_service_invoice_list");
            customTableList.Add("tex_buy_invoice");
            customTableList.Add("tex_sale_invoice");
            customTableList.Add("tex_movement_invoice");
            customTableList.Add("tex_simple_production_invoice");
            customTableList.Add("tex_for_service_invoice");
            customTableList.Add("tex_ostatka");
            foreach (string itm  in customTableList) {
                TexColumnConfigRaw texColumn = new TexColumnConfigRaw();
                texColumn.column_name = itm;
                tableNamesList.Add(texColumn);


            }
            
            return tableNamesList;
        }

        [HttpGet("getColumnListAsJsonObj")]
        public async Task<ActionResult<TexColumnConfig>> getColumnListAsJsonObj([FromQuery] String tableName,[FromQuery] long auth_id)
        {

            List<TexColumnConfig> texColumnList = await _context.TexColumnConfig.Where(p => p.table_name == tableName && p.auth_id == auth_id).ToListAsync();
            if (texColumnList != null && texColumnList.Count > 0) {
                TexColumnConfig texColumnConfig = texColumnList.First();
                texColumnConfig.column_default_obj =  JsonConvert.DeserializeObject<JArray>(string.IsNullOrEmpty(texColumnConfig.columns) ? "[]" : texColumnConfig.columns);
                return texColumnConfig;
            }

            TexColumnConfig columnConfig = new TexColumnConfig();
            columnConfig.active_status = true;
            List<TexColumnConfigRaw> column_config_raw = await _context.TexColumnConfigRaw.FromSqlRaw("" +
                " SELECT column_name "+
                " FROM information_schema.columns "+
                " WHERE"+
                " table_name = '"+ tableName + "'").ToListAsync();
            JArray arr = new JArray();
            foreach (TexColumnConfigRaw configRaw in column_config_raw) {
                if (!configRaw.column_name.Trim().Contains("_id")) {
                    if (tableName.Equals("tex_order_item")) {
                        if (configRaw.column_name.Trim().Contains("_date_time")) {
                            continue;
                        }
                    }

                    if (tableName.Contains("pos_"))
                    {
                        if (configRaw.column_name.Trim().Contains("created_date_time"))
                        {
                            continue;
                        }
                        if (configRaw.column_name.Trim().Contains("updated_date_time"))
                        {
                            continue;
                        }
                        if (configRaw.column_name.Trim().Contains("active_status"))
                        {
                            continue;
                        }
                        if (configRaw.column_name.Trim().Contains("id"))
                        {
                            continue;
                        }

                        if (configRaw.column_name.Trim().Contains("credit_sum"))
                        {
                            continue;
                        }

                        if (configRaw.column_name.Trim().Contains("debit_summ"))
                        {
                            continue;
                        }
                    }



                    JObject obj = new JObject();
                    obj.Add("name", configRaw.column_name);
                    obj.Add("status", true);
                    obj.Add("length", 100);
                    arr.Add(obj);
                }
            }
            List<String> columns_product  = new List<string>();
            //product
            if (tableName.Equals("tex_product")) {
                columns_product.Add("unitmeasurment_name");
                columns_product.Add("unitmeasurment_2_name");
                columns_product.Add("production_type_name");
            }
            else if (tableName.Equals("tex_ostatka"))
            {
                columns_product.Add("invoice_item_id");
                columns_product.Add("product_name");
                columns_product.Add("product_id");
                columns_product.Add("ostatka");
                columns_product.Add("color_name");
                columns_product.Add("unitmeasurment_name");
                columns_product.Add("price");
                columns_product.Add("suroviy_vid_name");
                columns_product.Add("real_product_name");
                columns_product.Add("date_str");
                columns_product.Add("guscolor_name");
                columns_product.Add("extra_work_name");
                columns_product.Add("main_proccess_name");
                columns_product.Add("upakovka_name");
                columns_product.Add("sort_name");
                columns_product.Add("name");
            }
            //category
            else if (tableName.Equals("tex_authorization")) {
                columns_product.Add("user_name");
                columns_product.Add("company_name");
            }
            //category
            else if (tableName.Equals("tex_category")) {
                columns_product.Add("product_type_name");
                columns_product.Add("measurment_type_name");

            } else if (tableName.Equals("tex_order")) {
                columns_product.Add("client_name");
                columns_product.Add("company_name");
                columns_product.Add("department_name");
                columns_product.Add("valyuta_name");

            }
            else if (tableName.Equals("tex_buy_invoice"))
            {
                arr.Clear();
                columns_product.Add("product_name_real");
                columns_product.Add("qty");
                columns_product.Add("ostatka");
                columns_product.Add("unitmeasurment_name");
                columns_product.Add("price");
                columns_product.Add("fein");
                columns_product.Add("pus");
                columns_product.Add("shirina");
                columns_product.Add("grammaj");
                columns_product.Add("metraj");
                columns_product.Add("qty2");
                columns_product.Add("color_name_real");
                columns_product.Add("colorvariant_name");
                columns_product.Add("guscolor_name");
                columns_product.Add("surovid_vid_name");
                columns_product.Add("note");
                columns_product.Add("main_proccess_name_real");
                columns_product.Add("extrawork_name");
                columns_product.Add("brak");
                columns_product.Add("sort_name");
                columns_product.Add("ugar");
                columns_product.Add("brutto");
                columns_product.Add("netto");
                columns_product.Add("upakovka_name_real");


            } else if (tableName.Equals("tex_sale_invoice")) {
                arr.Clear();
                columns_product.Add("product_name_real");
                columns_product.Add("qty");
                columns_product.Add("ostatka");
                columns_product.Add("unitmeasurment_name");
                columns_product.Add("price");
                columns_product.Add("fein");
                columns_product.Add("pus");
                columns_product.Add("shirina");
                columns_product.Add("grammaj");
                columns_product.Add("metraj");
                columns_product.Add("qty2");
                columns_product.Add("color_name_real");
                columns_product.Add("colorvariant_name");
                columns_product.Add("guscolor_name");
                columns_product.Add("surovid_vid_name");
                columns_product.Add("note");
                columns_product.Add("main_proccess_name_real");
                columns_product.Add("extrawork_name");
                columns_product.Add("brak");
                columns_product.Add("sort_name");
                columns_product.Add("ugar");
                columns_product.Add("brutto");
                columns_product.Add("netto");
                columns_product.Add("upakovka_name_real");

            } else if (tableName.Equals("tex_movement_invoice")) {

            } else if (tableName.Equals("tex_simple_production_invoice")) {

            }
            else if (tableName.Equals("tex_for_service_invoice")) {

            }
            else if (tableName.Equals("tex_buy_invoice_list") || tableName.Equals("tex_sale_invoice_list") || tableName.Equals("tex_movement_invoice_list") || tableName.Equals("tex_simple_production_invoice_list") || tableName.Equals("tex_for_service_invoice_list"))
            {
                arr.Clear();
                column_config_raw = await _context.TexColumnConfigRaw.FromSqlRaw("" +
                " SELECT column_name " +
                " FROM information_schema.columns " +
                " WHERE" +
                " table_name = 'tex_invoice' ").ToListAsync();
                foreach (TexColumnConfigRaw configRaw in column_config_raw)
                {
                    if (!configRaw.column_name.Trim().Contains("_id"))
                    {
                        if (tableName.Equals("tex_order_item"))
                        {
                            if (configRaw.column_name.Trim().Contains("_date_time"))
                            {
                                continue;
                            }
                        }
                        JObject obj = new JObject();
                        obj.Add("name", configRaw.column_name);
                        obj.Add("status", true);
                        obj.Add("length", 100);
                        arr.Add(obj);
                    }
                }

                columns_product.Add("order_number");
                columns_product.Add("company_name");
                columns_product.Add("valyuta_name");
                columns_product.Add("sklad_name");
                columns_product.Add("filial_name");
                columns_product.Add("paymen_type_name");
                columns_product.Add("department_name");
                columns_product.Add("calctype_name");
                columns_product.Add("invoice_type_name");
                columns_product.Add("main_sklad_name");
                columns_product.Add("main_department_name");
                columns_product.Add("main_company_name");
                columns_product.Add("precentage");

            } else if (tableName.Equals("tex_batch")) {
                arr.Clear();
                columns_product.Add("color_name");
                columns_product.Add("guscolor_name");
                columns_product.Add("colorvariant_name");
                columns_product.Add("device_name");
                columns_product.Add("order_number");
                columns_product.Add("begin_date");
                columns_product.Add("end_date");
            } else if (tableName.Equals("tex_order_item")) {
                arr.Clear();

                columns_product.Add("id");
                columns_product.Add("production_type_name");
                columns_product.Add("service_type_name");
                columns_product.Add("product_name");
                columns_product.Add("qty");
                columns_product.Add("unitmeasurment_name");
                columns_product.Add("price");
                columns_product.Add("summa");
                columns_product.Add("color_name");
                columns_product.Add("guscolor_name");
                columns_product.Add("colorvariant_name");
                columns_product.Add("main_prosses_name");
                columns_product.Add("extrawork_name");
                columns_product.Add("extrawork_price");
                columns_product.Add("trb_grm_ot");
                columns_product.Add("trb_grm_do");
                columns_product.Add("trb_shir_ot");
                columns_product.Add("trb_shir_do");
                columns_product.Add("note");
                columns_product.Add("pus");
                columns_product.Add("fein");
                columns_product.Add("paket");
                columns_product.Add("shirina");
                columns_product.Add("gramm");
                columns_product.Add("metraj");
                columns_product.Add("artikul");
                columns_product.Add("ugar");
                columns_product.Add("suroviy_vid_name");
                columns_product.Add("lot");
                columns_product.Add("pantone_code");
                columns_product.Add("size_name");
                columns_product.Add("begin_date");
                columns_product.Add("end_date");
                //columns_product.Add("reserve");
                columns_product.Add("add_batch");
                //columns_product.Add("order_number");
            }


            foreach (String cl_name in columns_product)
            {
                JObject obj = new JObject();
                obj.Add("name", cl_name);
                obj.Add("status", true);
                obj.Add("length", 100);
                arr.Add(obj);
            }

            columnConfig.column_default_obj = arr;
            columnConfig.columns = JsonConvert.SerializeObject(arr);
            columnConfig.table_name = tableName;
            columnConfig.auth_id = auth_id;
            try
            {
                _context.TexColumnConfig.Update(columnConfig);
                await _context.SaveChangesAsync();
            }
            catch (Exception) {
                return columnConfig;
            }


            return columnConfig;
        }

        // GET: api/TexColumnConfigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColumnConfig>> GetTexColumnConfig(long id)
        {
            var texColumnConfig = await _context.TexColumnConfig.FindAsync(id);

            if (texColumnConfig == null)
            {
                return NotFound();
            }

            return texColumnConfig;
        }

        // PUT: api/TexColumnConfigs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColumnConfig(long id, TexColumnConfig texColumnConfig)
        {
            if (id != texColumnConfig.id)
            {
                return BadRequest();
            }

            _context.Entry(texColumnConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColumnConfigExists(id))
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

        // POST: api/TexColumnConfigs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        
        [HttpPost]
        public async Task<ActionResult<TexColumnConfig>> PostTexColumnConfig(TexColumnConfig texColumnConfig)
        {
            if (texColumnConfig.id > 0)
            {
                TexColumnConfig columnConfig = await _context.TexColumnConfig.FindAsync(texColumnConfig.id);
                columnConfig.columns = texColumnConfig.columns;
                _context.TexColumnConfig.Update(columnConfig);
                await _context.SaveChangesAsync();
            }
            else {
                List<TexColumnConfig> texColumnConfigList = await _context.TexColumnConfig.Where(p => p.table_name == texColumnConfig.table_name && p.auth_id == texColumnConfig.auth_id).ToListAsync();
                if (texColumnConfigList != null && texColumnConfigList.Count > 0) {
                    _context.TexColumnConfig.RemoveRange(texColumnConfigList);
                    await _context.SaveChangesAsync();
                }
                //removed all need to ad new one
                _context.TexColumnConfig.Update(texColumnConfig);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetTexColumnConfig", new { id = texColumnConfig.id }, texColumnConfig);
        }

        // DELETE: api/TexColumnConfigs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColumnConfig>> DeleteTexColumnConfig(long id)
        {
            var texColumnConfig = await _context.TexColumnConfig.FindAsync(id);
            if (texColumnConfig == null)
            {
                return NotFound();
            }

            _context.TexColumnConfig.Remove(texColumnConfig);
            await _context.SaveChangesAsync();

            return texColumnConfig;
        }

        private bool TexColumnConfigExists(long id)
        {
            return _context.TexColumnConfig.Any(e => e.id == id);
        }
    }
}
