using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Shopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        //scopo usando pelo front end 
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { 
                new ApiScope("shopping", "Shopping Server"),
                new ApiScope(name:"read", "Read data."),
                new ApiScope(name:"write", "Write data."),
                new ApiScope(name:"delete", "Delete data."),
            };
        //client
        //client é um componente que solicita um token ao identity server,
        //assim ele pode permitir ou negar acesso a um recurso
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets =
                    {
                        new Secret("Shopping_api_Secret_encoded".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "shopping",
                    ClientSecrets =
                    {
                        new Secret("Shopping_api_Secret_encoded".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/singout-callback-oidc"},
                    AllowedScopes = new List<String>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "shopping"
                    }
                }
            };
    }
}
