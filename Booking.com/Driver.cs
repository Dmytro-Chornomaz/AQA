﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

        public void WaitUntilElementExists(int secondsToWait, string webElementXPath)
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

        public void ExecuteJSCommand(string command)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;

            javaScriptExecutor.ExecuteScript(command);
        }

        public string TakeScreenshot(string pathToSave)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string title = TestContext.CurrentContext.Test.MethodName +
                DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss");
            FileInfo address = new FileInfo($"{pathToSave}\\");
            string finalScreenshotName = address + title + ".png";

            screenshot.SaveAsFile(finalScreenshotName);

            return finalScreenshotName;
        }
    }

}
