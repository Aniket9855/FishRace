using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishRace
{
    public class BetCls
    {
        public int Amount { get; set; } // The Amont Of Money that was Bet
        public GuyCls Bettor; // The Person Who Placed The Bet
        public int Fish { get; set; } // Which kayaker got bet on (1-4)
    }
}
