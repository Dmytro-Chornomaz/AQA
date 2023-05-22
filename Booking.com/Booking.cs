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
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-web-security");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--allow-insecure-localhost");
            options.AcceptInsecureCertificates = true;
            //options.AcceptInsecureCertificatesFromSource = true;
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            options.AddUserProfilePreference("profile.block_third_party_cookies", false);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("password_manager_enabled", false);
            options.AddExcludedArgument("enable-automation");

            driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.booking.com/index.en-gb.html");

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

            static void SelectDestination(IWebDriver driver, string destination)
            {
                IWebElement txtDestination = driver.FindElement(By.XPath("//input[@name='ss']"));
                txtDestination.Clear();
                txtDestination.SendKeys(destination);
            }

            static void FindAndClickCheckInCheckOut(IWebDriver driver)
            {
                IWebElement btnDate = driver.FindElement(By.XPath("//button[text()='Check-in date']"));
                btnDate.Click();
            }

            static void SelectMonthAndDay(IWebDriver driver, string checkInMonth, string checkInDay, string checkOutMonth, string checkOutDay)
            {
                IWebElement leftWindow = driver.FindElement(By.XPath
                ($"//div[@data-testid='searchbox-datepicker-calendar']//h3[text()='{checkInMonth}']/.."));
                IWebElement CheckInDateToPick = leftWindow.FindElement(By.XPath($".//*[text()='{checkInDay}']"));
                CheckInDateToPick.Click();

                IWebElement rightWindow = driver.FindElement(By.XPath
                    ($"//div[@data-testid='searchbox-datepicker-calendar']//h3[text()='{checkOutMonth}']/.."));
                IWebElement CheckOutDateToPick = rightWindow.FindElement(By.XPath($".//*[text()='{checkOutDay}']"));
                CheckOutDateToPick.Click();
            }

            static void FindSearchButttonAndClick(IWebDriver driver)
            {
                IWebElement searchButton = driver.FindElement(By.XPath("//span[normalize-space()='Search']"));
                searchButton.Click();
            }

            static void VerifyThatEveryHotelContainsCity(IWebDriver driver, string city)
            {
                List<IWebElement> hotels = driver.FindElements(By.XPath("//div[@data-testid='property-card']")).ToList();
                foreach (var hotel in hotels)
                {
                    IWebElement hotelAddress = hotel.FindElement(By.XPath(".//span[@data-testid='address']"));
                    string hotelAddressText = hotelAddress.Text;
                    StringAssert.Contains(city, hotelAddressText, $"Actual hotel address doesn`t contain {city}");
                }
            }

            static void VerifyTheFirstDateIsDisplayedInSearch(IWebDriver driver, string checkInDay, string checkInMonth)
            {
                string actualDateStart = driver.FindElement(By.XPath
                ("//button[@data-testid='date-display-field-start']")).Text;
                string actualDayStart = actualDateStart.Split(' ')[1];
                string actualMonthStart = actualDateStart.Split(' ')[2];
                Assert.AreEqual(checkInDay, actualDayStart, "Check-in day is not equal to expexted");
                StringAssert.Contains(checkInMonth, actualMonthStart, "Check-in month is not equal to expexted");
            }

            static void VerifyTheSecondDateIsDisplayedInSearch(IWebDriver driver, string checkOutDay, string checkOutMonth)
            {
                string actualDateEnd = driver.FindElement(By.XPath
                ("//button[@data-testid='date-display-field-end']")).Text;
                string actualDayEnd = actualDateEnd.Split(' ')[1];
                string actualMonthEnd = actualDateEnd.Split(' ')[2];
                Assert.AreEqual(checkOutDay, actualDayEnd, "Check-out day is not equal to expexted");
                StringAssert.Contains(checkOutMonth, actualMonthEnd, "Check-out month is not equal to expexted");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
