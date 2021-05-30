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

namespace SpecFlowProject.dto
{
    public class Product
    {
        public String ProductName { get; set; }
        public String Category { get; set; }
        public String Supplier { get; set; }
        public String UnitPrice { get; set; }
        public String QuanityPerUnit { get; set; }
        public String UnitsInStock { get; set; }
        public String UnitsOnOrder { get; set; }
        public String ReorderLevel { get; set; }

        public Product()
        {
            ProductName = "Chocolate cupcake with cherry";
            Category = "Confections";
            Supplier = "Pavlova, Ltd.";
            UnitPrice = "15";
            QuanityPerUnit = "10 - 150 g boxes";
            UnitsInStock = "20";
            UnitsOnOrder = "0";
            ReorderLevel = "5";
        }

    }
}
