using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace cosc4353_UnitTests
{
    public class RegistrationDemo
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

        [TestMethod]
        public void Registration_invalidInput()
        {
            // initialize input string that contain values longer than the allowed length
            string name = "randomtestrandomtestrandomtestrandomtestrandomtestrandomtest";
            int namelength_presubmission = name.Length;

            string address = "randomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtest";
            int addresslength_preSubmission = address.Length;

            string city = "randomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtestrandomtest";
            int citylength_preSubmission = city.Length;

            // checking both long and short zip codes outside of the 5-9 range
            string zipShort = "123";
            string zipLong = "1234567890";

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // register new user
            driver.FindElement(By.Id("TxtBoxNewU")).SendKeys("formtest2");
            driver.FindElement(By.Id("TextBoxNewPass")).SendKeys("formpass");
            driver.FindElement(By.Id("ConfirmTextBox1")).SendKeys("formpass");
            driver.FindElement(By.Id("RegButton")).Click();

            // login with new username and password
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='LoginBox']")));
            driver.FindElement(By.Id("LoginBox")).SendKeys("formtest2");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("formpass");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();

            // Enter information to profile page. For all input boxes, excluding State and Zip boxes, the input box will not allow user to input more than the specified characters.
            // To test this, an input larger than the allowed length will be inputed, and the output length should only be as long as the allowed length.
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='PerInfo']")));
            driver.FindElement(By.Id("fname")).SendKeys(name);
            driver.FindElement(By.Id("Addy1")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);
            var selectelement = new SelectElement(driver.FindElement(By.Id("state")));
            selectelement.SelectByValue("TX");

            // Testing sample zipcode of length 3
            driver.FindElement(By.Id("zip")).SendKeys(zipShort);
            driver.FindElement(By.Id("formSubmit")).Click();

            // Error message should pop up saying the zip code is too short
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='errormsg']")));

            // Testing sample zipcode of length 10
            driver.FindElement(By.Id("zip")).SendKeys(zipLong);
            driver.FindElement(By.Id("formSubmit")).Click();

            // Error message should pop up saying the zip code is too long
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='errormsg']")));
        }

        [TestMethod]
        public void Registration_validInput()
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // login with new username and password registered from previous test
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='LoginBox']")));
            driver.FindElement(By.Id("LoginBox")).SendKeys("formtest2");
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
