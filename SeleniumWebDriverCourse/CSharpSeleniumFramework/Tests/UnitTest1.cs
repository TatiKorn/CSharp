using CSharpSeleniumFramework;
using CSharpSeleniumFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETest : Base
    {
        [Test, TestCaseSource(nameof(AddTestDataConfig)), Category("Regression")]
        public void EndToEndFlow(string username, string password, string[] expectedProducts)
        {
            var loginPage = new LoginPage(driver.Value);
            var productPage = loginPage.ValidLogin(username, password);
            productPage.WaitForPageDisplay();

            var products = productPage.GetCards;
            foreach (var product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.GetCardTitle).Text))
                {
                    product.FindElement(productPage.AddToCartButton).Click();
                }
            }

            var checkoutPage = productPage.Checkout();
            var checkoutCards = checkoutPage.GetCards;

            var actualProducts = new List<string>();
            foreach (var card in checkoutCards)
            {
                actualProducts.Add(card.Text);
            }
            Assert.That(actualProducts, Is.EqualTo(expectedProducts));

            checkoutPage.CheckOut();

            driver.Value.FindElement(By.Id("country")).SendKeys("ind");
            var wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.Value.FindElement(By.LinkText("India")).Click();

            driver.Value.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.Value.FindElement(By.CssSelector("[value='Purchase']")).Click();
            var confirmText = driver.Value.FindElement(By.CssSelector(".alert-success")).Text;
        }

        [Test, Category("Smoke")]
        public void LocatorsIdentification()
        {
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
           .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")), "Sign In"));

            String errorMessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(
                getDataParser().ExtractData("username"),
                getDataParser().ExtractData("password"),
                getDataParser().ExtractDataArray("products")
            );
            yield return new TestCaseData(
                getDataParser().ExtractData("username_wrong"),
                getDataParser().ExtractData("password_wrong"),
                getDataParser().ExtractDataArray("products")
            );
        }
        //dotnet test CSharpSeleniumFramework.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter\(name=\"browserName\", value=\"Chrome\"\)
        //java -jar jenkins.war --httpPort=9090
    }
}
