using AppForTest.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System;
using Newtonsoft.Json.Linq;
using AppForTest.Dto;

namespace AppForTest.Services
{
    public class LoginService
    {
        //TBD - Make RegisterUserPost use FireHttpRequest, this makes less redundant code.
        public async Task<ResponseFromAuthentication> RegisterUserPost(UserModel user)
        {
            string url = "https://10.0.2.2:7212/api/auth/register";

            HttpResponseMessage response;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            //If this line is not here, the certificate cannot be verified when sending request to backend.
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            //Serialize our user object, put it in a StringContent, so that we can put headers on it, to tell receiver its a json object.
            var jsonObj = JsonConvert.SerializeObject(user, Formatting.Indented);
            var stringContent = new StringContent(jsonObj);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Throughout this we use the response from our http to the status of the request,
            //However if the request didnt even go through we can still use our "ReponseFromAuthentication",
            //To create a dummy reponse which just returns an error along with a message to be handle by the caller.
            try
            {
                response = await client.PostAsync(url, stringContent);
            } catch (Exception)
            {
                return new ResponseFromAuthentication()
                {
                    IsFailed = true,
                    ErrorMessage = "Unable to handle request, check everything!"
                };
            }

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseFromAuthentication()
                {
                    IsFailed = true,
                    ErrorMessage = await response.Content.ReadAsStringAsync(),
                };
            }

            //If reponse was 200 IE. "OK", we know there is a json object returned where we can get our data.
            //In this case we get our token which verifies the user, and the user that has being used currently.
            string reponseContentFromJson = await response.Content.ReadAsStringAsync();
            var jsonConcent = JObject.Parse(reponseContentFromJson);
            string userToken = jsonConcent["userToken"].ToString();
            string userRegistered = jsonConcent["userRegistered"].ToString();

            return new ResponseFromAuthentication()
            {
                UserAccessToken = userToken,
                UserName = userRegistered,
                IsFailed = false,
            };
        }

        public async Task<ResponseFromAuthentication> LoginUserPost(UserLoginDto user)
        {
            string url = "https://10.0.2.2:7212/api/auth/login";

            //Serialize our user object, put it in a StringContent, so that we can put headers on it, to tell receiver its a json object.
            var jsonObj = JsonConvert.SerializeObject(user, Formatting.Indented);
            return await FireHttpRequest(jsonObj, url);
        }

        private async Task<ResponseFromAuthentication> FireHttpRequest(string jsonObj, string url)
        {
            HttpResponseMessage response;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            //If this line is not here, the certificate cannot be verified when sending request to backend.
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            var stringContent = new StringContent(jsonObj);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Throughout this we use the response from our http to the status of the request,
            //However if the request didnt even go through we can still use our "ReponseFromAuthentication",
            //To create a dummy reponse which just returns an error along with a message to be handle by the caller.
            try
            {
                response = await client.PostAsync(url, stringContent);
            }
            catch (Exception)
            {
                return new ResponseFromAuthentication()
                {
                    IsFailed = true,
                    ErrorMessage = "Request could not be handle, check connection."
                };
            }

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseFromAuthentication()
                {
                    IsFailed = true,
                    ErrorMessage = await response.Content.ReadAsStringAsync(),
                };
            }

            //If reponse was 200 IE. "OK", we know there is a json object returned where we can get our data.
            //In this case we get our token which verifies the user, and the user that has being used currently.
            string reponseContentFromJson = await response.Content.ReadAsStringAsync();
            var jsonConcent = JObject.Parse(reponseContentFromJson);
            string userToken = jsonConcent["userToken"].ToString();
            string userRegistered = jsonConcent["user"].ToString();

            return new ResponseFromAuthentication()
            {
                UserAccessToken = userToken,
                UserName = userRegistered,
                IsFailed = false,
            };
        }
    }
}
