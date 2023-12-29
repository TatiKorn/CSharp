using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class FunctionalTest
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
     
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";


        }

        [Test]
        public void dropdown()

        {

          IWebElement dropdown=  driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1);

            IList <IWebElement> rdos=driver.FindElements(By.CssSelector("input[type='radio']"));


            foreach(IWebElement radioButton in rdos)
            {
               if( radioButton.GetAttribute("value").Equals("user"))

                {

                    radioButton.Click();
                }

                    }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));


            driver.FindElement(By.Id("okayBtn")).Click();
         Boolean result=   driver.FindElement(By.Id("usertype")).Selected;

            Assert.That(result, Is.True);

            



























        }

    }
}
