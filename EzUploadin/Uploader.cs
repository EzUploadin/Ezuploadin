using System;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace EzUploadin
{
    public class Uploader
    {

        /// <summary>
        /// Uploader base class
        /// </summary>
        public Uploader()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler.Handle);

            Log.I("Starting uploader v" + Info.version);
            Authentication.Authenticate();
        }
    }
}