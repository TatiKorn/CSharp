using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {

        IWebDriver driver;

       [SetUp]

        public void StartBrowser()

        {
            //Methods -geturl, click-
            //chromedriver.exe on chrome browser
            //edgedriver.exe
            //geckodriver
            //99 .exe (99)
            //WebDriverManager-(
          new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
              driver = new ChromeDriver();
            //driver = new FirefoxDriver();
          //  driver = new EdgeDriver();


            driver.Manage().Window.Maximize();




        }


        [Test]
        public void Test1()

        {

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
           // driver.PageSource
           driver.Close();//1 windows
            //driver.Quit(); //2 windows 







        }

    }

}
