using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace First_autotest
{
    public class GoogleSearchClass
    {
        [Test]
        public void GoogleSearch()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://google.com");

            driver.Manage().Window.Maximize();

            IWebElement txtSearch = driver.FindElement(By.Name("q"));

            txtSearch.SendKeys("youtube");

            txtSearch.SendKeys(Keys.Enter);
        }
    }
}