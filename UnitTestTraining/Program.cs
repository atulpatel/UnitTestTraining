using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            IClock myclock = new Clock();
            var todaySalutation = new TodaySalutation(myclock);
            Console.WriteLine(todaySalutation.Salutation());
            Console.ReadKey();
        }
    }

    public static class StringConstant
    {
        public static string MORNING = "Hi Good Morning";
        public static string AFTERNOON = "Hi Good Afternoon";
        public static string EVENING = "Hi Good Evening";
    }

    public class TodaySalutation
    {
        private readonly IClock _clock;

        public TodaySalutation(IClock clock)
        {
            _clock = clock;
        }

        public string Salutation()
        {
            var currenttime = _clock.Now;
            if (currenttime.Hour < 12)
            {
                return StringConstant.MORNING;
            }
            if (currenttime.Hour >= 12 && currenttime.Hour <= 17)
            {
                return StringConstant.AFTERNOON;
            }
            if (currenttime.Hour > 17)
            {
                return StringConstant.EVENING;
            }
            return "";
        }
    }



}
