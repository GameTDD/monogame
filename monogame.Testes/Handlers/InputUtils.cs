using NUnit.Framework;
using Microsoft.Xna.Framework.Input;
using Handlers;

namespace monogame.Testes
{
    [TestFixture()]
    public class InputUtils
    {
        MouseState buttonPressedState;
        MouseState buttonReleasedState;

        [TestFixtureSetUp()]
        public void TestSetup()
        {
            buttonPressedState = new MouseState(0, 0, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            buttonReleasedState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        [Test()]
        public void IsClickedShouldReturnTrueForClickedState()
        {
            Assert.That(Input.IsMouseClicked(buttonPressedState, buttonReleasedState), Is.True);
        }

        [Test()]
        public void IsClickedShouldReturnFalseForPressedState()
        {
            Assert.That(Input.IsMouseClicked(buttonPressedState, buttonPressedState), Is.False);
        }  

        [Test()]
        public void IsClickedShouldReturnFalseForReleasedState()
        {
            Assert.That(Input.IsMouseClicked(buttonReleasedState, buttonReleasedState), Is.False);
        }  

        [Test()]
        public void IsClickedShouldReturnFalseForUnclickedState()
        {
            Assert.That(Input.IsMouseClicked(buttonReleasedState, buttonPressedState), Is.False);
        }  
    }
}
