using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_page_objects
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement header = driver.FindElement(By.TagName("h1"));
        public string GetHeaderText() => header.Text;
    }
}
