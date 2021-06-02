using System;

namespace CS02_Delegate
{
    public class TestShowLogs {

        public delegate void Showlog(string s);
        public void Info(string s)
        {
            Console.WriteLine(string.Format("Info:{0}",s));
        }

        public void Warning(string s)
        {
            Console.WriteLine(string.Format("Warning:{0}",s));
        }

        public void Test() 
        {
            Showlog showlog = null;
            showlog += Info;
            showlog += Warning;
            showlog += (x) => Console.WriteLine($"---Notification:{x}");
            showlog("Message!");
        }
    }
}