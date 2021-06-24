using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishRace
{
    public class BettorCls
    {
        public class Aniket : GuyCls
        {
            public Aniket()
            {
                PlayerName = "Aniket";
                Cash = 50;
                Labelmax.Text = Convert.ToString(Cash);
            }
        }

        public class Raghuveer : GuyCls
        {
            public Raghuveer()
            {
                PlayerName = "Raghuveer";
                Cash = 50;
                Labelmax.Text = Convert.ToString(Cash);
            }
        }

        public class Nirmal : GuyCls
        {
            public Nirmal()
            {
                PlayerName = "Nirmal";
                Cash = 50;
                Labelmax.Text = Convert.ToString(Cash);
            }
        }
    }
}
