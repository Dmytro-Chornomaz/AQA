using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_search
{
    public class TestClass3
    {
        [Test]
        public void TestRadioButton()
        {
            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement rdoOther = driver.FindElement(By.XPath("//input[@value='other']"));
            IWebElement rdoMale = driver.FindElement(By.XPath("//input[@value='male']"));
            IWebElement rdoFemale = driver.FindElement(By.XPath("//input[@value='female']"));

            rdoFemale.Click();

            bool isFemaleSelected = rdoFemale.Selected;
            bool isMaleSelected = rdoMale.Selected;
            bool isOtherSelected = rdoOther.Selected;

            Console.WriteLine("Female: " + isFemaleSelected);
            Console.WriteLine("Male: " + isMaleSelected);
            Console.WriteLine("Other: " + isOtherSelected);

            Console.WriteLine("-------------------------------");

            rdoMale.Click();

            isFemaleSelected = rdoFemale.Selected;
            isMaleSelected = rdoMale.Selected;
            isOtherSelected = rdoOther.Selected;

            Console.WriteLine("Female: " + isFemaleSelected);
            Console.WriteLine("Male: " + isMaleSelected);
            Console.WriteLine("Other: " + isOtherSelected);

            Console.WriteLine("-------------------------------");

            bool isMaleDisplayed = rdoMale.Displayed;
            bool isMaleEnabled = rdoMale.Enabled;

            Console.WriteLine("Is male displayed: " + isMaleDisplayed);
            Console.WriteLine("Is male enabled: " + isMaleEnabled);

            driver.Close();

        }

        [Test]
        public void TestCheckbox()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement chkCar = driver.FindElement(By.XPath("//input[@value='Car']"));
            IWebElement chkBike = driver.FindElement(By.XPath("//input[@value='Bike']"));

            bool isCarChecked = chkCar.Selected;
            bool isBikeChecked = chkBike.Selected;

            Console.WriteLine("Car is checked: " + isCarChecked);
            Console.WriteLine("Bike is checked: " + isBikeChecked);

            Console.WriteLine("-------------------------------------");

            chkCar.Click();
            chkBike.Click();

            isCarChecked = chkCar.Selected;
            isBikeChecked = chkBike.Selected;

            Console.WriteLine("Car is checked: " + isCarChecked);
            Console.WriteLine("Bike is checked: " + isBikeChecked);

            driver.Close();

        }

        [Test]
        public void TestDropdown()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement ddlVehicles = driver.FindElement(By.XPath("//select"));
            SelectElement _ddlVehicles = new SelectElement(ddlVehicles);

            var allSelectedOptions = _ddlVehicles.AllSelectedOptions.ToList();
            allSelectedOptions.ForEach(x => Console.WriteLine("All selected options: " + x.Text));

            bool isMultiple = _ddlVehicles.IsMultiple;
            Console.WriteLine("Is multiple: " + isMultiple);

            var optionsList = _ddlVehicles.Options.ToList();
            optionsList.ForEach(x => Console.WriteLine("Options list: " + x.Text));
            
            var wrappedElement = _ddlVehicles.WrappedElement;
            Console.WriteLine(wrappedElement);
            Console.WriteLine(wrappedElement.Text);
            Console.WriteLine(wrappedElement.TagName);


            _ddlVehicles.SelectByText("Volvo");
            var selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("First selected option: " + selectedOption);
            
            _ddlVehicles.SelectByValue("saab");
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("Second selected option: " + selectedOption);

            _ddlVehicles.SelectByIndex(3);
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("Third selected option: " + selectedOption);

            driver.Close();

        }

        [Test]
        public void TestUL()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement liTab1 = driver.FindElement(By.XPath("//a[text()='Tab 1']"));
            IWebElement liTab2 = driver.FindElement(By.XPath("//a[text()='Tab 2']"));
            IWebElement displayedOption = driver.FindElement(By.XPath
                ("//div[not(contains(@style, 'none'))]/div[@class='et_pb_tab_content']"));

            Console.WriteLine("Displayed option: " + displayedOption.Text);
            
            Console.WriteLine("----------------------------------");

            liTab2.Click();
            Thread.Sleep(1000);
            displayedOption = driver.FindElement(By.XPath
                ("//div[not(contains(@style, 'none'))]/div[@class='et_pb_tab_content']"));

            Console.WriteLine("Displayed option: " + displayedOption.Text);
            
            Console.WriteLine("----------------------------------");

            liTab1.Click();
            Thread.Sleep(1000);
            displayedOption = driver.FindElement(By.XPath
                ("//div[not(contains(@style, 'none'))]/div[@class='et_pb_tab_content']"));

            Console.WriteLine("Displayed option: " + displayedOption.Text);
            
            Console.WriteLine("----------------------------------");

            driver.Close();
        }
    }
}
