using NUnit.Framework;
using OpenQA.Selenium;
using CSharpSeleniumFramework;

namespace Tests
{
    public class WindowHandlers : Base
    {
        private const string email = "mentor@rahulshettyacademy.com";
        [Test]
        public void Test()
        {
            driver.Value.FindElement(By.ClassName("blinkingText")).Click();
            Assert.That(driver.Value.WindowHandles.Count, Is.EqualTo(2));
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles.Last());
            string text = driver.Value.FindElement(By.CssSelector(".red")).Text;
            string[] splittedText = text.Split("at");
            string extractedEmail = splittedText[1].Trim().Split(" ").First();
            Assert.That(extractedEmail, Is.EqualTo(email));
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles.First());
            driver.Value.FindElement(By.Id("username")).SendKeys(extractedEmail);
        }
    }
}
