﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    internal class TestClass2
    {
        [Test]

        public void SearchListOfElements()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--disable-notifications");
            //options.AddArguments("disable-infobars");

            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            List<IWebElement> products = driver.FindElements(By.XPath
                ("//div[@class='products__item']//div[@class='products__item_caption']")).ToList();

            foreach (IWebElement product in products)
            {
                IWebElement productName = product.FindElement(By.XPath("./a"));

                string _productName = productName.Text;

                List<IWebElement> elementPricesList = product.FindElements(By.XPath
                    (".//div[contains(@class, 'products__item_price')]")).ToList();

                IWebElement correctPrice = null;

                foreach (var elementPrice in elementPricesList)
                {
                    string elementPriceClass = elementPrice.GetAttribute("class");

                    if (!elementPriceClass.Contains("old") &&
                        !elementPriceClass.Contains("wrapper"))
                    {
                        correctPrice = elementPrice;
                    }
                }

                if (correctPrice == null)
                {
                    throw new AssertionException
                        ($"There is no correct price for product {_productName}");
                }

                string _correctPrice = correctPrice.Text;

                Console.WriteLine($"Product name: {_productName}");

                Console.WriteLine($"Product price: {_correctPrice}");
            }


        }
    }
}
