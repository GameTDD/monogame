using NUnit.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
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
            SpriteFont font = null;
            region = new Region(10, 15, 20, 35, font);
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

        [Test()]
        public void XIsReturnedFor1()
        {
            region.State = 1;
            Assert.That(region.GetSymbol(), Is.EqualTo("X"));
        }

        public void OIsReturnedForMinus1()
        {
            region.State = -1;
            Assert.That(region.GetSymbol(), Is.EqualTo("O"));
        }

        [Test()]
        public void EmptyStringFor0()
        {
            region.State = 0;
            Assert.That(region.GetSymbol(), Is.EqualTo(""));
        }

        [Test()]
        public void IsStringPositionVectorCentered()
        {
            Assert.That(region.StringPosition, Is.EqualTo(new Vector2(20, 32)));
        }
    }
}
