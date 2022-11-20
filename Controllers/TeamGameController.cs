using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PickleLeaugev4.Models;
using PickleLeaugev4.Data;
using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamGameController : ControllerBase
    {

        private DataContext _context;

        public TeamGameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<TeamGame>>> Get()
        {
            return Ok(await _context.TeamGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamGame>> Get(int id)
        {
            var TeamGame = await _context.TeamGames.FindAsync(id);
            if (TeamGame == null)
            {
                return BadRequest("TeamGame not found");
            }
            return Ok(TeamGame);
        }


        [HttpPost]
        public async Task<ActionResult<List<TeamGame>>> AddTeamGame(TeamGame TeamGame)
        {
            _context.TeamGames.Add(TeamGame);
            await _context.SaveChangesAsync();
            return Ok(TeamGame);
        }

        [HttpPut]
        public async Task<ActionResult<TeamGame>> UpdateTeamGame(TeamGame request)
        {
            var TeamGame = await _context.TeamGames.FindAsync(request.TeamGameId);
            if (TeamGame == null)
            {
                return BadRequest("TeamGame not found");
            }
            if (request.TeamOneId != null)
            {
                TeamGame.TeamOneId = request.TeamOneId;
            }
            if (request.TeamTwoId != null)
            {
                TeamGame.TeamTwoId = request.TeamTwoId;
            }
            if (request.TeamOneScore != null)
            {
                TeamGame.TeamOneScore = request.TeamOneScore;
            }
            if (request.TeamTwoScore != null)
            {
                TeamGame.TeamTwoScore = request.TeamTwoScore;
            }
            if (request.GameTime != null)
            {
                TeamGame.GameTime = request.GameTime;
            }
            if (request.CourtName != null)
            {
                TeamGame.CourtName = request.CourtName;
            }
            if (request.SessionId != null)
            {
                TeamGame.SessionId = request.SessionId;
            }
            if (request.WinnerId != null)
            {
                TeamGame.WinnerId = request.WinnerId;
            }

            await _context.SaveChangesAsync();

            return Ok(TeamGame);
        }

        [HttpDelete]
        public async Task<ActionResult<List<TeamGame>>> Delete(int id)
        {
            var TeamGame = await _context.TeamGames.FindAsync(id);
            if (TeamGame == null)
            {
                return BadRequest("TeamGame not found");
            }
            _context.TeamGames.Remove(TeamGame);
            await _context.SaveChangesAsync();

            return Ok(TeamGame);
        }
    }
}
