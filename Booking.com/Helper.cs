using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Framework
{
    public static class Helper
    {
        public static void Wait(int seconds) => Thread.Sleep(seconds * 1000);
    }
}
