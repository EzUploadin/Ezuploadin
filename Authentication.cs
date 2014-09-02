using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Specialized;

namespace EzUploadin
{
    class Authentication
    {
        static internal void Authenticate(Uploader uploader)
        {
            AuthInfo info = new AuthInfo();
            info.URL = uploader.URL;
            info.ServerName = uploader.ServerName;
            info.Port = uploader.Port;

            if(Generic.DataFileExists)
            {
                
            }
            else
            {
                LogIn(info);
            }
        }

        static internal void LogIn(AuthInfo info)
        {
            NetworkCredential cred = new NetworkCredential();
            Credui.GetCredentialsVistaAndUp(info.ServerName, out cred);
            string Password = Security.HashPassword(cred.Password);
            
            NameValueCollection coll = new NameValueCollection();
            coll.Add("u", cred.UserName);
            coll.Add("p", Password);

            WebClient client = new WebClient();
            Encoding.Default.GetString(client.UploadValues(info.URL + URLs.LOGIN, coll));
        }
    }
    internal class AuthInfo
    {
        internal string URL;
        internal string ServerName;
        internal int Port;
    }
}
