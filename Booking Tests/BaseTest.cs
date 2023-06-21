using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Booking_Framework;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ER = AventStack.ExtentReports;

namespace Booking_Tests
{
    public class BaseTest
    {
        protected Driver driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected ER.ExtentReports extentReports;
        protected ER.ExtentTest extentTest;

        struct ContextOfText
        {
            public Status status;
            public string stackTrace;
            public string errorMessage;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var testClassName = TestContext.CurrentContext.Test.ClassName;
            var date = DateTime.Now.ToString(" dd-MM-yyyy_(HH_mm_ss)");
            var outputDir = $"{Pathes.REPORTS_PATH}\\{testClassName}{date}\\";
            var param = "Automation_Report.html";

            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter($"{outputDir}{param}");
            extentReports = new ER.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        [SetUp]
        public void Init()
        {
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.MethodName);
            driver = new DriverFactory().GetDriverByName(BrowsersEnum.Chrome);
            driver.GoToUrl("https://www.booking.com/index.en-gb.html");
        }

        public string TakeScreenshot()
        {
            string dir = Pathes.SCREENSOTS_PATH;
            string screenShotFullName = driver.TakeScreenshot(dir);
            return screenShotFullName;
        }

        private void AddTestHTML(ContextOfText test, string screenshotPath = null)
        {
            string stackTrace = string.IsNullOrEmpty(test.stackTrace) ? "\b<br>" : $"\n<br>{test.stackTrace}\n<br>";
            string errorMessage = string.IsNullOrEmpty(test.errorMessage) ? "\b<br>" : $"\n<br>{test.errorMessage}\n<br>";

            extentTest.Log(test.status, $"Test ended with: {test.status}, {stackTrace}{errorMessage}");
            if (screenshotPath != null)
            {
                AddScreenshotToHTML(test.status, screenshotPath);
            }
        }

        private void AddScreenshotToHTML(Status status, string screenshotPath)
        {
            extentTest.Log(status, $"Screenshot attached: {extentTest.AddScreenCaptureFromPath(screenshotPath)}");
        }

        private Status GetStatus(TestStatus testStatus)
        {
            switch (testStatus)
            {
                case TestStatus.Failed:
                    return Status.Fail;
                case TestStatus.Skipped:
                    return Status.Skip;
                default:
                    return Status.Pass;
            }
        }

        public void WriteLog(string message)
        {
            TestContext.Out.WriteLine("\n" + message);
            logger.Debug(message);
            extentTest.Log(Status.Info, message);
        }

        [TearDown]
        public void TearDown()
        {
            ContextOfText test;
            test.stackTrace = TestContext.CurrentContext.Result.StackTrace;
            test.errorMessage = TestContext.CurrentContext.Result.Message;
            test.status = GetStatus(TestContext.CurrentContext.Result.Outcome.Status);

            if (test.status == Status.Fail)
            {
                AddTestHTML(test, TakeScreenshot());
            }
            else
            {
                AddTestHTML(test);
            }

            driver.CloseDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extentReports.Flush();
        }


    }
}
