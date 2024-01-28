using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_matchups.Data.Services;
using my_matchups.Data.ViewModels;
using System.Threading.Tasks;

namespace my_matchups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchupsController : ControllerBase
    {
        private readonly MatchupsService _matchupsService;

        public MatchupsController(MatchupsService matchupsService)
        {
            _matchupsService = matchupsService;
        }

        [HttpGet("get-all-matchups")]
        public async Task<IActionResult> GetAllMatchups()
        {
            var allMatchups = await _matchupsService.GetAllMatchupsAsync();
            return Ok(allMatchups);
        }

        [HttpGet("get-matchup-by-id/{id}")]
        public async Task<IActionResult> GetMatchById(int id)
        {
            var match = await _matchupsService.GetMatchupByIdAsync(id);
            return Ok(match);
        }

        [HttpPost("add-matchup")]
        public async Task<IActionResult> AddMatch([FromBody] MatchVM match)
        {
            await _matchupsService.AddMatchupAsync(match);
            return Ok();
        }

        [HttpPut("update-match-by-id/{id}")]
        public async Task<IActionResult> UpdateMatchById(int id, [FromBody] MatchVM match)
        {
            var updatedMatch = await _matchupsService.UpdateMatchByIdAsync(id, match);
            return Ok(updatedMatch);
        }

        [HttpDelete("delete-match-by-id/{id}")]
        public async Task<IActionResult> DeleteMatchById(int id)
        {
            await _matchupsService.DeleteMatchByIdAsync(id);
            return Ok();
        }
    }
}
