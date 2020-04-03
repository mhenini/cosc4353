using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace cosc4353
{
    public class LoginDemo
    {
        WebDriverWait wait;
        private IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            // works but must have 2nd visual studio running with actual project
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53848/Login.aspx");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("loginButton")));
        }

        [Test]
        public void NewLogin_ValidInput()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input valid values and proceeds to redirect to ProfileForm.aspx
            driver.FindElement(By.Id("LoginBox")).SendKeys("houCougars");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("houston1998");
            driver.FindElement(By.Id("resText")).SendKeys("Y");
            driver.FindElement(By.Id("loginButton")).Click();

        }

        [Test]
        public void ReturnLogin_ValidInput()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input valid values and proceeds to redirect to Profile.aspx
            driver.FindElement(By.Id("LoginBox")).SendKeys("houCougars");
            driver.FindElement(By.Id("PassWordBox")).SendKeys("houston1998");
            driver.FindElement(By.Id("resText")).SendKeys("N");
            driver.FindElement(By.Id("loginButton")).Click();

        }

        [Test]
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

        [Test]
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

        [Test]
        public void Valid_Registration()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input valid values and sucessfull registers client
            driver.FindElement(By.Id("TxtBoxNewU")).SendKeys("sd2020");
            driver.FindElement(By.Id("TextBoxNewPass")).SendKeys("spring2020");
            driver.FindElement(By.Id("ConfirmTextBox1")).SendKeys("spring2020");
            driver.FindElement(By.Id("RegButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Label7")));

        }

        [Test]
        public void invalidUser_Registration()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input an existing user into registration
            driver.FindElement(By.Id("TxtBoxNewU")).SendKeys("houCougars");
            driver.FindElement(By.Id("TextBoxNewPass")).SendKeys("spring2020");
            driver.FindElement(By.Id("ConfirmTextBox1")).SendKeys("spring2020");
            driver.FindElement(By.Id("RegButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Label7")));
            driver.FindElement(By.Id("TxtBoxNewU")).Clear();

        }

        [Test]
        public void NonMatchingPass_Registration()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Input incorrect passwords while registering
            driver.FindElement(By.Id("TxtBoxNewU")).SendKeys("sd2020");
            driver.FindElement(By.Id("TextBoxNewPass")).SendKeys("spring");
            driver.FindElement(By.Id("ConfirmTextBox1")).SendKeys("spring2020");
            driver.FindElement(By.Id("RegButton")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Label7")));
            driver.FindElement(By.Id("TxtBoxNewPass")).Clear();
            driver.FindElement(By.Id("ConfirmTextBox1")).Clear();

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }


    }     
}