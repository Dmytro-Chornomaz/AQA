using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Framework
{
    public class Element
    {
        public IWebElement element { get; set; }

        public Element(IWebElement element)
        {
            this.element = element;
        }

        public void Click()
        {
            element.Click();
        }

        public void Clear()
        {
            element.Clear();
        }

        public void SendKeys(string key)
        {
            element.SendKeys(key);
        }

        public Element FindElementByXpath(string xPath)
        {
            return new Element(element.FindElement(By.XPath(xPath)));
        }

        public string GetText()
        {
            return element.Text;
        }
    }
}
