

namespace Booking_Framework
{
    public static class Pathes
    {
        public static string SOLUTION_PATH = AppDomain.CurrentDomain.BaseDirectory
                    .Replace("Booking Tests\\bin\\Debug\\net7.0", "");

        public static string TESTS_PATH = SOLUTION_PATH + "Booking Tests";

        public static string SCREENSOTS_PATH = TESTS_PATH + "Screensots";

        public static string REPORTS_PATH = TESTS_PATH + "Report";

        public static string MODELS_PATH = SOLUTION_PATH + "Booking Models\\bin\\Debug\\net7.0";


    }
}
