using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace openidconnectdemo
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAPIResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("api1", "My API")
            };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "msatia",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("msatia".Sha256()) },
                    AllowedScopes = {"firstopenidapi","demoapi"}
                }
            };
        }
    }
}
