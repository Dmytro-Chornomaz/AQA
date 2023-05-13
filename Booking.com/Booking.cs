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
            IWebElement txtDestination = driver.FindElement(By.XPath("//input[@name='ss']"));
            IWebElement btnDate = driver.FindElement(By.XPath("//button[text()='Check-in date']"));

            
            txtDestination.Clear();
            txtDestination.SendKeys(city);

            btnDate.Click();

            DateTime tomorrow = DateTime.Now.AddDays(1);
            string checkInYear = tomorrow.Year.ToString();
            string checkInMonth = ((Months)tomorrow.Month).ToString();
            string checkInDay = tomorrow.Day.ToString();

            DateTime checkOutDate = tomorrow.AddDays(5);
            string checkOutYear = checkOutDate.Year.ToString();
            string checkOutMonth = ((Months)checkOutDate.Month).ToString();
            string checkOutDay = checkOutDate.Day.ToString();

            IWebElement firstWindow = driver.FindElement(By.XPath
                ($"//div[@data-testid='searchbox-datepicker-calendar']//h3[text()='{checkInMonth}']/.."));
            IWebElement dateToPick = firstWindow.FindElement(By.XPath($".//*[text()='{checkInDay}']"));
            dateToPick.Click();


        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }

    }
}
