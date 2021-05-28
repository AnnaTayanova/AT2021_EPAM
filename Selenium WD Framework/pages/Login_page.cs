using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Selenium_WD_Framework.pages;
using Selenium_WD_Framework.service;
using Selenium_WD_Framework.dto;

namespace Selenium_WD_Framework.pages
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
            User user = new User();
            new Actions(driver).SendKeys(login, user.Login).Build().Perform();
            new Actions(driver).SendKeys(password,user.Password).Build().Perform();
            new Actions(driver).Click(buttonSubmit).Build().Perform();
            return new Home_page(driver);
        }
    }
}
