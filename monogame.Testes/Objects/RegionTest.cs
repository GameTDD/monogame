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
        public void StateChangesTo1AfterClick()
        {
            region.InteractWithRegionState();
            Assert.That(region.State, Is.EqualTo(1));
        }

        [Test()]
        public void StateDoesNotCHangeWhenAlreadyClicked()
        {
            region.State = -1;
            region.InteractWithRegionState();
            Assert.That(region.State, Is.EqualTo(-1));
        }
    }
}
