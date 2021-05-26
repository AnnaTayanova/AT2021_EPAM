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
    abstract class Abstract_page
    {
        protected IWebDriver driver;
    }
}
