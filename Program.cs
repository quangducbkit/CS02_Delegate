using System;

namespace CS02_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            TestShowLogs testShowLogs = new TestShowLogs();
            testShowLogs.Test();
            FuncAndAction funcAndAction = new FuncAndAction();
            funcAndAction.Test();
        }
    }
}
