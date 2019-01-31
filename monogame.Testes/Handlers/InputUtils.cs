using NUnit.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame.Testes
{
    [TestFixture()]
    public class InputUtils
    {
        MouseState mouseButtonState;
        MouseState mousePreviousButtonState;

        [TestFixtureSetUp()]
        public void TestSetup()
        {
            mouseButtonState = new MouseState(0, 0, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            mousePreviousButtonState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        [Test()]
        public void IsClickedShouldReturnTrueForClickedState()
        {
            Assert.That(Handlers.Input.IsMouseClick(mouseButtonState, mousePreviousButtonState), Is.True);
        }        
    }
}
