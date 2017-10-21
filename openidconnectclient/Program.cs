using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using Newtonsoft.Json.Linq;

namespace openidconnectclient
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

       
        private static async Task MainAsync()
        {
            var disco =  await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "msatia", "msatia");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("demoapi");
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response =  await client.GetAsync("http://localhost:5001/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content =  await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            

        }

       
    }
}
