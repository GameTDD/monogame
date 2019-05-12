using NUnit.Framework;
using System;
using monogame.Objects;

namespace monogame.Testes.Handlers
{
    [TestFixture()]
    public class WinStateManagerTest
    {
        Region[] regions;

        [TestFixtureSetUp()]
        public void TestSetup()
        { 
            regions = new Region[9] {
                new Region(100, 100, 94, 94, null),
                new Region(206, 100, 88, 94, null),
                new Region(306, 100, 94, 94, null),
                new Region(100, 206, 94, 88, null),
                new Region(206, 206, 88, 88, null),
                new Region(306, 206, 94, 88, null),
                new Region(100, 306, 94, 94, null),
                new Region(206, 306, 88, 94, null),
                new Region(306, 306, 94, 94, null)
            };
        }

        [Test()]
        public void AllRegionsWith0NoVictoryPlayer()
        {
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(0));
        }

        [Test()]
        public void Row1HasWonP1()
        {
            regions[0].State = 1;
            regions[1].State = 1;
            regions[2].State = 1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(1));
        }

        [Test()]
        public void Row2HasWonP2()
        {
            TestSetup();
            regions[3].State = -1;
            regions[4].State = -1;
            regions[5].State = -1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(-1));
        }

        [Test()]
        public void Col1HasWonP1()
        {
            TestSetup();
            regions[0].State = 1;
            regions[3].State = 1;
            regions[6].State = 1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(1));
        }

        [Test()]
        public void Col2HasWonP2()
        {
            TestSetup();
            regions[1].State = -1;
            regions[4].State = -1;
            regions[7].State = -1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(-1));
        }
    }
}
