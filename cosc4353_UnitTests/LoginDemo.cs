using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cosc4353_UnitTests
{
    [TestClass]
    public class LoginDemo
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
        public void NewLogin_ValidInput()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input valid values and proceeds to redirect to ProfileForm.aspx
            driver.FindElement(By.Id("LoginBox")).SendKeys("houCougars");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("houston1998");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fname")));            

        }

        [TestMethod]
        public void ReturnLogin_ValidInput()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input valid values and proceeds to redirect to Profile.aspx
            driver.FindElement(By.Id("LoginBox")).SendKeys("houCougars");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("houston1998");
            driver.FindElement(By.Id("resText")).SendKeys("N");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='myNavbar']/ul[1]/li[3]/a")));
            

        }

        [TestMethod]
        public void Invalid_LoginPass()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input invalid values and displays an "incorrect password"
            driver.FindElement(By.Id("LoginBox")).SendKeys("houCougars");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("houston");
            driver.FindElement(By.Id("resText")).SendKeys("N");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Label6")));
            driver.FindElement(By.Id("PassWordBox")).Clear();

        }

        [TestMethod]
        public void Invalid_LoginUserorPass()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input invalid values and displays an "Invalid Username or Password"
            driver.FindElement(By.Id("LoginBox")).SendKeys("bsmith25");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("houston");
            driver.FindElement(By.Id("resText")).SendKeys("N");
            driver.FindElement(By.Id("loginButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Label6")));
            driver.FindElement(By.Id("LoginBox")).Clear();

        }

        [TestCleanup]
        public void closeBrowser()
        {
            driver.Quit();
        }


    }     
}