using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class WindowHandlers
    {
        private const string baseUrl = "https://rahulshettyacademy.com/loginpagePractise/";
        private const string email = "mentor@rahulshettyacademy.com";
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = baseUrl;
        }

        [Test]
        public void Test()
        {
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string text = driver.FindElement(By.CssSelector(".red")).Text;
            string[] splittedText = text.Split("at");
            string extractedEmail = splittedText[1].Trim().Split(" ").First();
            Assert.That(extractedEmail, Is.EqualTo(email));
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.FindElement(By.Id("username")).SendKeys(extractedEmail);
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
