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
    public class ClubController :  ControllerBase 
    {
        
        private DataContext _context;

        public ClubController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Club>>> Get()
        {
            return Ok(await _context.Clubs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> Get(int id)
        {
            var Club = await _context.Clubs.FindAsync(id);
            if (Club == null)
            {
                return BadRequest("Club not found");
            }
            return Ok(Club);
        }


        [HttpPost]
        public async Task<ActionResult<List<Club>>> AddClub(Club Club)
        {
            _context.Clubs.Add(Club);
            await _context.SaveChangesAsync();
            return Ok(Club);
        }

        [HttpPut]
        public async Task<ActionResult<Club>> UpdateClub(Club request)
        {
            var Club = await _context.Clubs.FindAsync(request.ClubId);
            if (Club == null)
            {
                return BadRequest("Club not found");
            }
            if(request.ClubName != null){
                Club.ClubName = request.ClubName;
            }

            await _context.SaveChangesAsync();

            return Ok(Club);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Club>>> Delete(int id)
        {
            var Club = await _context.Clubs.FindAsync(id);
            if (Club == null)
            {
                return BadRequest("Club not found");
            }
            _context.Clubs.Remove(Club);
            await _context.SaveChangesAsync();

            return Ok(Club);
        }

    }
}
