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

        public void InteractWithRegionState(MouseState current, MouseState previous)
        {
            if (Regions.HasMouseClickedRegion(current, previous, Area) && !IsActive())
            {
                State = 1;
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
    }
}
