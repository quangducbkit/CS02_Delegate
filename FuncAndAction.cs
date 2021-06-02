using System;

namespace CS02_Delegate
{
    public class FuncAndAction
    {
        Func<int, int, int> twoIntNumFunc;
        Action<string> showLogAct;
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        public int Min(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        }

        public void SumWithCallBack(int a, int b, Action<string> callback)
        {
            int sum = a + b;
            callback(sum.ToString());

        }

        public void Test()
        {
            twoIntNumFunc = null;
            int a = 5;
            int b = 1;
            twoIntNumFunc = Max;
            Console.WriteLine(string.Format("max({0},{1})={2}",a, b,twoIntNumFunc(a,b)));
            twoIntNumFunc = Sum;
            Console.WriteLine(string.Format("sum({0},{1})={2}",a, b,twoIntNumFunc(a,b)));
            twoIntNumFunc = Min;
            Console.WriteLine(string.Format("min({0},{1})={2}",a, b,twoIntNumFunc(a,b)));

            TestShowLogs testShowLogs = new TestShowLogs();
            showLogAct = testShowLogs.Info;
            showLogAct += testShowLogs.Warning;
            showLogAct("Message from Action");

            showLogAct = testShowLogs.Info;
            SumWithCallBack(a,b,showLogAct);
        }


    }
}