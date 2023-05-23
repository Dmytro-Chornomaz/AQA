using NUnit.Framework;
using POM_page_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithWrongEmailAndPassword()
        {
            InitPage initPage = new InitPage(driver);
            LoginPage loginPage = initPage.header.ClickLogin();
            
            loginPage.SetEmail("text@text.text");
            loginPage.SetPassword("password");
            Thread.Sleep(1000);
            loginPage.ClickLogin();
            Thread.Sleep(1000);

            string actualErrorMessage = loginPage.GetErrorMessage();
            string expectedErrorMessage = "Неправильное имя пользователя или пароль.";

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "User didn`t get or got wrong error message");

            
        }
    }
}
