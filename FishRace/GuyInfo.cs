using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishRace.BettorCls;

namespace FishRace
{
    public static class GuyInfo
    {
        public static GuyCls GetBettorInfo(int ID)
        {
            switch (ID)
            {
                case 0:
                    return new Aniket();

                case 1:
                    return new Raghuveer();

                case 2:
                    return new Nirmal();
                default:
                    return new Aniket();

            }
            //this initiates a new steve,dax or allan to hold the data from other classes.

        }
    }
}
