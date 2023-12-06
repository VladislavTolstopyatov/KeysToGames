using KeysToGames.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games.Entities
{
    public class GameModel
    {
        public Guid id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string DeveloperCompany { get; set; }
        public int Price { get; set; }
        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
