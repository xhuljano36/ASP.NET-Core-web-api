using Microsoft.EntityFrameworkCore;
using my_matchups.Data.Models;
using my_matchups.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_matchups.Data.Services
{
    public class MatchupsService
    {
        private readonly AppDbContext _context;

        public MatchupsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMatchupAsync(MatchVM matchup)
        {
            var _match = new Match()
            {
                TeamsCompeting=matchup.TeamsCompeting,

                IsPlayed = matchup.IsPlayed,
                DatePlayed = matchup.DatePlayed,
                MatchRate = matchup.MatchRate,
                Type = matchup.Type,
                Description = matchup.Description,
                DateDetermined = DateTime.Now
            };
            _context.Matchups.Add(_match);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Match>> GetAllMatchupsAsync() => await _context.Matchups.ToListAsync();

        public async Task<Match> GetMatchupByIdAsync(int matchupId) => await _context.Matchups.FirstOrDefaultAsync(n => n.Id == matchupId);

        public async Task<Match> UpdateMatchByIdAsync(int matchId, MatchVM match)
        {
            var _match = await _context.Matchups.FirstOrDefaultAsync(n => n.Id == matchId);
            if (_match != null)
            {
                _match.TeamsCompeting = match.TeamsCompeting;
               
                _match.IsPlayed = match.IsPlayed;
                _match.DatePlayed = match.IsPlayed ? match.DatePlayed.Value : null;
                _match.MatchRate = match.IsPlayed ? match.MatchRate.Value : null;
                _match.Type = match.Type;
                _match.Description = match.Description;
                await _context.SaveChangesAsync();
            }
            return _match;
        }

        public async Task DeleteMatchByIdAsync(int matchId)
        {
            var _match = await _context.Matchups.FirstOrDefaultAsync(n => n.Id == matchId);
            if (_match != null)
            {
                _context.Matchups.Remove(_match);
                await _context.SaveChangesAsync();
            }
        }
    }
}
