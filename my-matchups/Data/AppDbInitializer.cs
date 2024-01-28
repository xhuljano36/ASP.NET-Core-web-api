using my_matchups.Data.Models;

namespace my_matchups.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Matchups.Any())
                {
                    context.Matchups.AddRange(new Match()
                    {
                        TeamsCompeting = "Milan vs Real Madrid",
                       
                        IsPlayed = true,
                        DatePlayed = DateTime.Now.AddDays(-8),
                        Description = "First matchup description",
                        MatchRate = 7,
                        Type = "Football",
                        DateDetermined = DateTime.Now.AddDays(-20)
                    }, new Match()
                    {
                        
                        Description = "Second matchup description",
                        IsPlayed = false,
                        TeamsCompeting = "Inter vs Barcelona",

                        Type = "Football",
                        DateDetermined = DateTime.Now
                    }) ;
                    context.SaveChanges();
                }
            }
        }
    }
}
