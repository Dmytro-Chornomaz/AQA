using Booking_Framework;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;

namespace Booking_Tests
{
    public class BaseTest
    {
        protected Driver driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Init()
        {
            driver = new DriverFactory().GetDriverByName("chrome");
            driver.GoToUrl("https://www.booking.com/index.en-gb.html");
        }

        public void TakeScreenshot()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net7.0", "");
            string finalPath = dir + "Screenshots";
            driver.TakeScreenshot(finalPath);
        }

        [TearDown]
        public void TearDown()
        {
            driver.CloseDriver();
        }

        public void WriteLog(string message)
        {
            TestContext.Out.WriteLine("\n" + message);
        }
    }
}
