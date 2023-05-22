using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace Booking.com
{
    public class DriverFactory
    {        
        public Driver GetDriverByName(string browserName)
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-web-security");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--allow-insecure-localhost");
            chromeOptions.AcceptInsecureCertificates = true;
            //chromeOptions.AcceptInsecureCertificatesFromSource = true;
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            chromeOptions.AddUserProfilePreference("profile.block_third_party_cookies", false);
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("password_manager_enabled", false);
            chromeOptions.AddExcludedArgument("enable-automation");

            IWebDriver driver;

            switch (browserName)
            {
                case "chrome":
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    string geckoDriverPath = "D:\\QA\\C#\\AQA\\Booking.com\\bin\\Debug\\net7.0\\geckodriver.exe";
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(geckoDriverPath);
                    driver = new FirefoxDriver(service);
                    break;
                    default: throw new Exception("You selected a wrong browser");

                case "headless":
                    ChromeOptions headlessChromeOptions = new ChromeOptions();
                    headlessChromeOptions.AddArguments("--headless");
                    driver = new ChromeDriver(headlessChromeOptions);
                    break;
            }

            return new Driver(driver);
        }
    }
}
