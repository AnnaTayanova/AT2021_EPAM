﻿using System;
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
    public class All_products_page: Abstract_page
    {
        public All_products_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create new')]")]
        public IWebElement buttonCreateNew;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Chocolate cupcake with cherry')]")]
        public IWebElement selectedProduct;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Chocolate cupcake with cherry')]/parent::td/following-sibling::td/a[contains(@href, 'Remove')]")]
        public IWebElement deleteProduct;


        public ProductPage ExecuteCreate()
        {
            buttonCreateNew.Click();
            return new ProductPage(driver);
        }

        public All_products_page ExecuteDelete()
        {
            deleteProduct.Click();
            driver.SwitchTo().Alert().Accept();
            return new All_products_page(driver);
        }

        public ProductPage ViewSelected()
        {
            selectedProduct.Click();
            return new ProductPage(driver);
        }
    }
}
