using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PayfullApi_sdk.App_Code.Requests
{
    public class Request
    {
        protected string merchant;
        protected string language = "tr";
        protected string clientIp;
        protected string password;
        protected string endpoint;
        protected Dictionary<string, string> paramss = new Dictionary<string, string>();
        protected string type;
        protected string merchantTrxId;
        public string Param { get { return this.paramss["hash"]; } }
        public string Lang { get { return this.language; } set { this.language = value; } }
        public Request(Config config, string type)
        {
            this.paramss.Add("type", type)
            this.merchant = config.ApiKey;
            this.clientIp = this.GetIPAddress();
            this.password = config.ApiSecret;
            this.endpoint = config.ApiUrl;
        }
        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return "192.168.0.1";
            //return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        protected static string GenerateHash(Dictionary<string, string> paramss, string password)
        {
            var sorted_paramss = from entry in paramss orderby entry.Key ascending select entry;
            string hashString = "";
            foreach (var item in sorted_paramss)
            {
                var l=0;
                if(item.Value!=null)
                    l = item.Value.Length;
                if (l != 0) { hashString = String.Concat(hashString, l, item.Value); }
            }
            return Request.HashHmac(hashString, password);
        }
        private static string HashHmac(string message, string secret)
        {
            Encoding encoding = Encoding.UTF8;
            using (HMACSHA1 hmac = new HMACSHA1(encoding.GetBytes(secret)))
            {
                var msg = encoding.GetBytes(message);
                var hash = hmac.ComputeHash(msg);
                return BitConverter.ToString(hash).ToLower().Replace("-", string.Empty);
            }
        }
        protected void CreateRequest()
        {
            this.paramss.Add("merchant", this.merchant);
            this.paramss.Add("language" ,this.language);
            this.paramss.Add("client_ip" , this.clientIp);
            this.paramss.Add("hash", Request.GenerateHash(this.paramss, this.password));
        }
        protected static string Send(string endpoint, Dictionary<string, string> paramss)
        {
            WebRequest request = WebRequest.Create(endpoint);
            string data = QueryStringBuilder.BuildQueryString(paramss);
            request.Method = "POST";
            request.ContentLength = Encoding.UTF8.GetBytes(data).Length;
            request.ContentType = "application/x-www-form-urlencoded";
            string response = null;
            using (Stream s = request.GetRequestStream())
            {
                using (StreamWriter stw = new StreamWriter(s))
                {
                    stw.Write(data);
                }
            }

            using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                response = reader.ReadToEnd();
            }
            return response;
        }
    }
}