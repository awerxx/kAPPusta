using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Infrastructure.Persistence;
using Avvr.Kappusta.Zoya.Web.Data;
using Avvr.Kappusta.Zoya.Web.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<AccountService>();
builder.Services.AddSingleton<IAccountRepository, DummyAccountRepository>();
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapEndpoints();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
