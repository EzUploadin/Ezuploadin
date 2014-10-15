using System;
using System.Windows.Forms;

namespace EzUploadin
{
    class ExceptionHandler
    {
        public static void Handle(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            string ExceptionMsg = String.Format("{0}: {1}", e.GetType().ToString(), e.Message);
            string FullException = String.Format("{0}: {1}\n{2}", e.GetType().ToString(), e.Message, e.StackTrace);
            Log.E(FullException);
            MessageBox.Show(ExceptionMsg, "EzUploadin has crashed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
    }
}