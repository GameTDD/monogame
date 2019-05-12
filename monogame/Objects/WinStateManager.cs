using System.Collections.Generic;
using System;

namespace monogame.Objects
{
    public class WinStateManager
    {
        public static int WhichPlayerWon(Region[] regions)
        {
            int row1 = HasWon( new Region[] { regions[0], regions[1], regions[2] });
            int row2 = HasWon( new Region[] { regions[3], regions[4], regions[5] });
            int row3 = HasWon( new Region[] { regions[6], regions[7], regions[8] });
            int col1 = HasWon(new Region[] { regions[0], regions[3], regions[6] });
            return DetermineWinner(row1, row2, row3, col1);
        }

        public static int HasWon(Region[] regions) {
            return ((regions[0].State == 1 && regions[1].State == 1 && regions[2].State == 1)
                || (regions[0].State == -1 && regions[1].State == -1 && regions[2].State == -1))
                ? regions[0].State
                : 0;
        }

        public static int DetermineWinner(int row1, int row2, int row3, int col1)
        {
            if (row1 != 0)
            {
                return row1;
            }
            else if (row2 != 0)
            {
                return row2;
            }
            else if (row3 != 0)
            {
                return row3;
            }
            return col1;
        }
    }
}
