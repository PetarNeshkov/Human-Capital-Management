using HumanCapitalManagement.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddAntiForgeryHeader()
    .AddControllersWithAutoAntiForgeryTokenAttribute();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultAreaRoute();
        endpoints.MapDefaultControllerRoute();
        endpoints.MapRazorPages();
    });

app.Run();