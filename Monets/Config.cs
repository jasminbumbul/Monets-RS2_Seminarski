//using IdentityServer4;
//using IdentityServer4.Models;
//using System.Collections.Generic;

//namespace IdentityServerAspNetIdentity
//{
//    public static class Config
//    {
//        public static IEnumerable<IdentityResource> IdentityResources =>
//        new List<IdentityResource>
//        {
//            new IdentityResources.OpenId(),
//            new IdentityResources.Profile(),
//            new IdentityResource
//            {
//                Name = "role",
//                UserClaims = new List<string> { "role" }
//            },
//        };

//        public static IEnumerable<ApiScope> ApiScopes =>
//            new List<ApiScope>
//            {
//                new ApiScope("api1", "My API")
//            };

//        public static IEnumerable<ApiResource> ApiResources = new[]
//        {
//            new ApiResource("api1") // TODO: Possible doodoo
//            {
//                Scopes = new List<string> { "api1"},
//                ApiSecrets = new List<Secret> { new Secret("SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes".Sha256()) },
//                UserClaims = new List<string> { "role" }
//            }
//        };

//        public static IEnumerable<Client> Clients =>
//            new List<Client>
//            {
//            // machine to machine client
//                new Client
//                {
//                    ClientId = "client",
//                    ClientSecrets = { new Secret("SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes".Sha256()) },

//                    AllowedGrantTypes = GrantTypes.ClientCredentials,
//                    // scopes that client has access to
//                    AllowedScopes = { "api1" }
//                }
//            };
//    }
//}