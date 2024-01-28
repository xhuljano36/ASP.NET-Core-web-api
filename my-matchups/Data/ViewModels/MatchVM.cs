namespace my_matchups.Data.ViewModels
{
    public class MatchVM
    {
        public string TeamsCompeting { get; set; }
       
        public bool IsPlayed { get; set; }
        public DateTime? DatePlayed { get; set; }
        public string Description { get; set; }
        public int? MatchRate { get; set; }
        public string Type { get; set; }
     
    }
}
