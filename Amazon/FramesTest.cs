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
    public class FramesTest
    {
        IWebDriver driver;

        [Test]
        public void NestedFramesTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
            driver.Manage().Window.Maximize();

            var iframes = driver.FindElements(By.TagName("iframe"));
            IWebElement parentFrame = driver.FindElement(By.XPath(" //*[@id='frame1']"));

            driver.SwitchTo().Frame(parentFrame);

            IWebElement element = driver.FindElement(By.TagName("body"));
            Console.WriteLine(element.Text);

            iframes = driver.FindElements(By.TagName("iframe"));

            driver.SwitchTo().Frame(0);
            var childElement = driver.FindElement(By.TagName("p"));
            Console.WriteLine(childElement.Text);

            driver.SwitchTo().ParentFrame();
            element = driver.FindElement(By.TagName("body"));
            Console.WriteLine(element.Text);

            driver.Quit();
        }

        [Test]
        public void FrameTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            driver.Manage().Window.Maximize();

            var iframes = driver.FindElements(By.TagName("iframe"));
            IWebElement bigFrame = driver.FindElement(By.XPath(" //*[@id='frame1']"));

            driver.SwitchTo().Frame(bigFrame);

            IWebElement element = driver.FindElement(By.XPath("//h1[@id='sampleHeading']"));

            driver.SwitchTo().DefaultContent();
            var outOfFrameElement = driver.FindElement(By.XPath(" //*[@id='framesWrapper']/div"));
            Console.WriteLine(outOfFrameElement.Text);

            driver.Quit();
        }
    }
}
