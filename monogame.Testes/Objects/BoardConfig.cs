using NUnit.Framework;
using NSubstitute;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame.MacOS;
using monogame.Objects;

namespace monogame.Testes.Objects
{
    [TestFixture()]
    public class BoardConfig
    {
        Board gameBoard;

        [TestFixtureSetUp()]
        public void BoardTestSetUp()
        {
            gameBoard = new Board();
        }

        [Test()]
        public void LinesAreReactangles()
        {
            Assert.That(gameBoard.lines[0], Is.InstanceOf<Rectangle>());
        }

        [Test()]
        public void TestIfBoardHasOnly4Lines()
        {
            Assert.That(gameBoard.lines.Length, Is.EqualTo(4));
        }

        [Test()]
        public void ThicknessAndLenghtAreCommonProps()
        {
            Assert.That(gameBoard.Thickness, Is.EqualTo(10));
            Assert.That(gameBoard.Length, Is.EqualTo(300));
        }

        [TestCase(0, 195, 100, 10, 300)]
        [TestCase(1, 295, 100, 10, 300)]
        [TestCase(2, 100, 195, 300, 10)]
        [TestCase(3, 100, 295, 300, 10)]
        public void AreRectanglesPropertiesCorrect(int i, int x, int y, int w, int h)
        {
            Assert.That(gameBoard.lines[i], Is.EqualTo(new Rectangle(x, y, w, h)));
        }
    }
}
