using NUnit.Framework;
using System;
using monogame.MacOS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame.Testes.GameScene
{
    [TestFixture()]
    public class GameConfig
    {

        [Test()]
        public void IsBackgroundWhite()
        {
            Assert.That(Color.White, Is.EqualTo(GeneralAttributes.BackgroundColor()));
        }
    }
}
