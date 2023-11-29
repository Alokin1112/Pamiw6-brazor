using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
// using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Pamiw6;
using Pamiw6.Shared.Configuration;
using Pamiw6.Shared.Services.AuthorService;
using Pamiw6.Shared.Services.BookService;
using Microsoft.AspNetCore.Components.Authorization;
using Pamiw6.shared.services;
using Pamiw6.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<HttpClient>();

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
};


builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BookService>();


await builder.Build().RunAsync();
