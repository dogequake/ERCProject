using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERCApi.Models;

namespace ERCApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LcsController : ControllerBase
    {
        private readonly Test_dbContext _context;

        public LcsController(Test_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lc>>> Get()
        {
            var result = await _context.Lcs.ToListAsync();
            return result;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lc>> Get(int id)
        {
            Lc lc = await _context.Lcs.Include(x => x.Resident).FirstOrDefaultAsync(x => x.Id == id);
            if (lc == null)
                return NotFound();
            return new ObjectResult(lc);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Lc>> Post(Lc lc)
        {
            if (lc == null)
            {
                return BadRequest();
            }

            _context.Lcs.Add(lc);
            await _context.SaveChangesAsync();
            return Ok(lc);
        }

        // PUT api/users/
        [HttpPut("{id}")]
        public async Task<ActionResult<Lc>> Put(int id, Lc lc)
        {
            if (id != lc.Id)
            {
                return BadRequest();
            }


            _context.Entry(lc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lc>> DeleteConf(int id)
        {
            Lc lc = _context.Lcs.FirstOrDefault(x => x.Id == id);
            if (lc == null)
            {
                return NotFound();
            }
            _context.Lcs.Remove(lc);
            await _context.SaveChangesAsync();
            return Ok(lc);
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Lc>>> FindWithResident()
        //{
        //    var result = await _context.Lcs.Where(p => p.ResidentId != null).ToListAsync();

        //    return result;
        //}

        private bool ClientExists(int id)
        {
            return _context.Lcs.Any(e => e.Id == id);
        }
    }
}
