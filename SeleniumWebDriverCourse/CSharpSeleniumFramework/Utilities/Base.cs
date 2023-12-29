using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace CSharpSeleniumFramework;

public class Base
{
    public ExtentReports extent;
    public ExtentTest test;
    string browserName;

    [OneTimeSetUp]
    public void Setup()

    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        String reportPath = projectDirectory + "//index.html";
        var htmlReporter = new ExtentHtmlReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        extent.AddSystemInfo("Host Name", "Local host");
        extent.AddSystemInfo("Environment", "QA");
        extent.AddSystemInfo("Username", "Rahul Shetty");

    }
    public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

    [SetUp]
    public void StartBrowser()
    {
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        if (browserName == null)
        {
            browserName = ConfigurationManager.AppSettings["browser"];
            // or a default browser
            browserName = browserName ?? "chrome";
        }
        InitBrowser(browserName);
        driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Value.Manage().Window.Maximize();
        driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
    }

    private void InitBrowser(string browserName)
    {
        switch (browserName)
        {
            case "chrome":
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver.Value = new ChromeDriver();
                break;
            case "firefox":
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                driver.Value = new FirefoxDriver();
                break;
            case "edge":
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                driver.Value = new EdgeDriver();
                break;
            case "ie":
                new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                driver.Value = new InternetExplorerDriver();
                break;
            default:
                throw new Exception("Browser not supported");
        }
    }
    public static JsonReader getDataParser() => new JsonReader("utilities/testData.json");

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace = TestContext.CurrentContext.Result.StackTrace;

        DateTime time = DateTime.Now;
        String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

        if (status == TestStatus.Failed)
        {

            test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
            test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

        }
        else if (status == TestStatus.Passed)
        {

        }

        extent.Flush();
        driver.Value.Quit();
    }
    public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

    {
        ITakesScreenshot ts = (ITakesScreenshot)driver;
        var screenshot = ts.GetScreenshot().AsBase64EncodedString;

        return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

    }

}
