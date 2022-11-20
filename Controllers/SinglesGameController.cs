using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PickleLeaugev4.Models;
using PickleLeaugev4.Data;
using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SinglesGameController : ControllerBase
    {

        private DataContext _context;

        public SinglesGameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<SinglesGame>>> Get()
        {
            return Ok(await _context.SinglesGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SinglesGame>> Get(int id)
        {
            var SinglesGame = await _context.SinglesGames.FindAsync(id);
            if (SinglesGame == null)
            {
                return BadRequest("SinglesGame not found");
            }
            return Ok(SinglesGame);
        }


        [HttpPost]
        public async Task<ActionResult<List<SinglesGame>>> AddSinglesGame(SinglesGame SinglesGame)
        {
            _context.SinglesGames.Add(SinglesGame);
            await _context.SaveChangesAsync();
            return Ok(SinglesGame);
        }

        [HttpPut]
        public async Task<ActionResult<SinglesGame>> UpdateSinglesGame(SinglesGame request)
        {
            var SinglesGame = await _context.SinglesGames.FindAsync(request.SinglesGameId);
            if (SinglesGame == null)
            {
                return BadRequest("SinglesGame not found");
            }
            if (request.PlayerOneId != null)
            {
                SinglesGame.PlayerOneId = request.PlayerOneId;
            }
            if (request.PlayerTwoId != null)
            {
                SinglesGame.PlayerTwoId = request.PlayerTwoId;
            }
            if (request.PlayerOneScore != null)
            {
                SinglesGame.PlayerOneScore = request.PlayerOneScore;
            }
            if (request.PlayerTwoScore != null)
            {
                SinglesGame.PlayerTwoScore = request.PlayerTwoScore;
            }
            if (request.GameTime != null)
            {
                SinglesGame.GameTime = request.GameTime;
            }
            if (request.CourtName != null)
            {
                SinglesGame.CourtName = request.CourtName;
            }
            if (request.SessionId != null)
            {
                SinglesGame.SessionId = request.SessionId;
            }
            if (request.WinnerId != null)
            {
                SinglesGame.WinnerId = request.WinnerId;
            }

            await _context.SaveChangesAsync();

            return Ok(SinglesGame);
        }

        [HttpDelete]
        public async Task<ActionResult<List<SinglesGame>>> Delete(int id)
        {
            var SinglesGame = await _context.SinglesGames.FindAsync(id);
            if (SinglesGame == null)
            {
                return BadRequest("SinglesGame not found");
            }
            _context.SinglesGames.Remove(SinglesGame);
            await _context.SaveChangesAsync();

            return Ok(SinglesGame);
        }
    }
}

