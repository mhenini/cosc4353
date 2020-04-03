using System;
using System.Threading;
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
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("N");
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("1");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("submitPrice")));
        }

        // Test if the correct price is calculated when user's location is Texas
        [TestMethod]
        public void GetPrice_InState()
        {   // expected result           
            double margin = 1.5 * (0.02 - 0 + 0.03 + 0.1 + 0.03);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated when user's location is not Texas
        [TestMethod]
        public void GetPrice_OutOfState()
        {// expected result           
            double margin = 1.5 * (0.04 - 0 + 0.03 + 0.1 + 0.03);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("OutStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated if user has requested fuel before
        [TestMethod]
        public void GetPrice_HasHistory()
        {// expected result           
            double margin = 1.5 * (0.02 - 0.01 + 0.03 + 0.1 + 0.03);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated when user has no history
        [TestMethod]
        public void GetPrice_NoHistory()
        {
            // expected result           
            double margin = 1.5 * (0.02 - 0 + 0.03 + 0.1 + 0.03);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated when user requests >= 1000 gallons
        [TestMethod]
        public void GetPrice_GallonsRequestedLarge()
        {
            // expected result           
            double margin = 1.5 * (0.02 - 0 + 0.03 + 0.1 + 0.02);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2000 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2000");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated when user requests < 1000 gallons
        [TestMethod]
        public void GetPrice_GallonsRequestedSmall()
        {
            // expected result           
            double margin = 1.5 * (0.02 - 0 + 0.03 + 0.1 + 0.03);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated when user's delivery date is in summer
        [TestMethod]
        public void GetPrice_InSummer()
        {
            // expected result           
            double margin = 1.5 * (0.02 - 0 + 0.03 + 0.1 + 0.04);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");
            driver.FindElement(By.Id("date")).Clear();
            driver.FindElement(By.Id("date")).SendKeys("7/2/2020");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the correct price is calculated when user's delivery date is not in summer
        [TestMethod]
        public void GetPrice_NotInSummer()
        {// expected result           
            double margin = 1.5 * (0.02 - 0 + 0.03 + 0.1 + 0.03);
            double suggestedPrice = Math.Round(1.5 + margin, 2);
            double totalPrice = Math.Round(2 * suggestedPrice, 2);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateNoHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);

            // calc prices should match expected prices
            Assert.AreEqual(suggestedPrice.ToString(), driver.FindElement(By.Id("price")).GetAttribute("value"));
            Assert.AreEqual(totalPrice.ToString(), driver.FindElement(By.Id("total")).GetAttribute("value"));
        }

        // Test if the price is properly submitted
        [TestMethod]
        public void SubmitPrice()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // login with any returning user
            driver.FindElement(By.Id("LoginBox")).SendKeys("InStateHistory");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("pwd");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            driver.FindElement(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")).Click();

            // Fill form
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getPrice")));
            driver.FindElement(By.Id("gallons")).SendKeys("2");

            // buttons should now be clickable
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("getPrice")));
            driver.FindElement(By.Id("getPrice")).Click();
            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("submitPrice")));
            driver.FindElement(By.Id("submitPrice")).Click();

            // success alert should now pop up
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Quit();
        }

        [TestMethod]
        public void ProfileForm_invalidinput()
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // register new user
            driver.FindElement(By.Id("TxtBoxNewU")).SendKeys("formtest");
            driver.FindElement(By.Id("TextBoxNewPass")).SendKeys("formpass");
            driver.FindElement(By.Id("ConfirmTextBox1")).SendKeys("formpass");
            driver.FindElement(By.Id("RegButton")).Click();

            // login with new username and password
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='LoginBox']")));
            driver.FindElement(By.Id("LoginBox")).SendKeys("formtest");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("formpass");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();

            // enter information to profile page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='PerInfo']")));
            driver.FindElement(By.Id("fname")).SendKeys("Testing 123");
            driver.FindElement(By.Id("Addy1")).SendKeys("456 Testing ln.");
            driver.FindElement(By.Id("city")).SendKeys("Checkville");
            var selectelement = new SelectElement(driver.FindElement(By.Id("state")));
            selectelement.SelectByValue("TX");
            driver.FindElement(By.Id("zip")).SendKeys("123456");
            driver.FindElement(By.Id("formSubmit")).Click();

            // if successful, application will go to the profile page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
        }
    }
}
