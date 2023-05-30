using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Framework
{
    public class Driver
    {
        public IWebDriver driver { get; set; }
        public Driver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }

        public Element FindElementByXpath(string xPath)
        {
            return new Element(driver.FindElement(By.XPath(xPath)));
        }

        public void CloseDriver()
        {
            driver.Close();
        }

        public List<Element> FindElementsByXpath(string xPath)
        {
            var elements = driver.FindElements(By.XPath(xPath));
            var result = elements.Select(x => new Element(x));
            return result.ToList();
        }
    }
}
