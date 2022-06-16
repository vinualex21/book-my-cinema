using BookMyCinema;
using NUnit.Framework;

namespace BookMyCinemaTests
{
    public class TheatreManagerTest
    {
        private TheatreManager theatreManager;
        [SetUp]
        public void Setup()
        {
            theatreManager = new TheatreManager();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}