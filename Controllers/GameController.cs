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
    public class gameController : ControllerBase
    {

        private DataContext _context;

        public gameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return Ok(await _context.Game.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return BadRequest("game not found");
            }
            return Ok(game);
        }

        [HttpGet("Session/{id}")]
        public async Task<ActionResult<Session>> GetGamesBySession(int id)
        {
            var Games = await (from G in _context.Game
                                  where G.SessionId == id
                                 select G).ToListAsync();
            if (Games == null)
            {
                return BadRequest("Games not found");
            }
            return Ok(Games);
        }


        [HttpPost]
        public async Task<ActionResult<List<Game>>> Addgame(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            return Ok(game);
        }

        [HttpPut]
        public async Task<ActionResult<Game>> Updategame(Game request)
        {
            var game = await _context.Game.FindAsync(request.GameId);
            if (game == null)
            {
                return BadRequest("game not found");
            }
            if (request.IdOne != null)
            {
                game.IdOne = request.IdOne;
            }
            if (request.IdTwo != null)
            {
                game.IdTwo = request.IdTwo;
            }
            if (request.ScoreOne != null)
            {
                game.ScoreOne = request.ScoreOne;
            }
            if (request.ScoreTwo != null)
            {
                game.ScoreTwo = request.ScoreTwo;
            }
            if (request.GameTime != null)
            {
                game.GameTime = request.GameTime;
            }
            if (request.CourtName != null)
            {
                game.CourtName = request.CourtName;
            }
            if (request.SessionId != null)
            {
                game.SessionId = request.SessionId;
            }
            if (request.WinnerId != null)
            {
                game.WinnerId = request.WinnerId;
            }

            await _context.SaveChangesAsync();

            return Ok(game);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Game>>> Delete(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return BadRequest("game not found");
            }
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return Ok(game);
        }
    }
}