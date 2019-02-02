using NUnit.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace monogame.Testes
{
    [TestFixture()]
    public class GeometryTest
    {
        MouseState correctMouseState;
        MouseState smallerThanRegionState;
        MouseState greaterThanRegionState;
        Rectangle rect;

        [TestFixtureSetUp()]
        public void GeometryTestSetUp()
        {
            correctMouseState = new MouseState(50, 80, 0, ButtonState.Pressed, ButtonState.Released,
                                             ButtonState.Released, ButtonState.Released, ButtonState.Released);
            smallerThanRegionState = new MouseState(10, 10, 0, ButtonState.Pressed, ButtonState.Released,
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
        public void MouseStatePositionSmallerThanRegion(){
            Assert.That(Handlers.Regions.IsInReagion(smallerThanRegionState, rect), Is.False);
        }

        [Test()]
        public void MouseStatePositionGreaterThanRegion()
        {
            Assert.That(Handlers.Regions.IsInReagion(greaterThanRegionState, rect), Is.False);
        }
    }
}
