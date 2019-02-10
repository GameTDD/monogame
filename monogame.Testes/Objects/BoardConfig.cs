using NUnit.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    }
}
