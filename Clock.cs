using System;
using System.Threading;
namespace CS02_Delegate
{
    // Evnent pulisher
    public class Clock{
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInfomation);

        public event SecondChangeHandler SecondChange;
        public int _hour;
        public int _minute;
        public int _second;

        public void OnSecondChange( object clock, TimeInfoEventArgs timeInfomation)
        {
            if(SecondChange != null)
            {
                SecondChange(clock,timeInfomation);
            }
        }

        public void Run()
        {
            for(;;)
            {
                Thread.Sleep(1000);
                DateTime dt = DateTime.Now;
                if(_second != dt.Second)
                {
                    TimeInfoEventArgs timeInfoEventArgs = new TimeInfoEventArgs(dt.Hour,dt.Minute,dt.Second);
                    OnSecondChange(this,timeInfoEventArgs);
                }
                _second = dt.Second;
                _minute = dt.Minute;
                _hour = dt.Hour;
            }
        }
    
    }

    public class TimeInfoEventArgs{
        public readonly int hour;
        public readonly int minute;
        public readonly int second;

        public TimeInfoEventArgs(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }
    }

    // Event subcriber 1
    public class DisplayClock{
        public void Subcribe(Clock clock)
        {
            clock.SecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }

        public void TimeHasChanged(object clock, TimeInfoEventArgs timeInformation)
        {
            Console.WriteLine("Current time:{0}:{1}:{2}", timeInformation.hour,timeInformation.minute,timeInformation.second);
        }

    }

    // Event subcriber 2
    public class LogClock{
        public void Subcribe(Clock clock)
        {
            clock.SecondChange += new Clock.SecondChangeHandler(WriteLogEntry);
        }

        public void WriteLogEntry(object clock, TimeInfoEventArgs timeInfomation)
        {
            Console.WriteLine("Log to file:{0}:{1}:{2}", timeInfomation.hour, timeInfomation.minute, timeInfomation.second);
        }

    }
}