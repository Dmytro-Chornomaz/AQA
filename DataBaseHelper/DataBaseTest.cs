using Booking_Tests;
using DataBaseHelper.DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseHelper
{
    public class DataBaseTest : BaseTest
    {
        [Test]
        public void SampleTest()
        {
            try
            {
                int testId = 3;

                string userName = UserSql.GetUserNameById(testId);

                Assert.AreEqual("Valeriia", userName, "Got wrong username");
                Assert.AreNotEqual("Nataliia", userName, "");
            }
            catch (Exception ex)
            {
                TakeScreenshot();
                throw ex;
            }
            
        }


        [Test]
        public void OneMoreSampleTest()
        {
            try
            {
                int testId = 3;

                var user = UserSql.GetUserById(testId);

                Assert.AreEqual("Valeriia", user.UserName, "Got wrong username");
                Assert.AreEqual(74561, user.Mobile, "Got wrong mobile");
            }
            catch (Exception ex)
            {
                TakeScreenshot();
                throw ex;
            }
            
        }
    }
}
