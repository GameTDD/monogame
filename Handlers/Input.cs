using Microsoft.Xna.Framework.Input;

namespace Handlers
{
    public class Input
    {
        public static bool IsMouseClicked(MouseState mouseState, MouseState prevMouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed 
                && prevMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }
    }
}
