using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PickleLeaugev4.Models;
using PickleLeaugev4.Data;
using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaugeController : ControllerBase
    {

        private DataContext _context;

        public LeaugeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Leauge>>> Get()
        {
            return Ok(await _context.Leauge.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leauge>> Get(int id)
        {
            var Leauge = await _context.Leauge.FindAsync(id);
            if (Leauge == null)
            {
                return BadRequest("Leauge not found");
            }
            return Ok(Leauge);
        }

        [HttpGet("LeagueRunner/{id}")]
        public async Task<ActionResult<Leauge>> GetByLeagueRunner(int id)
        {
            var Leauge = await (from L in _context.Leauge
                                 join LR in _context.LeaugeUnderLeaugeRunner on L.LeaugeId equals LR.LeaugeId
                                 where LR.LeagueRunnerId == id
                                 select L).ToListAsync();
            if (Leauge == null)
            {
                return BadRequest("Leauge not found");
            }
            return Ok(Leauge);
        }


        [HttpPost]
        public async Task<ActionResult<List<Leauge>>> AddLeauge(Leauge Leauge)
        {
            
            _context.Leauge.Add(Leauge);
            await _context.SaveChangesAsync();
            return Ok(Leauge);
        }

        [HttpPost("LeaugeWithRunnerId")]
        public async Task AddLeaugeWithRunner(LeaugeWithRunnerId LeaugeWithRunnerId)
        {
            Leauge Leauge = new Leauge();
            LeaugeUnderLeaugeRunner LeaugeUnderLeaugeRunner = new LeaugeUnderLeaugeRunner();

            Leauge.LeaugeName = LeaugeWithRunnerId.LeaugeName;
            Leauge.LeaugeStartDate = LeaugeWithRunnerId.LeaugeStartDate;
            Leauge.LeagueType = LeaugeWithRunnerId.LeagueType;
            _context.Leauge.Add(Leauge);
            await _context.SaveChangesAsync();

            int LeaugeId = Leauge.LeaugeId;

            LeaugeUnderLeaugeRunner.LeaugeId = LeaugeId;
            LeaugeUnderLeaugeRunner.LeagueRunnerId = LeaugeWithRunnerId.LeaugeRunnerId;
            _context.LeaugeUnderLeaugeRunner.Add(LeaugeUnderLeaugeRunner);
            await _context.SaveChangesAsync();

        }

        [HttpPost("LeaugeRunner")]
        public async Task<ActionResult<List<Leauge>>> AddLeaugeRunner(LeaugeUnderLeaugeRunner LeaugeUnderLeaugeRunner)
        {
            _context.LeaugeUnderLeaugeRunner.Add(LeaugeUnderLeaugeRunner);
            await _context.SaveChangesAsync();
            return Ok(LeaugeUnderLeaugeRunner);

        }

        [HttpGet("Session/{id}")]
        public async Task<ActionResult<Session>> GetSessiomsByLeague(int id)
        {
            var Sessions = await (from S in _context.Sessions
                                  where S.LeaugeId == id
                                 select S).ToListAsync();
            if (Sessions == null)
            {
                return BadRequest("Leauge not found");
            }
            return Ok(Sessions);
        }


        [HttpPut]
        public async Task<ActionResult<Leauge>> UpdateLeauge(Leauge request)
        {
            var Leauge = await _context.Leauge.FindAsync(request.LeaugeId);
            if (Leauge == null)
            {
                return BadRequest("Leauge not found");
            }
            if(request.LeaugeName != null)
            {
                Leauge.LeaugeName = request.LeaugeName;
            }
            if(request.LeaugeStartDate != null)
            {
                Leauge.LeaugeStartDate = request.LeaugeStartDate;
            }
            if (request.LeagueType != null)
            {
                Leauge.LeagueType = request.LeagueType;
            }

            await _context.SaveChangesAsync();

            return Ok(Leauge);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Leauge>>> Delete(int id)
        {
            var Leauge = await _context.Leauge.FindAsync(id);
            if (Leauge == null)
            {
                return BadRequest("Leauge not found");
            }
            _context.Leauge.Remove(Leauge);
            await _context.SaveChangesAsync();

            return Ok(Leauge);
        }
    }
}
