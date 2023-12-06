using KeysToGames.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games.Entities
{
    public class CreateGameModel
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateOfRelease { get; set; }
        [Required]
        public string DeveloperCompany { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public GenreEntity Genre { get; set; }
    }
}
