using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_1
{
    public class TestAsserts
    {
        ChromeDriver driver;

        [Test]
        public void RegularAsserts()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua");

            IWebElement txtSearch = driver.FindElement(By.XPath("//input[@name='search']"));


            string textToInput = "Hello";
            txtSearch.SendKeys(textToInput);
            txtSearch.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            IWebElement result = driver.FindElement(By.TagName("h1"));
            string actualSearchText = result.Text.Split(' ')[^1];
            //Console.WriteLine("Text is " + actualSearchText);

            Assert.AreEqual(textToInput.ToUpper(), actualSearchText, $"There is no search result {textToInput} in search results page");
            Assert.IsFalse(string.IsNullOrEmpty(actualSearchText), "Actual search result text is null or empty");
            Assert.IsTrue(driver.Url.Contains("search"), $"URL {driver.Url} doesn`t contain the search result");

            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
