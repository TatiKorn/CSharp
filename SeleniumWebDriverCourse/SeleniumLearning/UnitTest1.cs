namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.Write("Setup");
        }

        [Test]
        public void Test()
        {
            TestContext.Progress.Write("Test");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.Write("Close");
        }
    }
}