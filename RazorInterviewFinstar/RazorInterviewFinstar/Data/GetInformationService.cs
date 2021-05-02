using RazorInterviewFinstar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace RazorInterviewFinstar.Data
{
    public class GetInformationService
    {
        private static readonly string baseUri = "https://interview.mfi-ap.asia";
        private static readonly string authServiceUri = baseUri + @"/ServiceModel/AuthService.svc/Login";

        public Task<Account> GetInfoAsync(CookieContainer cookie, string number)
        {
            return Task.FromResult(GetInfo(cookie, number));
        }

        public Account GetInfo(CookieContainer cookie, string number)
        {
            var url = baseUri + "/0/rest/InfintoPortalService/GetClientInfo";

            var httpRequest = WebRequest.CreateHttp(url);
            httpRequest.Method = "POST";
            httpRequest.CookieContainer = cookie;
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            CookieCollection cookieCollection = cookie.GetCookies(new Uri(authServiceUri));

            httpRequest.Headers.Add("BPMCSRF", cookieCollection["BPMCSRF"].Value);

            var data = "{\"mobile\":\"{" + number + "}\"}";
            Account account = null;

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                account = JsonSerializer.Deserialize<Account>(result);
            }

            return account;
        }
    }
}
