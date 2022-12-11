using AppForTest.Dto;
using AppForTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppForTest.Services
{
    public class ExcerciseService
    {
        public async Task<List<ExcerciseModel>> GetExcercises()
        {
            string url = "https://10.0.2.2:7212/api/excercise";
            HttpResponseMessage response;

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            //If this line is not here, the certificate cannot be verified when sending request to backend.
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            string userToken = await SecureStorage.GetAsync("accessToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);


            try
            {
                response = await client.GetAsync(url);
            }
            catch (Exception)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                return null;

            string responseContentString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ExcerciseModel>>(responseContentString);
        }

        public async Task CreateExcercise(ExcerciseDto excercise)
        {
            string url = "https://10.0.2.2:7212/api/excercise";
            HttpResponseMessage response;

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            //If this line is not here, the certificate cannot be verified when sending request to backend.
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            string userToken = await SecureStorage.GetAsync("accessToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

            var jsonObj = JsonConvert.SerializeObject(excercise, Formatting.Indented);
            var stringContent = new StringContent(jsonObj);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                response = await client.PostAsync(url, stringContent);
            }
            catch (Exception)
            {
                Console.WriteLine("Woops");
            }
        }

        public async Task DeleteExcercise(int excerciseId)
        {
            string url = string.Format("https://10.0.2.2:7212/api/excercise/{0}", excerciseId);
            HttpResponseMessage response;

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            //If this line is not here, the certificate cannot be verified when sending request to backend.
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            string userToken = await SecureStorage.GetAsync("accessToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

            try
            {
                response = await client.DeleteAsync(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
                return;
            }
                
        }
    }
}
