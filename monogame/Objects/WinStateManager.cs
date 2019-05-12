using System.Collections.Generic;
using System;
using System.Linq;

namespace monogame.Objects
{
    public class WinStateManager
    {
        public static int WhichPlayerWon(Region[] regions)
        {
            int[] axis = new int[] {
                HasWon( new Region[] { regions[0], regions[1], regions[2] }),
                HasWon(new Region[] { regions[3], regions[4], regions[5] }),
                HasWon(new Region[] { regions[6], regions[7], regions[8] }),
                HasWon(new Region[] { regions[0], regions[3], regions[6] }),
                HasWon(new Region[] { regions[1], regions[4], regions[7] }),
                HasWon(new Region[] { regions[2], regions[5], regions[8] }),
                HasWon(new Region[] { regions[0], regions[4], regions[8] }),
                HasWon(new Region[] { regions[2], regions[4], regions[6] })
            };

            foreach(int value in axis) { 
                if (value == 1 || value == -1) { return value;  }
            }
            return 0;
        }

        public static int HasWon(Region[] regions) {
            return ((regions[0].State == 1 && regions[1].State == 1 && regions[2].State == 1)
                || (regions[0].State == -1 && regions[1].State == -1 && regions[2].State == -1))
                ? regions[0].State
                : 0;
        }
    }
}
