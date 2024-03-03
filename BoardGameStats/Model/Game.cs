using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Model
{
    public class Game : EntitiyBase
    {
        public string Name { get; set; }
        public GameType Type { get; set; }
        public List<Play> Plays { get; set; }
    }
}
