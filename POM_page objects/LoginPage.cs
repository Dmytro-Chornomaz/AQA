using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_page_objects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        IWebElement txtEmail = driver.FindElement(By.XPath("//input[@name='login']"));
        IWebElement txtPassword = driver.FindElement(By.XPath("//input[@name='password']"));
        IWebElement btnLogin = driver.FindElement(By.XPath("//input[contains(@class, 'btn')]"));
        IWebElement errorMessage = driver.FindElement(By.XPath("//em[@class='wa-error-msg']"));

        public void SetEmail(string email) => txtEmail.SendKeys(email);
        public void SetPassword(string password) => txtPassword.SendKeys(password);
        public void ClickLogin() => btnLogin.Click();
        public string GetErrorMessage() => errorMessage.Text;
    }
}
