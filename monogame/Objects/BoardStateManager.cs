using System;
using Microsoft.Xna.Framework.Input;
using Handlers;

namespace monogame.Objects
{
    public class BoardStateManager
    {
        public static int currentPlayer { get; set; }

        public BoardStateManager()
        {
            currentPlayer = 1;
        }

        public static void UpdatePlayerState() {
            currentPlayer = -currentPlayer;
        }

        public int ClickedRegion(Region[] regions, MouseState current, MouseState prev) 
        {
            for (int i = 0; i < regions.Length; i++)
            {
                if (Regions.HasMouseClickedRegion(current, prev, regions[i].Area))
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateClickedRegionState(Region[] regions, 
                                             int clickedRegion)
        {
            if (clickedRegion != -1)
            {
                regions[clickedRegion].InteractWithRegionState();
            }
        }
    }
}
