using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace AQA_1
{
    public class ActionsTest
    {
        ChromeDriver driver;

        [Test]
        public void WriteTextWithShift()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com/");

            Actions actions = new Actions(driver);

            IWebElement input = driver.FindElement(By.XPath("//*[@name='q']"));            

            actions.KeyDown(Keys.Shift).SendKeys("hello").KeyUp(Keys.Shift).Perform();          
        }

        [Test]
        public void DragAndDrop()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");

            Actions actions = new Actions(driver);
            
            IWebElement frame = driver.FindElement(By.XPath("//iframe[@class='demo-frame']"));

            driver.SwitchTo().Frame(frame);

            IWebElement draggable = driver.FindElement(By.Id("draggable"));
            IWebElement droppable = driver.FindElement(By.Id("droppable"));
            IWebElement droppableChild = droppable.FindElement(By.TagName("p"));

            Console.WriteLine(droppableChild.Text);

            actions.DragAndDrop(draggable, droppable).Perform();

            droppableChild = droppable.FindElement(By.TagName("p"));
            Assert.AreEqual("Dropped!", droppableChild.Text);

            driver.Quit();
        }
    }
}
