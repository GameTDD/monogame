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
            SpriteFont font = null;
            gameBoard = new Board(font);
        }

        [Test()]
        public void LinesAreReactangles()
        {
            Assert.That(gameBoard.lines[0], Is.InstanceOf<Rectangle>());
        }

        [Test()]
        public void BoardHasOnly4Lines()
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

        [Test()]
        public void BoardHas9Regions()
        {
            Assert.That(gameBoard.regions.Length, Is.EqualTo(9));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void CenterRegionDoesNotOverlapsLines(int x)
        {
            Assert.That(HasOverlap(gameBoard.regions[x].Area, gameBoard.lines, -1), Is.False);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void RegionsDoNotOverlap(int x)
        {
            Rectangle[] rectangles = new Rectangle[9] {
                gameBoard.regions[0].Area,
                gameBoard.regions[1].Area,
                gameBoard.regions[2].Area,
                gameBoard.regions[3].Area,
                gameBoard.regions[4].Area,
                gameBoard.regions[5].Area,
                gameBoard.regions[6].Area,
                gameBoard.regions[7].Area,
                gameBoard.regions[8].Area, 
            };
            Assert.That(HasOverlap(gameBoard.regions[x].Area, rectangles, x), Is.False);
        }

        public bool HasOverlap(Rectangle rect, Rectangle[] lines, int idx)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (i != idx && rect.Intersects(lines[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
