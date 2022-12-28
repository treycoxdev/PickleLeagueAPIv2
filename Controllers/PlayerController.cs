using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PickleLeaugev4.Models;
using PickleLeaugev4.Data;
using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private DataContext _context;

        public PlayerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Player>>> Get()
        {
            return Ok(await _context.Players.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var Player = await _context.Players.FindAsync(id);
            if (Player == null)
            {
                return BadRequest("Player not found");
            }
            return Ok(Player);
        }

        [HttpGet("League/{id}")]
        public async Task<ActionResult<Session>> GetPlayerByLeauge(int id)
        {
            var Players = await (from  PIL in _context.PlayersInLeauges 
                                 join P in _context.Players on PIL.PlayerId equals P.PlayerId
                                 where PIL.LeaugeId == id
                                 select P).ToListAsync();
            return Ok(Players);
        }

        [HttpPost("League")]
        public async Task<ActionResult<PlayerInTeam>> AddPlayerToLeague(PlayerInLeauge playerInLeague)
        {
            _context.PlayersInLeauges.Add(playerInLeague);
            await _context.SaveChangesAsync();
            return Ok(playerInLeague);
        }

        [HttpPost("Team")]
        public async Task<ActionResult<PlayerInTeam>> AddPlayerToTeam(PlayerInTeam playerInTeam)
        {
            _context.PlayersInTeams.Add(playerInTeam);
            await _context.SaveChangesAsync();
            return Ok(playerInTeam);
        }


        [HttpPost]
        public async Task<ActionResult<List<Player>>> AddPlayer(Player Player)
        {
            _context.Players.Add(Player);
            await _context.SaveChangesAsync();
            return Ok(Player);
        }

        [HttpPut]
        public async Task<ActionResult<Player>> UpdatePlayer(Player request)
        {
            var Player = await _context.Players.FindAsync(request.PlayerId);
            if (Player == null)
            {
                return BadRequest("Player not found");
            }
            if(request.Email != null)
            {
                Player.Email = request.Email;
            }
            if (request.FirstName != null)
            {
                Player.FirstName = request.FirstName;
            }
            if (request.LastName != null)
            {
                Player.LastName = request.LastName;
            }

            await _context.SaveChangesAsync();

            return Ok(Player);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Player>>> Delete(int id)
        {
            var Player = await _context.Players.FindAsync(id);
            if (Player == null)
            {
                return BadRequest("Player not found");
            }
            _context.Players.Remove(Player);
            await _context.SaveChangesAsync();

            return Ok(Player);
        }
    }
}

