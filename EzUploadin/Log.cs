using System;
using System.IO;

namespace EzUploadin
{
    class Log
    {
        static internal void L(string key, string Message)
        {
            string msg = String.Format("[{0}][{1}]{2}\n", DateTime.Now.ToShortDateString(), key, Message);
            Console.Write(msg);
            File.AppendAllText(Generic.LogFile, msg);
        }
        static internal void E(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            L("Error", Message);
            Console.ResetColor();
        }
        static internal void I(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            L("Info", Message);
            Console.ResetColor();
        }
        
    }
}
