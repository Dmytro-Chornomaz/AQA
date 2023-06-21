using Booking_Framework;

namespace Booking_Page_Objects
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(Driver driver) : base(driver) { }

        //private List<Element> hotelsList => driver.FindElementsByXpath("//div[@data-testid='property-card']");

        private Element ActualDateStart => driver.FindElementByXpath
            ("//button[@data-testid='date-display-field-start']");
        private Element ActualDateEnd = driver.FindElementByXpath
            ("//button[@data-testid='date-display-field-end']");

        public string GetActualDateStartText() => ActualDateStart.GetText();
        public string GetActualDateEndText() => ActualDateEnd.GetText();

        public List<string> GetHotelsAdresses()
        {
            List<string> result = new List<string>();
            List<Element> hotelsList = driver
                .FindElementsByXpath("//div[@data-testid='property-card']//span[@data-testid='address']");

            foreach (var hotel in hotelsList)
            {
                //Element hotelAddress = hotel.FindElementByXpath(".//span[@data-testid='address']");
                string hotelAddressText = hotel.GetText();
                result.Add(hotelAddressText);
            }
            return result;
        }
    }
}
