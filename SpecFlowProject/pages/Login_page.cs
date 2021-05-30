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
using SpecFlowProject.pages;
using SpecFlowProject.service;
using SpecFlowProject.dto;

namespace SpecFlowProject.pages
{
    public class Login_page : Abstract_page
    {
        public Login_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='Name']")]
        public IWebElement login;
        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        public IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement buttonSubmit;

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
