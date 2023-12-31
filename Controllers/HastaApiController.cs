using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webProjeOdev8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaApiController : ControllerBase
    {
        private HastaneRandevuContext _context = new HastaneRandevuContext();

        // GET: api/<HastaApiController>
        [HttpGet]
        public List<Hasta> Get()
        {
            var hastalar = _context.Hastalar.ToList();
            return hastalar;
        }

        // GET api/<HastaApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Hasta> Get(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var hasta = _context.Hastalar.FirstOrDefault(h => h.hastaId == id);
            if (hasta == null)
            {
                return NotFound();
            }
            return hasta;
        }

        // POST api/<HastaApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Hasta h)
        {
            _context.Hastalar.Add(h);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<HastaApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] Hasta h)
        {

            if (id is null)
            {
                return NotFound();
            }
            var hasta = _context.Hastalar.FirstOrDefault(h => h.hastaId == id);
            if (hasta == null)
            {
                return NotFound();
            }
            hasta.hastaAdi = h.hastaAdi;
            hasta.hastaSoyadi = h.hastaSoyadi;
            _context.Update(hasta);
            _context.SaveChanges();
            return Ok(hasta);
        }

        // DELETE api/<HastaApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            
            if (id is null)
            {
                return NotFound();
            }
            var hasta = _context.Hastalar.Include(x => x.Randevular).FirstOrDefault(h => h.hastaId == id);
            if (hasta == null)
            {
                return NotFound();
            }
            if (hasta.Randevular.Count() > 0)
            {
                return BadRequest("Hastanın randevuları var.");
            }
            _context.Hastalar.Remove(hasta);
            _context.SaveChanges();
            return Ok(hasta);

        }
    }
}


