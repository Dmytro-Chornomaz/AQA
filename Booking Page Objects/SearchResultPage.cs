using Booking_Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Page_Objects
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(Driver driver) : base(driver) { }

        private List<Element> hotelsList => driver.FindElementsByXpath("//div[@data-testid='property-card']");

        private Element actualDateStart => driver.FindElementByXpath
            ("//button[@data-testid='date-display-field-start']");
        private Element actualDateEnd = driver.FindElementByXpath
            ("//button[@data-testid='date-display-field-end']");

        public string GetActualDateStartText() => actualDateStart.GetText();
        public string GetActualDateEndText() => actualDateEnd.GetText();


        public List<string> GetHotelsAdresses()
        {
            List<string> result = new List<string>();

            foreach (var hotel in hotelsList)
            {
                Element hotelAddress = hotel.FindElementByXpath(".//span[@data-testid='address']");
                string hotelAddressText = hotelAddress.GetText();
                result.Add(hotelAddressText);
            }
            return result;
        }
    }
}
