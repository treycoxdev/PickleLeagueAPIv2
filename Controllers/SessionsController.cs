using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickleLeaugev4.Data;
using PickleLeaugev4.Models;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        private DataContext _context;

        public SessionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Session>>> Get()
        {
            return Ok(await _context.Sessions.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> Get(int id)
        {
            var Session = await _context.Sessions.FindAsync(id);
            if (Session == null)
            {
                return BadRequest("Session not found");
            }
            return Ok(Session);
        }


        [HttpPost]
        public async Task<ActionResult<List<Session>>> AddSession(Session Session)
        {
            _context.Sessions.Add(Session);
            await _context.SaveChangesAsync();
            return Ok(Session);
        }

        [HttpPut]
        public async Task<ActionResult<Session>> UpdateSession(Session request)
        {
            var Session = await _context.Sessions.FindAsync(request.SessionId);
            if (Session == null)
            {
                return BadRequest("Session not found");
            }
            if (request.SessionTime != DateTime.MinValue)
            {
                Session.SessionTime = request.SessionTime;
            }
            if (request.SessionLocation != null)
            {
                Session.SessionLocation = request.SessionLocation;
            }

            await _context.SaveChangesAsync();

            return Ok(Session);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Session>>> Delete(int id)
        {
            var Session = await _context.Sessions.FindAsync(id);
            if (Session == null)
            {
                return BadRequest("Session not found");
            }
            _context.Sessions.Remove(Session);
            await _context.SaveChangesAsync();

            return Ok(Session);
        }
    }
}
