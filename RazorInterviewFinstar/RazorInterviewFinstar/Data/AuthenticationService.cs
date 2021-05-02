using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace RazorInterviewFinstar.Data
{
    public class AuthenticationService
    {
        private static readonly string baseUri = "https://interview.mfi-ap.asia";
        private static readonly string authServiceUri = baseUri + @"/ServiceModel/AuthService.svc/Login";
        private static readonly string userName = "interview";
        private static readonly string userPassword = "AAaaa11!";

        class ResponseStatus
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public object Exception { get; set; }
            public object PasswordChangeUrl { get; set; }
            public object RedirectUrl { get; set; }
        }

        public Task<CookieContainer> TryAuthAsync()
        {
            return Task.FromResult(TryAuth());
        }

        private CookieContainer TryAuth()
        {
            var authRequest = HttpWebRequest.CreateHttp(authServiceUri);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/json";
            CookieContainer AuthCookie = new();
            authRequest.CookieContainer = AuthCookie;

            // Помещение в тело запроса учетной информации пользователя.
            using (var requestStream = authRequest.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(@"{
                    ""UserName"":""" + userName + @""",
                    ""UserPassword"":""" + userPassword + @"""
                    }");
                }
            }

            // Вспомогательный объект, в который будут десериализованы данные HTTP-ответа.
            ResponseStatus status = null;
            // Получение ответа от сервера. Если аутентификация проходит успешно, в свойство AuthCookie будут
            // помещены cookie, которые могут быть использованы для последующих запросов.
            using (var response = (HttpWebResponse)authRequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    // Десериализация HTTP-ответа во вспомогательный объект.
                    string responseText = reader.ReadToEnd();
                    status = JsonSerializer.Deserialize<ResponseStatus>(responseText);
                }
            }

            if (status != null)
            {
                // Успешная аутентификация.
                if (status.Code == 0)
                {
                    return authRequest.CookieContainer;
                }
                // Сообщение о неудачной аутентификации.
                Console.WriteLine(status.Message);
            }

            return null;
        }
    }
}
