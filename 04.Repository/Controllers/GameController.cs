using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _04.Repository.Controllers
{
    [Route("game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGamesRepository gamesRepository;

        public GameController(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await gamesRepository.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await gamesRepository.GetAsync(id);
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(Game game)
        {
            await gamesRepository.CreateAsync(game);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, Game updatedGame)
        {
            if (id != updatedGame.Id)
            {
                return BadRequest();
            }

            await gamesRepository.UpdateAsync(updatedGame);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await gamesRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
