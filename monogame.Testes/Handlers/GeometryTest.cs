using NUnit.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Handlers;

namespace monogame.Testes
{
    [TestFixture]
    public class GeometryTest
    {
        protected MouseState correctMouseState;
        protected MouseState unclickedMouseState;
        protected MouseState smallerThanRegionState;
        protected MouseState greaterThanRegionState;
        protected Rectangle rect;

        [TestFixtureSetUp]
        public void GeometryTestSetUp()
        {
            correctMouseState = new MouseState(50, 80, 0, ButtonState.Pressed, ButtonState.Released,
                                             ButtonState.Released, ButtonState.Released, ButtonState.Released);
            unclickedMouseState = new MouseState(50, 80, 0, ButtonState.Released, ButtonState.Released,
                                             ButtonState.Released, ButtonState.Released, ButtonState.Released);
            smallerThanRegionState = new MouseState(10, 10, 0, ButtonState.Released, ButtonState.Released,
                                             ButtonState.Released, ButtonState.Released, ButtonState.Released);
            greaterThanRegionState = new MouseState(1000, 1000, 0, ButtonState.Pressed, ButtonState.Released,
                                             ButtonState.Released, ButtonState.Released, ButtonState.Released);
            rect = new Rectangle(30, 60, 40, 40);
        }

    
        [Test]
        public void MouseStatePositionIsInRegion()
        {
            Assert.That(Regions.IsInReagion(correctMouseState, rect), Is.True);
        }

        [Test]
        public void MouseStatePositionSmallerThanRegion()
        {
            Assert.That(Regions.IsInReagion(smallerThanRegionState, rect), Is.False);
        }

        [Test]
        public void MouseStatePositionGreaterThanRegion()
        {
            Assert.That(Regions.IsInReagion(greaterThanRegionState, rect), Is.False);
        }
    

        [Test]
        public void MouseHasClickedRegion()
        {
            Assert.That(Regions.HasMouseClickedRegion(correctMouseState, smallerThanRegionState, rect), Is.True);
        }

        [Test]
        public void MouseInRegionNotClicked()
        {
            Assert.That(Regions.HasMouseClickedRegion(unclickedMouseState, smallerThanRegionState, rect), Is.False);
        }

        [Test]
        public void MouseClickedNotInRegion()
        {
            Assert.That(Regions.HasMouseClickedRegion(greaterThanRegionState, unclickedMouseState, rect), Is.False);
        }
    
    }
}
