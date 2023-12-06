namespace KeysToGames.Controllers.Games.Entities
{
    public class GameFilter
    {
        public int? minimumPrice { get; set; }
        public int? maximumPrice { get; set; }

        public DateTime? dateOfRelease { get; set; }
    }
}
