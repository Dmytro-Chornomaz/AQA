using Booking_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Page_Objects
{
    public class InitialPage : BasePage
    {
        public InitialPage(Driver driver) : base(driver) { }

        private Element txtDestination => driver.FindElementByXpath("//input[@name='ss']");
        private Element searchButton => driver.FindElementByXpath("//span[normalize-space()='Search']");

        public void FillDestination(string destination)
        {
            txtDestination.Clear();
            txtDestination.SendKeys(destination);
        }

        private Element GetBtnDate()
        {           
            Element btnDate = driver.FindElementByXpath("//button[text()='Check-in date']");
            return btnDate;
        }

        public void ClickDate()
        {
            GetBtnDate().Click();
        }

        public void SelectMonthAndDay(string checkInMonth, string checkInDay, string checkOutMonth, string checkOutDay)
        {
            Element leftWindow = driver.FindElementByXpath
            ($"//div[@data-testid='searchbox-datepicker-calendar']//h3[text()='{checkInMonth}']/..");
            Element CheckInDateToPick = leftWindow.FindElementByXpath($".//*[text()='{checkInDay}']");
            CheckInDateToPick.Click();

            Element rightWindow = driver.FindElementByXpath
                ($"//div[@data-testid='searchbox-datepicker-calendar']//h3[text()='{checkOutMonth}']/..");
            Element CheckOutDateToPick = rightWindow.FindElementByXpath($".//*[text()='{checkOutDay}']");
            CheckOutDateToPick.Click();
        }

        public void ClickSearch(string destination)
        {
            searchButton.Click();
            driver.WaitUntilPageTitleContainsText(3, $"Hotels in {destination}");    
        }
    }
}
