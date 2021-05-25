using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Selenium_WD_Advanced.pages;

namespace Selenium_WD_Advanced.pages
{
    class Login_page : Abstract_page
    {
        public Login_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='Name']")]
        private IWebElement login;
        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement buttonSubmit;

        public Home_page ExecuteLogin()
        {
            new Actions(driver).Click(login).SendKeys("user").Build().Perform();
            new Actions(driver).Click(password).SendKeys("user").Build().Perform();
            new Actions(driver).Click(buttonSubmit).Build().Perform();
            return new Home_page(driver);
        }
    }
}
