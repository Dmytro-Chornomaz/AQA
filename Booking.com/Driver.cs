using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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

        public void WaitUntilMethodDisappearsFromDOM(int secondsToWait, string webElementXPath)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
                driverWait.Until
                    (d => driver.FindElements(By.XPath(webElementXPath)).ToList().Count == 0);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException
                    ($"Element didn`t disappear from DOM, \n{e.StackTrace}, \n{e.Message}");
            }
            
        }

        public void WautUntilElementExists(int secondsToWait, string webElementXPath)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
                driverWait.Until
                    (ExpectedConditions.ElementExists(By.XPath(webElementXPath)));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException
                    ($"Element didn`t appear in DOM, \n{e.StackTrace}, \n{e.Message}");
            }
        }

        public void WaitUntilPageTitleContainsText(int secondsToWait, string titleText)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
                driverWait.Until
                    (ExpectedConditions.TitleContains(titleText));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException
                    ($"Page doesn`t contains {titleText} in title, \n{e.StackTrace}, \n{e.Message}");
            }
        }
    }

}
