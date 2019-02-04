using System;
using System.Collections.Generic;

namespace Helpers
{
   public class Program
    {
        public double TimeAtOffice { get; set; } = 0;
        public List<TimeEvents> events { get; set; } = new List<TimeEvents>
        {
            new TimeEvents(DateTime.Now.AddHours(-12),leaveType.arrive),
            new TimeEvents(DateTime.Now.AddHours(-8),leaveType.leave),
            new TimeEvents(DateTime.Now.AddHours(-7),leaveType.arrive),
            new TimeEvents(DateTime.Now.AddHours(-5),leaveType.leave)
            
        };

        
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CalculateOfficeTime());
            
            Console.ReadLine();
        }

        public double CalculateOfficeTime()
        {
            double officeTime = 0;
            var current = new TimeEvents();
            foreach (var t in events)
            {
                if (t.type==leaveType.leave&&current.type==leaveType.arrive)
                {
                    officeTime += CalculateTimeBetween(current.time, t.time );
                    current = t;
                    Console.WriteLine(officeTime);
                }
                if (t.type==leaveType.arrive)
                {
                    current = t;
                };

                
            }
            return officeTime;
        }

        static bool Compare()
        {
            Console.WriteLine(DateTime.Now.ToString("MM:dd:yyyy")); 
            return true;
        }

        public static bool IsSameDay(DateTime date)
        {
            return DateTime.Now.ToString("MM:dd:yyyy") == date.ToString("MM:dd:yyyy");
        }

        public static double CalculateTimeBetween(DateTime first, DateTime second)
        {
            return second.Subtract(first).TotalHours;
        }

        public class TimeEvents
        {
            public DateTime time { get; set; }
            public leaveType type { get; set; }
            public TimeEvents()
            {

            }

            public TimeEvents(DateTime time, leaveType type)
            {
                this.time = time;
                this.type = type;
            }
        }

        public enum leaveType
        {
            arrive,
            leave
        }


        


    }
}
