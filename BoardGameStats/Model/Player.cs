using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Model
{
    public class Player : EntitiyBase
    {
        public string Name { get; set; }
        public List<PlayPlayer> PlayerPlays { get; set; }
    }
}
