using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {

        // Xpath, Css , id, classname, name, tagname, linktext


        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //Implicit wait 5seconds can be decalred globally
            //3 seconds
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";





        }

        [Test]
        public void LocatorsIdentification()

        {

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            //css selector & xpath
            //  tagname[attribute ='value']
            //    #id  #terms  - class name -> css .classname
            //    driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            //    //tagName[@attribute = 'value']

            // CSS - .text-info span:nth-child(1) input
            //xpath - //label[@class='text-info']/span/input
            
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
           .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));

            String errorMessage =driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link= driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/#/documents-request";
            Assert.AreEqual(expectedUrl, hrefAttr);

            //validate url of the link text




















        }

    }
}
