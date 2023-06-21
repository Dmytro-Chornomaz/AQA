using Newtonsoft.Json;

namespace Booking_Framework
{
    public static class ParametersResolver
    {
        public static T Resolve<T>(string jsonFile)
        {
            string json = File.ReadAllText(jsonFile);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
