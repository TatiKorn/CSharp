using SeleniumExtras.WaitHelpers;

namespace CheckersGame
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    class Program1
    {
        static void Main(string[] args)
        {
            // Step 1: Initialize the ChromeDriver
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Step 2: Navigate to the website
            driver.Navigate().GoToUrl("https://www.gamesforthebrain.com/game/checkers/");

            // Step 2: Confirm that the site is up
            if (driver.Title.Contains("Checkers"))
            {
                Console.WriteLine("Website is up!");
            }
            else
            {
                Console.WriteLine("Website is not responding.");
            }

            // Step 3: Make five legal moves as orange
            // Perform the move by clicking the orange piece and then clicking a legal move
            IWebElement orangePiece = driver.FindElement(By.Name("space62"));
            orangePiece.Click();
            IWebElement legalMove = driver.FindElement(By.ClassName("space53"));
            legalMove.Click();
            IWebElement makeAMove = driver.FindElement(By.Id("message"));
            // Wait for the element to be displayed
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("message")));
            // Click the button
            makeAMove.Click();


            // Step 3c: Restart the game after five moves
            IWebElement restartButton = driver.FindElement(By.LinkText("Restart"));
            restartButton.Click();

            // Step 3d: Confirm that the restarting was successful
            if (driver.Title.Contains("Checkers") && makeAMove.Text.Equals("Select an orange piece to move."))
            {
                Console.WriteLine("Game has been successfully restarted!");
            }
            else
            {
                Console.WriteLine("Game restart failed.");
            }

            // Close the browser
            driver.Quit();
        }
    }

}