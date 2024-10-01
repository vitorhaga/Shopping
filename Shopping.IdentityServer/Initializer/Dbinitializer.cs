using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Shopping.IdentityServer.Configuration;
using Shopping.IdentityServer.Model;
using Shopping.IdentityServer.Model.Context;
using System.Security.Claims;

namespace Shopping.IdentityServer.Initializer
{
    public class Dbinitializer : IDbInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public Dbinitializer(MySQLContext context, 
            UserManager<ApplicationUser> user, 
            RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) 
                return;

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin))
                .GetAwaiter()
                .GetResult();

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client))
                .GetAwaiter()
                .GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "vitor-admin",
                Email = "vitorhaga.dev@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (18) 936189635",
                FirstName = "Vitor",
                LastName = "Admin"
            };
            //aqui a senha precisa ter uma maiuscula, minuscula, um numero e um caracter especial se não da um erro padrão
            _user.CreateAsync(admin,"VitorHaga10$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin)
                .GetAwaiter()
                .GetResult();
            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;           
            
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "vitor-client",
                Email = "vitorhaga.dev@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (18) 936189635",
                FirstName = "Vitor",
                LastName = "Client"
            };
            //aqui a senha precisa ter uma maiuscula, minuscula, um numero e um caracter especial se não da um erro padrão
            _user.CreateAsync(client,"VitorHaga10$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client)
                .GetAwaiter()
                .GetResult();
            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
