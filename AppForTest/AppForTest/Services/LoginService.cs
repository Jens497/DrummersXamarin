using AppForTest.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace AppForTest.Services
{
    public class LoginService
    {
        public async Task<AuthenticationResult> RegisterUserPost(UserModel user)
        {
            string url = "https://10.0.2.2:7212/api/auth/register";

            HttpResponseMessage response;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            var jsonObj = JsonConvert.SerializeObject(user, Formatting.Indented);
            var stringContent = new StringContent(jsonObj);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("In the login servjce");

            try
            {
                response = await client.PostAsync(url, stringContent);
            } catch (Exception)
            {
                return new AuthenticationResult()
                {
                    IsFailed = true,
                    ErrorMessage = "Unable to handle request, check everything!"
                };
            }

            if (!response.IsSuccessStatusCode)
            {
                return new AuthenticationResult()
                {
                    IsFailed = true,
                    ErrorMessage = await response.Content.ReadAsStringAsync(),
                };
            }

            Console.WriteLine("In the login servjce2");

            string reponseContentFromJson = await response.Content.ReadAsStringAsync();
            var jsonConcent = JObject.Parse(reponseContentFromJson);
            string userToken = jsonConcent["token"].ToString();
            string userRegistered = jsonConcent["user"].ToString();


            return new AuthenticationResult()
            {
                AccessToken = userToken,
                UserName = userRegistered,
                IsFailed = false,
            };
        }
    }
}
