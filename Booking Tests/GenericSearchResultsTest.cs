using Booking_Framework;
using Booking_Page_Objects;
using NUnit.Framework;


namespace Booking_Tests
{
    public class GenericSearchResultsTest : BaseTest
    {
        [Test]
        public void VerifyGenericSearchResults()
        {
            string city = "New York";
            InitialPage initialPage = new InitialPage(driver);
            SearchResultPage searchResultPage = new SearchResultPage(driver);

            Console.WriteLine($"Selecting destination - {city}");
            initialPage.FillDestination(city);

            Console.WriteLine("Click on Check-In/Check-Out button");
            initialPage.ClickDate();

            DateTime checkInDate = DateTime.Now.AddDays(1);
            string checkInYear = checkInDate.Year.ToString();
            string checkInMonth = ((Months)checkInDate.Month).ToString();
            string checkInDay = checkInDate.Day.ToString();

            DateTime checkOutDate = checkInDate.AddDays(5);
            string checkOutYear = checkOutDate.Year.ToString();
            string checkOutMonth = ((Months)checkOutDate.Month).ToString();
            string checkOutDay = checkOutDate.Day.ToString();

            Console.WriteLine("Selecting monts and day");
            initialPage.SelectMonthAndDay(checkInMonth, checkInDay, checkOutMonth, checkOutDay);

            Console.WriteLine("Clicking search button");
            initialPage.ClickSearch();

            Console.WriteLine("Getting a list of hotels");
            List<string> hotelAdresses = searchResultPage.GetHotelsAdresses();
            foreach (var hotelAdress in hotelAdresses)
            {
                StringAssert.Contains(city, hotelAdress, $"Actual hotel address doesn`t contain {city}");
            }

            string actualDateStart = searchResultPage.GetActualDateStartText();
            string actualDateEnd = searchResultPage.GetActualDateEndText();

            VerifyTheFirstDateIsDisplayedInSearch(actualDateStart, checkInDay, checkInMonth);
            VerifyTheSecondDateIsDisplayedInSearch(actualDateEnd, checkOutDay, checkOutMonth);
        }
        private void VerifyTheFirstDateIsDisplayedInSearch(string actualDateStart, string checkInDay, string checkInMonth)
        {
            Console.WriteLine($"Verify that first date {actualDateStart} is dispayed in search");
            string actualDayStart = actualDateStart.Split(' ')[1];
            string actualMonthStart = actualDateStart.Split(' ')[2];
            Assert.AreEqual(checkInDay, actualDayStart, "Check-in day is not equal to expexted");
            StringAssert.Contains(checkInMonth, actualMonthStart, "Check-in month is not equal to expexted");
            Console.WriteLine("Date is successfully displayed");
        }
        private void VerifyTheSecondDateIsDisplayedInSearch(string actualDateEnd, string checkOutDay, string checkOutMonth)
        {
            Console.WriteLine($"Verify that second date {actualDateEnd} is dispayed in search");
            string actualDayEnd = actualDateEnd.Split(' ')[1];
            string actualMonthEnd = actualDateEnd.Split(' ')[2];
            Assert.AreEqual(checkOutDay, actualDayEnd, "Check-out day is not equal to expexted");
            StringAssert.Contains(checkOutMonth, actualMonthEnd, "Check-out month is not equal to expexted");
            Console.WriteLine("Date is successfully displayed");
        }
    }
}