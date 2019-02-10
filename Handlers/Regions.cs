using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Handlers
{
    public class Regions
    {
        public static bool IsInReagion(MouseState mouse, Rectangle rect)
        {
            if (rect.Contains(mouse.X, mouse.Y)) {
                return true;
            }
            return false;
        }

        public static bool HasMouseClickedRegion(MouseState currentState, 
                                                 MouseState prevState, Rectangle rect)
        {
            return Input.IsMouseClicked(currentState, prevState) 
                        && IsInReagion(currentState, rect);
        }
    }
}
