using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.PageObjects
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;

        private By _cardTitle = By.CssSelector(".card-title a");
        private By _addToCart = By.CssSelector(".card-footer button");

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> _cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageDisplay()

        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> GetCards => _cards;

        public By GetCardTitle => _cardTitle;

        public By AddToCartButton => _addToCart;

        public CheckoutPage Checkout()
        {
            checkoutButton.Click();
            return new CheckoutPage(_driver);
        }
    }
}
