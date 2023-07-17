using WebAPIServer.DbOperations;
using WebAPIServer.Middleware;
using WebAPIServer.Util;
using ZLogger;
using IdGen.DependencyInjection; //https://github.com/RobThree/IdGen
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var defaultSetting = new DefaultSetting();
configuration.Bind("DefaultSetting", defaultSetting);
builder.Services.AddSingleton(defaultSetting);

builder.Services.AddTransient<IAccountDb, AccountDb>();
builder.Services.AddTransient<IGameDb, GameDb>();
builder.Services.AddSingleton<IRedisDb, RedisDb>();
builder.Services.AddSingleton<IMasterDb, MasterDb>();
builder.Services.AddIdGen((int)defaultSetting.GeneratorId);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

//builder.Services.AddControllers();

LogManager.SetLogging(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

var redisDb = app.Services.GetRequiredService<IRedisDb>();
await redisDb.Init();

var masterDb = app.Services.GetRequiredService<IMasterDb>();
await masterDb.Init();

// 로그인 이후 유저 인증
//app.UseMiddleware<WebAPIServer.Middleware.CheckUserAuth>();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run(configuration["ServerAddress"]);


public class DefaultSetting
{
	public Int64 MailsPerPage { get; set; }
	public Int64 GeneratorId { get; set; }
}