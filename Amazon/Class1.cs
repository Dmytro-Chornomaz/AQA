using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon
{
    public class Class1
    {
        IWebDriver driver;

        [Test]
        public void TestByClassName()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://amazon.com");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.ClassName("navFooterBackToTopText"));

            string text = element.Text;
        }


        [Test]
        public void TestById()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://amazon.com");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.Id("nav-cart-count"));

            element.Click();
        }

        [Test]
        public void TestByName()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://amazon.com");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.Name("dropdown-selection-ubb"));

            string text = element.GetAttribute("id");
        }


        [Test]
        public void TestByLinkText()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://amazon.com");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.LinkText("Start here."));

            string text = element.GetAttribute("href");
        }


        [Test]
        public void TestByPartialLinkText()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.guru99.com/test/accessing-link.html");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.PartialLinkText("go"));

            string text = element.GetAttribute("href");

            Console.WriteLine(text);

            Console.ReadLine();
        }

        [Test]
        public void TestByTagName()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.TagName("h1"));

            string text = element.Text;
   
        }

        [Test]
        public void TestByXPath()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.XPath("//h1"));

            string text = element.Text;

        }

        [Test]
        public void TestByCssSelector()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.CssSelector("div.page-header > h1"));

            string text = element.Text;

        }

        [TearDown]

        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}