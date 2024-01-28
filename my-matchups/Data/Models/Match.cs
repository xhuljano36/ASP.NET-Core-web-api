namespace my_matchups.Data.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string TeamsCompeting { get; set; }
        public string Description { get; set; }
        public bool IsPlayed { get; set; }
        public DateTime? DatePlayed { get; set; }
        public int? MatchRate { get; set; }
        public string Type { get; set; }
        public DateTime DateDetermined { get; set; }
    }
}
