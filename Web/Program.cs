using HumanCapitalManagement.Web;
using HumanCapitalManagement.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddAntiForgeryHeader()
    .AddAutoMapper(typeof(AutoMapperProfiles))
    .AddApplicationServices()
    .AddControllersWithAutoAntiForgeryTokenAttribute()
    .AddEndpointsApiExplorer();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.PrepareDatabase()
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAnyCors()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultAreaRoute();
        endpoints.MapDefaultControllerRoute();
        endpoints.MapRazorPages();
    });

app.Run();