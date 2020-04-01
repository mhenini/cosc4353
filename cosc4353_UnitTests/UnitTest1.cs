using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace cosc4353_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        WebDriverWait wait;

        private IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            // works but must have 2nd visual studio running with actual project
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53848/Login.aspx");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("loginButton")));
        }

        // Test if error message appears for invalid input
        [TestMethod]
        public void FuelQuote_InvalidOutput()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("a");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("a");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Input invalid values and check for error messages
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("a");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("error")));
            driver.FindElement(By.Id("gallons")).Clear();

            driver.FindElement(By.Id("gallons")).SendKeys("0");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("error")));
            driver.FindElement(By.Id("gallons")).Clear();

            driver.FindElement(By.Id("gallons")).SendKeys("-1");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("error")));
        }

        // Test if get/submit price buttons are enabled when all fields are properly filled
        [TestMethod]
        public void FuelQuote_ValidOutput()
        {
        }

        // Test if the correct price is calculated when user's location is Texas
        [TestMethod]
        public void GetPrice_InState()
        {
        }

        // Test if the correct price is calculated when user's location is not Texas
        [TestMethod]
        public void GetPrice_OutOfState()
        {
        }

        // Test if the correct price is calculated if user has requested fuel before
        [TestMethod]
        public void GetPrice_HasHistory()
        {
        }

        // Test if the correct price is calculated when user has no history
        [TestMethod]
        public void GetPrice_NoHistory()
        {
        }

        // Test if the correct price is calculated when user requests >= 1000 gallons
        [TestMethod]
        public void GetPrice_GallonsRequestedLarge()
        {
        }

        // Test if the correct price is calculated when user requests < 1000 gallons
        [TestMethod]
        public void GetPrice_GallonsRequestedSmall()
        {
        }

        // Test if the correct price is calculated when user's delivery date is in summer
        [TestMethod]
        public void GetPrice_InSummer()
        {
        }

        // Test if the correct price is calculated when user's delivery date is not in summer
        [TestMethod]
        public void GetPrice_NotInSummer()
        {
        }

        // Test if the price is properly submitted
        [TestMethod]
        public void SubmitPrice()
        {
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Quit();
        }
    }
}
