using NUnit.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using monogame.Objects;

namespace monogame.Testes.Objects
{
    [TestFixture()]
    public class RegionTest
    {
        Region region;
        MouseState currentState;
        MouseState previousState;

        [TestFixtureSetUp()]
        public void SetUpRegion()
        {
            region = new Region(10, 15, 20, 35);
            currentState = new MouseState(20, 40, 0, ButtonState.Pressed, ButtonState.Released,
                     ButtonState.Released, ButtonState.Released, ButtonState.Released);
            previousState = new MouseState(25, 45, 0, ButtonState.Released, ButtonState.Released,
                     ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        [Test()]
        public void InitialStateShouldBeZero()
        {
            Assert.That(region.State, Is.EqualTo(0));
        }

        [Test()]
        public void InitialAreaShouldEqualRectangle()
        {
            Assert.That(region.Area, Is.EqualTo(new Rectangle(10, 15, 20, 35)));
        }

        [Test()]
        public void StateDoesNotChangeAfterClick()
        {
            region.State = 0;
            MouseState currentStateAux = new MouseState(1000, 400, 0, ButtonState.Pressed, ButtonState.Released,
                     ButtonState.Released, ButtonState.Released, ButtonState.Released);
            region.InteractWithRegionState(currentStateAux, previousState);
            Assert.That(region.State, Is.EqualTo(0));
        }

        [Test()]
        public void StateChangesTo1AfterClick()
        {
            region.InteractWithRegionState(currentState, previousState);
            Assert.That(region.State, Is.EqualTo(1));
        }
    }
}
