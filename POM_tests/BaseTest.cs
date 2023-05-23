using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POM_tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
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

            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://exe.ua/ua/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}