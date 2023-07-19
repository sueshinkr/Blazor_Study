using ManagingTool.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Radzen;


/*
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
*/

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<MailService>();
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAntDesign();
//builder.Services.AddSingleton<DialogService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

//builder.Services.AddBlazoredLocalStorage();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

UserService._httpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();
ItemService._httpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();
MailService._httpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();

await builder.Build().RunAsync();