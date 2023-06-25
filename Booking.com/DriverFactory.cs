using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Booking_Framework
{
    public class DriverFactory
    {
        public Driver GetDriverByName(BrowsersEnum browser)
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

            switch (browser)
            {
                case BrowsersEnum.Chrome:
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case BrowsersEnum.Firefox:
                    string geckoDriverPath = "D:\\QA\\C#\\AQA\\Booking.com\\bin\\Debug\\net7.0\\geckodriver.exe";
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(geckoDriverPath);
                    driver = new FirefoxDriver(service);
                    break;


                case BrowsersEnum.Headless:
                    ChromeOptions headlessChromeOptions = new ChromeOptions();
                    headlessChromeOptions.AddArguments("--headless");
                    driver = new ChromeDriver(headlessChromeOptions);
                    break;

                default: throw new Exception("You selected a wrong browser");
            }

            return new Driver(driver);
        }
    }
}
