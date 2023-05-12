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

        [Test]
        public void StringAsserts()
        {
            Assert.Multiple(() => 
            {
                StringAssert.Contains("tasha", "Natasha", "Error message");
                StringAssert.DoesNotContain("tosha", "Natasha", "Error message");
                StringAssert.AreEqualIgnoringCase("natasha", "NATASHA", "Error message");
                StringAssert.AreNotEqualIgnoringCase("notasha", "NATASHA", "Error message");
                StringAssert.StartsWith("Na", "Natasha", "Error message");
                StringAssert.DoesNotStartWith("Ma", "Natasha", "Error message");
                StringAssert.EndsWith("a", "Natasha", "Error message");
                StringAssert.DoesNotEndWith("o", "Natasha", "Error message");
            });
        }

        [Test]
        public void CollectionAsserts()
        {
            List<int> intList = new List<int>() { 1, 3, 5, 7, 9};
            List<int> intList2 = new List<int>() { 1, 3, 5, 7, 9 };
            List<int> intList3 = new List<int>() { 1, 3, 5, 7, 9, 52 };
            List<int> intList4 = new List<int>() { 52, 3, 5, 7, 9, 1 };
            List<int> intList5 = new List<int>();
            List<int> intList6 = new List<int>() { 1, 2, 3, 4, 5, 6};

            CollectionAssert.AreEqual(intList, intList2, "Error message");
            CollectionAssert.AreNotEqual(intList, intList3, "Error message");
            CollectionAssert.AreEquivalent(intList3, intList4, "Error message");
            CollectionAssert.AreNotEquivalent(intList2, intList3, "Error message");
            CollectionAssert.Contains(intList, 3, "Error message");
            CollectionAssert.DoesNotContain(intList, 4, "Error message");
            CollectionAssert.AllItemsAreInstancesOfType(intList4, typeof(int), "Error message");
            CollectionAssert.AllItemsAreNotNull(intList, "Error message");
            CollectionAssert.IsNotEmpty(intList, "Error message");
            CollectionAssert.IsEmpty(intList5, "Error message");
            CollectionAssert.IsNotEmpty(intList4, "Error message");
            CollectionAssert.AllItemsAreUnique(intList2, "Error message");
            CollectionAssert.IsSubsetOf(intList2, intList3, "Error message");
            CollectionAssert.IsSupersetOf(intList3, intList2, "Error message");
            CollectionAssert.IsOrdered(intList6, "Error message");
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        } 
    }
}
