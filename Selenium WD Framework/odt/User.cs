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

namespace Selenium_WD_Framework.dto
{
    class User
    {
        public String Login { get; set; }
        public String Password { get; set; }

        public User()
        {
            Login = "user";
            Password = "user";
        }
    }
}
