using System;
using Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame.Objects
{
    public class Region
    {
        public int State { get; set; } 
        public Rectangle Area { get; set; }

        public Region(int x, int y, int width, int height)
        {
            State = 0;
            Area = new Rectangle(x, y, width, height);
        }

        public void InteractWithRegionState()
        {
            if (!IsActive())
            {
                State = BoardStateManager.currentPlayer;
                BoardStateManager.UpdatePlayerState();
            }
        }

        public bool IsActive()
        {
            if (State == 1 || State == -1)
            {
                return true;
            }
            return false;
        }

        public string GetSymbol()
        {
            if (State == 1)
            { return "X"; }
            else if (State == -1) 
            { return "O"; }
            return "";
        }
    }
}
