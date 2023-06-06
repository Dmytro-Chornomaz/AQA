using Booking_Framework;
using Booking_Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_1
{
    public class JavaScriptExecutorTest : BaseTest
    {
        [Test]
        public void JSTest()
        {
            driver.ExecuteJSCommand("window.scrollTo(0, document.body.scrollHeight);");
            Helper.Wait(3);
            logger.Info("This is Info");
            logger.Warn("This is Warn");
            logger.Error("This is Error");
            logger.Debug("This is Debug");
        }
    }
}
