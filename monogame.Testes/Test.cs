using NUnit.Framework;
using System;

namespace monogame.Testes
{
    [TestFixture()]
    public class Test
    {
        private Tester tester;

        [TestFixtureSetUp()]
        public void TestSetup()
        {
            tester = new Tester();
        }

        [Test()]
        public void TestCase()
        {
            Assert.That(true, Is.EqualTo(tester.isBool()));
        }
    }
}
