using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Model
{
    public class PlayPlayer
    {
        public int PlayId { get; set; }
        public Play Play { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int Score { get; set; }
        public bool IsWinner { get; set; }
    }
}
