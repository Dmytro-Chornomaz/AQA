using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_page_objects
{
    public class HeaderSection : BasePage
    {
        public HeaderSection(IWebDriver driver) : base(driver) { }
        
        private IWebElement btnLogin => driver.FindElement(By.XPath("//a[@href='/login/']"));
        private IWebElement btnContacts => driver.FindElement(By.XPath("//ul[contains(@class, 'site_menu')]/li/a[@href='/ua/contacts/']"));
        private IWebElement btnDeliveryAndPayment => driver.FindElement(By.XPath("//ul[contains(@class, 'site_menu')]/li/a[@href='/ua/payment-and-delivery/']"));
        private IWebElement btnWarrantyAndService => driver.FindElement(By.XPath("//ul[contains(@class, 'site_menu')]/li/a[@href='/ua/warranty-and-service/']"));
        private IWebElement btnCertificates => driver.FindElement(By.XPath("//ul[contains(@class, 'site_menu')]/li/a[@href='/ua/certificates/']"));
        private IWebElement btnPCAssembly => driver.FindElement(By.XPath("//ul[contains(@class, 'site_menu')]/li/a[@href='/ua/pc-building/']"));


        public LoginPage ClickLogin() 
        { 
            btnLogin.Click();
            return new LoginPage(driver);
        }

        public ContactsPage ClickContacts()
        {
            btnLogin.Click();
            return new ContactsPage(driver);
        }

        public DeliveryAndPaymentPage ClickDeliveryAndPayment()
        {
            btnLogin.Click();
            return new DeliveryAndPaymentPage(driver);
        }

        public WarrantyAndServicePage ClickWarrantyAndService()
        {
            btnLogin.Click();
            return new WarrantyAndServicePage(driver);
        }

        public CertificatesPage ClickCertificates()
        {
            btnLogin.Click();
            return new CertificatesPage(driver);
        }

        public PCAssemblyPage ClickPCAssembly()
        {
            btnLogin.Click();
            return new PCAssemblyPage(driver);
        }
    }
}
