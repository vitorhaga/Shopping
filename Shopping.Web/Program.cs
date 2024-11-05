using Microsoft.AspNetCore.Authentication;
using Shopping.Web.Services;
using Shopping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IProductService, ProductService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"])
);builder.Services.AddHttpClient<ICartService, CartService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CartAPI"])
);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
  .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", options =>
  {
     options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
     options.GetClaimsFromUserInfoEndpoint = true;
     options.ClientId = "shopping";
     options.ClientSecret = "Shopping_api_Secret_encoded";
     options.ResponseType = "code";
     options.ClaimActions.MapJsonKey("role", "role", "role");
     options.ClaimActions.MapJsonKey("sub", "sub", "sub");
     options.TokenValidationParameters.NameClaimType = "name";
     options.TokenValidationParameters.NameClaimType = "role";
     options.SignedOutCallbackPath = @"/singout-callback-oidc"; //adicionado, pois PostLogoutRedirectUris = {"https://localhost:4430/singout-callback-oidc"}, no IdentityConfiguration não estava funcionando, dessa forma ele consegue enxergar o PostLogoutRedirectUris
     options.Scope.Add("shopping");
     options.SaveTokens = true;
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
