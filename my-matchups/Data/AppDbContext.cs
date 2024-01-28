using Microsoft.EntityFrameworkCore;
using my_matchups.Data.Models;

namespace my_matchups.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
              
        }
        public DbSet<Match> Matchups { get; set; }
    }
}
