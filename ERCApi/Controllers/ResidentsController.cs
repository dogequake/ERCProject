using ERCApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentsController : ControllerBase
    {
        private readonly Test_dbContext _context;

        public ResidentsController(Test_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> Get()
        {
            return await _context.Residents.Include(x => x.Lcs).ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> Get(int id)
        {
            Resident resident = await _context.Residents.FirstOrDefaultAsync(x => x.Id == id);
            if (resident == null)
                return NotFound();
            return new ObjectResult(resident);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Resident>> Post(Resident resident)
        {
            if (resident == null)
            {
                return BadRequest();
            }

            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();
            return Ok(resident);
        }

        // PUT api/users/
        [HttpPut("{id}")]
        public async Task<ActionResult<Resident>> Put(Resident resident)
        {
            if (resident == null)
            {
                return BadRequest();
            }
            if (!_context.Residents.Any(x => x.Id == resident.Id))
            {
                return NotFound();
            }

            _context.Update(resident);
            await _context.SaveChangesAsync();
            return Ok(resident);
        }

        // DELETE api/users/5


        //public async Task<ActionResult<Resident>> Delete(int id)
        //{
        //    Resident resident = _context.Residents.FirstOrDefault(x => x.Id == id);
        //    if (resident == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Residents.Remove(resident);
        //    await _context.SaveChangesAsync();
        //    return Ok(resident);
        //}
    }
}
