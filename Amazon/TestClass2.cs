using NUnit.Framework;
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

        [Test]
        public void ClickAndSendKeys()
        {
            string mobileModel = "Apple";

            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement txtFilterByManufacturer = driver.FindElement(By.XPath
                ("//*[text()='Виробники']/../following-sibling::div[@class='filter-category__search']//input"));

            txtFilterByManufacturer.SendKeys(mobileModel);

            Thread.Sleep(1000);

            IWebElement checkByMobileModel = driver.FindElement(By.XPath
                ($"//span[text()='{mobileModel}']/parent::div"));


            checkByMobileModel.Click();
        }

        [Test]
        public void TestKeyMethod()
        {
            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement txtsearch = driver.FindElement(By.XPath
                ("//input[@name='search']"));

            txtsearch.SendKeys("Hello!");

            txtsearch.SendKeys(Keys.Backspace);

            txtsearch.SendKeys(Keys.Enter);
        }

        [Test]
        public void TestGetAttributeAndText()
        {
            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement header = driver.FindElement(By.XPath("//h1"));

            string headerText = header.Text;

            string headerClass = header.GetAttribute("class");

            Console.WriteLine($"Text is {headerText}");

            Console.WriteLine($"Class is {headerClass}");

            driver.Close();
        }
    }
}
