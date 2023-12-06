using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games.Entities
{
    public class GameModelFilter
    {
        public int? minimumPrice { get; set; }
        public int? maximumPrice { get; set; }
        public DateTime? dateOfRelease { get; set; }
    }
}
