using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Model
{
    public class Play : EntitiyBase
    {
        public Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime Created { get; set; }
        public List<PlayPlayer> PlayerPlays { get; set; }
    }
}
