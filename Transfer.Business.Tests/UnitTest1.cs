namespace Transfer.Business.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int sayi = 1 + 1;

            Assert.AreEqual(sayi, 2);
        }
    }
}