using Blazored.LocalStorage;
using FilRougeFront;
using FilRougeFront.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<CommentService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
