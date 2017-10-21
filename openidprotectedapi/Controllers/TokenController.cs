using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace openidapiclient.Controllers
{
    public class TokenController : Controller
    {
        public async Task<IActionResult> GetTokenAsync(string clientid,string clientsecret)
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenClient = new TokenClient(disco.TokenEndpoint,clientid,clientsecret);
            var resp = await tokenClient.RequestClientCredentialsAsync("api1");
            if (resp.IsError)
                return new JsonResult(resp.Error);
            else
                return new JsonResult(resp.Json);
        }
    }
}
