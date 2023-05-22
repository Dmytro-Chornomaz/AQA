using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.com
{
    public class Booking
    {
        Driver driver;

        [SetUp]
        public void Init()
        {            
            driver = new DriverFactory().GetDriverByName("chrome");
            driver.GoToUrl("https://www.booking.com/index.en-gb.html");
        }

        [Test]
        public void Test()
        {
            string city = "New York";

            SelectDestination(driver, city);

            FindAndClickCheckInCheckOut(driver);

            DateTime checkInDate = DateTime.Now.AddDays(1);
            string checkInYear = checkInDate.Year.ToString();
            string checkInMonth = ((Months)checkInDate.Month).ToString();
            string checkInDay = checkInDate.Day.ToString();

            DateTime checkOutDate = checkInDate.AddDays(5);
            string checkOutYear = checkOutDate.Year.ToString();
            string checkOutMonth = ((Months)checkOutDate.Month).ToString();
            string checkOutDay = checkOutDate.Day.ToString();

            SelectMonthAndDay(driver, checkInMonth, checkInDay, checkOutMonth, checkOutDay);

            FindSearchButttonAndClick(driver);

            VerifyThatEveryHotelContainsCity(driver, city);

            VerifyTheFirstDateIsDisplayedInSearch(driver, checkInDay, checkInMonth);

            VerifyTheSecondDateIsDisplayedInSearch(driver, checkOutDay, checkOutMonth);

            static void SelectDestination(Driver driver, string destination)
            {
                Element txtDestination = driver.FindElementByXpath("//input[@name='ss']");
                txtDestination.Clear();
                txtDestination.SendKeys(destination);
            }

            static void FindAndClickCheckInCheckOut(Driver driver)
            {
                Element btnDate = driver.FindElementByXpath("//button[text()='Check-in date']");
                btnDate.Click();
            }

            static void SelectMonthAndDay(Driver driver, string checkInMonth, string checkInDay, string checkOutMonth, string checkOutDay)
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

            static void FindSearchButttonAndClick(Driver driver)
            {
                Element searchButton = driver.FindElementByXpath("//span[normalize-space()='Search']");
                searchButton.Click();
            }

            static void VerifyThatEveryHotelContainsCity(Driver driver, string city)
            {
                List<Element> hotels = driver.FindElementsByXpath("//div[@data-testid='property-card']");
                foreach (var hotel in hotels)
                {
                    Element hotelAddress = hotel.FindElementByXpath(".//span[@data-testid='address']");
                    string hotelAddressText = hotelAddress.GetText();
                    StringAssert.Contains(city, hotelAddressText, $"Actual hotel address doesn`t contain {city}");
                }
            }

            static void VerifyTheFirstDateIsDisplayedInSearch(Driver driver, string checkInDay, string checkInMonth)
            {
                string actualDateStart = driver.FindElementByXpath
                ("//button[@data-testid='date-display-field-start']").GetText();
                string actualDayStart = actualDateStart.Split(' ')[1];
                string actualMonthStart = actualDateStart.Split(' ')[2];
                Assert.AreEqual(checkInDay, actualDayStart, "Check-in day is not equal to expexted");
                StringAssert.Contains(checkInMonth, actualMonthStart, "Check-in month is not equal to expexted");
            }

            static void VerifyTheSecondDateIsDisplayedInSearch(Driver driver, string checkOutDay, string checkOutMonth)
            {
                string actualDateEnd = driver.FindElementByXpath
                ("//button[@data-testid='date-display-field-end']").GetText();
                string actualDayEnd = actualDateEnd.Split(' ')[1];
                string actualMonthEnd = actualDateEnd.Split(' ')[2];
                Assert.AreEqual(checkOutDay, actualDayEnd, "Check-out day is not equal to expexted");
                StringAssert.Contains(checkOutMonth, actualMonthEnd, "Check-out month is not equal to expexted");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.CloseDriver();
        }
    }
}
