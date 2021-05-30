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

namespace SpecFlowProject.service
{
    class ProductService
    {
        public static All_products_page CreateProduct(IWebDriver driver)
        {
            Home_page home = UserService.LoginService(driver);
            All_products_page allproducts1 = home.ExecuteAllProducts();
            ProductPage createproduct = allproducts1.ExecuteCreate();
            All_products_page allproducts2 = createproduct.ExecuteCreateProduct();
            return new All_products_page(driver);
        }
    }
}
