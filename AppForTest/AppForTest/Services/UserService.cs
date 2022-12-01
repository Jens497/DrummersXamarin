using AppForTest.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AppForTest.Services
{
    public class UserService
    {
        public async Task<List<UserModel>> GetUserModelsAsync()
        {
            string url = "https://10.0.2.2:7212/api/User/GetUsersTest";
            HttpResponseMessage response;
            //Uri uri = new Uri()
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient client = new HttpClient(httpClientHandler);

            try
            {
                response = await client.GetAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Didnt get anything in the response");
                Console.WriteLine(ex.ToString());
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("The statuscode was NOT successful IE. not 200");
                return null;
            }

            string responseString = await response.Content.ReadAsStringAsync();
            List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(responseString);
            Console.WriteLine(users);
            Console.WriteLine(users[0]);
            Console.WriteLine(users[0].Username);
            return users;
        }
    }
}
