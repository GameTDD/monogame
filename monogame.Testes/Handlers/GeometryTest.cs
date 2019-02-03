using NUnit.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace monogame.Testes
{
    [TestFixture()]
    public class GeometryTest
    {
        protected MouseState correctMouseState;
        protected MouseState unclickedMouseState;
        protected MouseState smallerThanRegionState;
        protected MouseState greaterThanRegionState;
        protected Rectangle rect;

        [TestFixtureSetUp()]
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

    
        [Test()]
        public void MouseStatePositionIsInRegion()
        {
            Assert.That(Handlers.Regions.IsInReagion(correctMouseState, rect), Is.True);
        }

        [Test()]
        public void MouseStatePositionSmallerThanRegion()
        {
            Assert.That(Handlers.Regions.IsInReagion(smallerThanRegionState, rect), Is.False);
        }

        [Test()]
        public void MouseStatePositionGreaterThanRegion()
        {
            Assert.That(Handlers.Regions.IsInReagion(greaterThanRegionState, rect), Is.False);
        }
    

        [Test()]
        public void MouseHasClickedRegion()
        {
            Assert.That(Handlers.Regions.HasMouseClickedRegion(correctMouseState, smallerThanRegionState, rect), Is.True);
        }

        [Test()]
        public void MouseInRegionNotClicked()
        {
            Assert.That(Handlers.Regions.HasMouseClickedRegion(unclickedMouseState, smallerThanRegionState, rect), Is.False);
        }

        [Test()]
        public void MouseClickedNotInRegion()
        {
            Assert.That(Handlers.Regions.HasMouseClickedRegion(greaterThanRegionState, unclickedMouseState, rect), Is.False);
        }
    
    }
}
