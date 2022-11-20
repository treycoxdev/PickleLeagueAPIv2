using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickleLeaugev4.Data;
using PickleLeaugev4.Models;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaugeRunnerController : ControllerBase
    {

        private DataContext _context;

        public LeaugeRunnerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<LeaugeRunner>>> Get()
        {
            return Ok(await _context.LeaugeRunners.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaugeRunner>> Get(int id)
        {
            var LeaugeRunner = await _context.LeaugeRunners.FindAsync(id);
            if (LeaugeRunner == null)
            {
                return BadRequest("LeaugeRunner not found");
            }
            return Ok(LeaugeRunner);
        }


        [HttpPost]
        public async Task<ActionResult<List<LeaugeRunner>>> AddLeaugeRunner(LeaugeRunner LeaugeRunner)
        {
            _context.LeaugeRunners.Add(LeaugeRunner);
            await _context.SaveChangesAsync();
            return Ok(LeaugeRunner);
        }

        [HttpPut]
        public async Task<ActionResult<LeaugeRunner>> UpdateLeaugeRunner(LeaugeRunner request)
        {
            var LeaugeRunner = await _context.LeaugeRunners.FindAsync(request.LeaugeRunnerId);
            if (LeaugeRunner == null)
            {
                return BadRequest("LeaugeRunner not found");
            }
            if(request.Email != null)
            {

                LeaugeRunner.Email = request.Email;
            }
            if (request.FirstName != null)
            {
                LeaugeRunner.FirstName = request.FirstName;
            }
            if (request.LastName != null)
            {
                LeaugeRunner.LastName = request.LastName;
            }

            await _context.SaveChangesAsync();

            return Ok(LeaugeRunner);
        }

        [HttpDelete]
        public async Task<ActionResult<List<LeaugeRunner>>> Delete(int id)
        {
            var LeaugeRunner = await _context.LeaugeRunners.FindAsync(id);
            if (LeaugeRunner == null)
            {
                return BadRequest("LeaugeRunner not found");
            }
            _context.LeaugeRunners.Remove(LeaugeRunner);
            await _context.SaveChangesAsync();

            return Ok(LeaugeRunner);
        }
    }
}

