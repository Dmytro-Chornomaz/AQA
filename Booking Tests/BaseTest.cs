using Booking_Framework;
using NUnit.Framework;

namespace Booking_Tests
{
    public class BaseTest
    {
        protected Driver driver;

        [SetUp]
        public void Init()
        {
            driver = new DriverFactory().GetDriverByName("chrome");
            driver.GoToUrl("https://www.booking.com/index.en-gb.html");
        }



        [TearDown]
        public void TearDown()
        {
            driver.CloseDriver();
        }
    }
}
