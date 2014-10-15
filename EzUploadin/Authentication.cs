using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EzUploadin
{
    class Authentication
    {
        static internal void Authenticate()
        {
            AuthResponse auth;
            if(TokenFileExists())
            {
                auth = LoginWithKey();
            }
            else
            {
                auth = LoginWithCreds();
            }
            switch(auth.Success)
            {
                case true:
                    break;
                case false:
                    throw new AuthError(auth.ErrorMessage);
                    break;
                default:
                    break;
            }
            
        }

        private static AuthResponse LoginWithCreds()
        {
            NetworkCredential cred = new NetworkCredential();
            Credui.GetCredentialsVistaAndUp(Settings.ServerName, out cred);
            string Password = Security.HashPassword(cred.Password);
            
            NameValueCollection coll = new NameValueCollection();
            coll.Add("u", cred.UserName);
            coll.Add("p", Password);

            WebClient client = new WebClient();
            string json = Encoding.Default.GetString(
                client.UploadValues(
                Settings.URL + URLs.AUTH + "?mode=login", coll));
            AuthResponse jsoned = JsonConvert.DeserializeObject<AuthResponse>(json);
            return jsoned;
        }

        private static AuthResponse LoginWithKey()
        {
            NameValueCollection coll = new NameValueCollection();
            coll.Add("id", Security.CPUinfo());

            WebClient client = new WebClient();
            string json = Encoding.Default.GetString(
                client.UploadValues(
                Settings.URL + URLs.AUTH + "?mode=key", coll));
            return JsonConvert.DeserializeObject<AuthResponse>(json);
        }

        private static bool TokenFileExists()
        {
            if(File.Exists("ezuploading.dat"))
            {
                return File.ReadAllBytes("ezuploading.dat").Length != 0;
            }
            return false;
        }
    }
    internal class AuthResponse
    {
        [JsonProperty("Success")]
        internal bool Success;

        [JsonProperty("ErrorCode")]
        internal int ErrorCode;

        [JsonProperty("ErrorMessage")]
        internal string ErrorMessage;
    }

    public class AuthError : Exception
    {
        public AuthError() : base() { }
        public AuthError(string message) : base(message) { }
        public AuthError(string message, Exception e) : base(message, e) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client.
        protected AuthError(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
