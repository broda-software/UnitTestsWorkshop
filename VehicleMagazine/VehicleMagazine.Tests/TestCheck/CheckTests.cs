using NUnit.Framework;

namespace VehicleMagazine.Tests.TestCheck
{
    [TestFixture]
    class CheckTests
    {
        [Test]
        public void CheckTest1()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void CheckTest2()
        {
            Assert.AreEqual(true, false);
        }
    }
}
