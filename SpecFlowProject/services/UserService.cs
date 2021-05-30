using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SpecFlowProject.pages;
using SpecFlowProject.dto;
using SpecFlowProject.service;

namespace SpecFlowProject.service
{
    class UserService
    {
        public static Home_page LoginService(IWebDriver driver)
        {
            Login_page login = new Login_page(driver);
            Home_page home = login.ExecuteLogin();
            return new Home_page(driver);
        }
    }
}
