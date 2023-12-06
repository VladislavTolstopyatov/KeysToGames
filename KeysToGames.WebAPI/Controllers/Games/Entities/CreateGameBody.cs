using KeysToGames.DataAccess.Entities;

namespace KeysToGames.Controllers.Games.Entities
{
    public class CreateGameBody
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string DeveloperCompany { get; set; }
        public int Price { get; set; }
        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
