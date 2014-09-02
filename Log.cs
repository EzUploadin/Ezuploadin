using System;
using System.IO;

namespace EzUploadin
{
    class Log
    {
        static internal void L(string Message)
        {
            File.AppendAllText(Generic.LogFile, Message);
        }
    }
}
