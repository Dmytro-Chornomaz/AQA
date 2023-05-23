using NUnit.Framework;
using POM_page_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_tests
{
    public class SmokeTest : BaseTest
    {
        [Test]
        public void VerifyHeaders()
        {
            InitPage initPage = new InitPage(driver);

            var contactsPage = initPage.header.ClickContacts();
            Assert.AreEqual("Контакти", contactsPage.GetHeaderText(), "Header of Contacts page is wrong");

            var deliveryPage = initPage.header.ClickDeliveryAndPayment();
            Assert.AreEqual("Доставка і оплата", deliveryPage.GetHeaderText(), "Header of Delivery page is wrong");

            var warrantyPage = initPage.header.ClickWarrantyAndService();
            Assert.AreEqual("Гарантія та сервіс", warrantyPage.GetHeaderText(), "Header of Warranty page is wrong");

            var certificatesPage = initPage.header.ClickCertificates();
            Assert.AreEqual("Сертифікати", certificatesPage.GetHeaderText(), "Header of Certificates page is wrong");

            var assemblyPage = initPage.header.ClickPCAssembly();
            Assert.AreEqual("Збірка ПК", assemblyPage.GetHeaderText(), "Header of Assembly page is wrong");


        }
    }
}
