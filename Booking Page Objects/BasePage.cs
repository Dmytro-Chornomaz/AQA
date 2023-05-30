using Booking_Framework;

namespace Booking_Page_Objects
{
    public class BasePage
    {
        protected static Driver driver;

        public BasePage(Driver webDriver)
        {
            driver = webDriver;
        }
    }
}