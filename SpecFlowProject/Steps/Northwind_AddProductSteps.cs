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
    public class Northwind_AddProductSteps
    {
        private IWebDriver driver;

        [Given(@"I open url  ""(.*)""")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(url);
        }
        
        [Given(@"I type in field login  ""(.*)""")]
        public void GivenITypeInFieldLogin(string login)
        {
            new Login_page(driver).login.SendKeys(login);
        }
        
        [Given(@"I type in field password  ""(.*)""")]
        public void GivenITypeInFieldPassword(string password)
        {
            new Login_page(driver).password.SendKeys(password);
        }
        
        [Given(@"I click button  Submit")]
        public void GivenIClickButtonSubmit()
        {
            new Login_page(driver).buttonSubmit.Click();
        }
        
        [Given(@"I click the link  All products")]
        public void GivenIClickTheLinkAllProducts()
        {
            new Home_page(driver).allProducts.Click();
        }
        
        [Given(@"I click button  Create New")]
        public void GivenIClickButtonCreateNew()
        {
            new All_products_page(driver).buttonCreateNew.Click();
        }
        
        [Given(@"I fill all  fields")]
        public void GivenIFillAllFields()
        {
            Product product = new Product();
            SelectElement selectCategoryId = new SelectElement(new ProductPage(driver).categoryId);
            SelectElement selectSuppliersId = new SelectElement(new ProductPage(driver).suppliersId);

            new ProductPage(driver).productName.SendKeys(product.ProductName);
            
            selectCategoryId.SelectByText(product.Category);
            selectSuppliersId.SelectByText(product.Supplier);

            new ProductPage(driver).unitPrice.SendKeys(product.UnitPrice);
            new ProductPage(driver).quantityPerUnit.SendKeys(product.QuanityPerUnit);
            new ProductPage(driver).unitInStock.SendKeys(product.UnitsInStock);
            new ProductPage(driver).unitsOnOrder.SendKeys(product.UnitsOnOrder);
            new ProductPage(driver).reorderLevel.SendKeys(product.ReorderLevel);
        }
        
        [When(@"I click button  Submit")]
        public void WhenIClickButtonSubmit()
        {
            new ProductPage(driver).buttonSubmit.Click();
        }
        
        [Then(@"I taken All products page")]
        public void ThenITakenAllProductsPage()
        {
            Assert.AreEqual("Create new", new All_products_page(driver).buttonCreateNew.Text);
        }
    }
}
