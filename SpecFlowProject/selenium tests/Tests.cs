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

namespace SpecFlowProject
{
    class Tests : TestStartData
    {
        [Test]
        public void Login()
        {
            Home_page home = UserService.LoginService(driver);

            Assert.AreEqual("Logout", home.logout.Text);
        }

        [Test]
        public void Logout()
        {
            Home_page home = UserService.LoginService(driver);

            Login_page logout = home.ExecuteLogout();
            Assert.IsFalse(driver.PageSource.Contains("Logout"));
        }

        [Test]
        public void AddProduct()
        {
            All_products_page allproducts = ProductService.CreateProduct(driver);

            IWebElement buttonCreateNew = driver.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
            Assert.AreEqual("Create new", buttonCreateNew.Text);
        }

        [Test]
        public void ViewProduct()
        {

            Home_page home = UserService.LoginService(driver);

            All_products_page allproducts = home.ExecuteAllProducts();
            ProductPage page = allproducts.ViewSelected();

            Product product = new Product();

            Assert.AreEqual(product.ProductName, driver.FindElement(By.XPath("//input[@id='ProductName']")).GetAttribute("value"));
            Assert.AreEqual(product.Category, driver.FindElement(By.XPath("//select[@id='CategoryId']//option[@selected='selected']")).Text);
            Assert.AreEqual(product.Supplier, driver.FindElement(By.XPath("//select[@id='SupplierId']//option[@selected='selected']")).Text);
            Assert.AreEqual(product.UnitPrice + ",0000", driver.FindElement(By.XPath("//input[@id='UnitPrice']")).GetAttribute("value"));
            Assert.AreEqual(product.QuanityPerUnit, driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']")).GetAttribute("value"));
            Assert.AreEqual(product.UnitsInStock, driver.FindElement(By.XPath("//input[@id='UnitsInStock']")).GetAttribute("value"));
            Assert.AreEqual(product.UnitsOnOrder, driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']")).GetAttribute("value"));
            Assert.AreEqual(product.ReorderLevel, driver.FindElement(By.XPath("//input[@id='ReorderLevel']")).GetAttribute("value"));
        }

        [Test]
        public void DeleteProduct()
        {
            Home_page home = UserService.LoginService(driver);

            Product product = new Product();

            All_products_page allproducts = home.ExecuteAllProducts();
            All_products_page allporoducts1 = allproducts.ExecuteDelete();

            Assert.IsFalse(driver.PageSource.Contains("$product.ProductName"));
        }
    }
}