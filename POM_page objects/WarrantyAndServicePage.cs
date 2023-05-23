using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_page_objects
{
    public class WarrantyAndServicePage : BasePage
    {
        public WarrantyAndServicePage(IWebDriver driver) : base(driver)
        {
            header = new HeaderSection(driver);
        }

        public HeaderSection header;
    }
}