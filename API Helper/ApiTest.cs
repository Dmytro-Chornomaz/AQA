using NUnit.Framework;
using Booking_Tests;

namespace API_Helper
{
    public class ApiTest : BaseTest
    {
        [Test]
        public void ApiSampleTest()
        {
            try
            {
                PetStoreClient petStoreClient = new PetStoreClient();

                string result = petStoreClient.CreatePet();

                StringAssert.Contains("Peach", result);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                TakeScreenshot();
                throw ex;
            }
            
        }

        [Test]
        public void OneMoreApiSampleTest()
        {
            try
            {
                PetStoreClient petStoreClient = new PetStoreClient();

                string result = petStoreClient.GetPetById(3232);

                StringAssert.Contains("Peach", result);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                TakeScreenshot();
                throw ex;
            }
            
        }
    }
}
