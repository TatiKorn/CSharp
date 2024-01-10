using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _password { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement _checkBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement _signInButton { get; set; }

        public ProductsPage ValidLogin(string userName, string password)
        {
            _username.SendKeys(userName);
            _password.SendKeys(password);
            _checkBox.Click();
            _signInButton.Click();
            return new ProductsPage(_driver);
        }

        public IWebElement Username => _username;
    }
}


