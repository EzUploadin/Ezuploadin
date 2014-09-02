using System;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace EzUploadin
{
    public class Uploader
    {
        internal string URL;
        internal string ServerName;
        internal int    Port;

        /// <summary>
        /// Uploader base class
        /// </summary>
        /// <param name="Url">The server's URL</param>
        /// <param name="Port">The serer's Port</param>
        public Uploader(string Url, int Port, string ServerName)
        {
            this.URL = Url;
            this.Port = Port;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Endpoint"></param>
        public Uploader(IPEndPoint Endpoint, string ServerName)
        {
            this.URL = Endpoint.Address.ToString();
            this.Port = Endpoint.Port;
            this.ServerName = ServerName;
            Authentication.Authenticate(this);
        }
    }
}