using System;
using TechTalk.SpecFlow;
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

namespace SpecFlowProject.Steps
{
    [Binding]
    public class Northwind_LoginSteps
    {

        private IWebDriver driver;


        [Given(@"I open url ""(.*)""")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(url);
        }
        
        [Given(@"I type in field login ""(.*)""")]
        public void GivenITypeInFieldLogin(string login)
        {
            new Login_page(driver).login.SendKeys(login);
        }
        
        [Given(@"I type in field password ""(.*)""")]
        public void GivenITypeInFieldPassword(string password)
        {
            new Login_page(driver).password.SendKeys(password);
        }
        
        [When(@"I click button Submit")]
        public void WhenIClickButonSubmit()
        {
            new Login_page(driver).buttonSubmit.Click();
        }
        
        [Then(@"I taken to the home page")]
        public void ThenITakenToTheHomePage()
        {
            Assert.AreEqual("Logout", new Home_page(driver).logout.Text);
        }
    }
}