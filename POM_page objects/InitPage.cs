using OpenQA.Selenium;

namespace POM_page_objects
{
    public class InitPage : BasePage
    {
        public InitPage(IWebDriver driver) : base(driver) 
        {
            header = new HeaderSection(driver);
        }

        public HeaderSection header;


    }
}