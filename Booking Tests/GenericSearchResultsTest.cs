﻿using Booking_Framework;
using Booking_Models;
using Booking_Page_Objects;
using NUnit.Framework;


namespace Booking_Tests
{
    public class GenericSearchResultsTest : BaseTest
    {
        [Test]
        public void VerifyGenericSearchResults()
        {
            try
            {
                string pathToJson = Pathes.MODELS_PATH + "\\SearchResultParams.json";
                SearchResultParams parameters = ParametersResolver.Resolve<SearchResultParams>(pathToJson);

                string city = parameters.City;
                InitialPage initialPage = new InitialPage(driver);
                SearchResultPage searchResultPage = new SearchResultPage(driver);

                WriteLog($"Selecting destination - {city}");
                initialPage.FillDestination(city);

                WriteLog("Click on Check-In/Check-Out button");
                initialPage.ClickDate();

                DateTime checkInDate = DateTime.Now.AddDays(1);
                string checkInYear = checkInDate.Year.ToString();
                string checkInMonth = ((Months)checkInDate.Month).ToString();                
                string checkInDay = checkInDate.Day.ToString();

                DateTime checkOutDate = checkInDate.AddDays(5);
                string checkOutYear = checkOutDate.Year.ToString();
                string checkOutMonth = ((Months)checkOutDate.Month).ToString();
                string checkOutDay = checkOutDate.Day.ToString();

                WriteLog("Selecting monts and day");
                initialPage.SelectMonthAndDay(checkInMonth, checkInDay, checkOutMonth, checkOutDay);

                WriteLog("Clicking search button");
                initialPage.ClickSearch(city);

                WriteLog("Getting a list of hotels");
                List<string> hotelAdresses = searchResultPage.GetHotelsAdresses();
                foreach (var hotelAdress in hotelAdresses)
                {
                    StringAssert.Contains(city, hotelAdress, $"Actual hotel address doesn`t contain {city}");
                }

                //This
                searchResultPage = new SearchResultPage(driver);

                string actualDateStart = searchResultPage.GetActualDateStartText();
                string actualDateEnd = searchResultPage.GetActualDateEndText();

                VerifyTheFirstDateIsDisplayedInSearch(actualDateStart, checkInDay, checkInMonth);
                VerifyTheSecondDateIsDisplayedInSearch(actualDateEnd, checkOutDay, checkOutMonth);
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }
        private void VerifyTheFirstDateIsDisplayedInSearch(string actualDateStart, string checkInDay, string checkInMonth)
        {
            WriteLog($"Verify that first date {actualDateStart} is displayed in search");
            string actualDayStart = actualDateStart.Split(' ')[1];
            string actualMonthStart = actualDateStart.Split(' ')[2];            
            Assert.AreEqual(checkInDay, actualDayStart, "Check-in day is not equal to expexted");
            string checkInMonth3Letters = checkInMonth;
            if (checkInMonth.Length > 3)
            {
                checkInMonth3Letters = checkInMonth.Remove(3); 
            }
            StringAssert.Contains(checkInMonth3Letters, actualMonthStart, "Check-in month is not equal to expexted");
            WriteLog("Date is successfully displayed");
        }
        private void VerifyTheSecondDateIsDisplayedInSearch(string actualDateEnd, string checkOutDay, string checkOutMonth)
        {
            WriteLog($"Verify that second date {actualDateEnd} is displayed in search");
            string actualDayEnd = actualDateEnd.Split(' ')[1];
            string actualMonthEnd = actualDateEnd.Split(' ')[2];
            Assert.AreEqual(checkOutDay, actualDayEnd, "Check-out day is not equal to expexted");
            StringAssert.Contains(checkOutMonth, actualMonthEnd, "Check-out month is not equal to expexted");
            WriteLog("Date is successfully displayed");
        }
    }
}