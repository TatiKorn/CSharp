using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.PageObjects
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> _checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement _checkoutButton;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IList<IWebElement> GetCards => _checkoutCards;

        public void CheckOut()
        {
            _checkoutButton.Click();
            // You might navigate to another page or perform further operations here
        }
    }
}