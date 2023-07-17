using ManagingTool;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<UserDataService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:11500/") });
builder.Services.AddAntDesign();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
UserDataService.HttpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();

await builder.Build().RunAsync();
