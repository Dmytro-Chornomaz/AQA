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
    class NavigationTest
    {
        IWebDriver driver;
        [Test]
        public void TestNavigation()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

        }

        [Test]
        public void TestInterrogation()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            string pageSource = driver.PageSource;
            string title = driver.Title;
            string url = driver.Url;

            driver.SwitchTo().NewWindow(WindowType.Tab);
            string currentWindowHandle = driver.CurrentWindowHandle;
            var allWindowHandles = driver.WindowHandles;
        }

        [Test]
        public void TestNavigationBetweenTabsAndCloseOneTab()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            driver.Manage().Window.Maximize();

            var tabButton = driver.FindElement(By.XPath("//button[@id='tabButton']"));

            string parentWindowHandle = driver.CurrentWindowHandle;

            tabButton.Click();

            var allWindowHandles = driver.WindowHandles.ToList();

            string? secondWindow = allWindowHandles.
                Where(x => x != parentWindowHandle).Select(x => x).FirstOrDefault();

            driver.SwitchTo().Window(secondWindow);

            var sampleHeading = driver.FindElement(By.XPath("//h1"));

            Console.WriteLine(sampleHeading.Text);

            driver.Close();

            driver.SwitchTo().Window(parentWindowHandle);

        }

        [Test]
        public void TestNavigationBetweenTabsAndCloseAllTabs()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            driver.Manage().Window.Maximize();

            var tabButton = driver.FindElement(By.XPath("//button[@id='tabButton']"));

            string parentWindowHandle = driver.CurrentWindowHandle;

            tabButton.Click();

            var allWindowHandles = driver.WindowHandles.ToList();

            string? secondWindow = allWindowHandles.
                Where(x => x != parentWindowHandle).Select(x => x).FirstOrDefault();

            driver.SwitchTo().Window(secondWindow);

            var sampleHeading = driver.FindElement(By.XPath("//h1"));

            Console.WriteLine(sampleHeading.Text);

            driver.Quit();

        }

        [Test]
        public void TestNavigationBetweenWindows()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            driver.Manage().Window.Maximize();


            var windowButtonWrapper = driver.FindElement(By.XPath("//button[@id='windowButton']"));

            string parentWindowHandle = driver.CurrentWindowHandle;

            windowButtonWrapper.Click();

            var allWindowHandles = driver.WindowHandles.ToList();

            string? secondWindow = allWindowHandles.
                Where(x => x != parentWindowHandle).Select(x => x).FirstOrDefault();

            driver.SwitchTo().Window(secondWindow);

            var sampleHeading = driver.FindElement(By.XPath("//h1"));

            Console.WriteLine(sampleHeading.Text);

            driver.SwitchTo().Window(parentWindowHandle);   
        }

        [Test]
        public void TestAlerts()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            driver.Manage().Window.Maximize();

            var alertButton = driver.FindElement(By.Id("alertButton"));
            var confirmButton = driver.FindElement(By.Id("confirmButton"));
            var promtButton = driver.FindElement(By.Id("promtButton"));

            alertButton.Click();
            var alert = driver.SwitchTo().Alert();
            alert.Accept();

            confirmButton.Click();
            driver.SwitchTo().Alert().Dismiss();

            promtButton.Click();
            var text = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().SendKeys("Bertold");
            driver.SwitchTo().Alert().Accept();

            driver.Close();
        }
    }
}
