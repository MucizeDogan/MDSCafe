using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //Auth olmu� kullan�c�y� zorunlu k�l

// Add services to the container.

builder.Services.AddDbContext<Context>();

builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews(opt => {
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy)); // B�t�n controllerlar�n i�erisine authorize i�lemini filtrele
});

builder.Services.ConfigureApplicationCookie(opts => {
    opts.LoginPath = "/Login/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Product}/{action=Index}/{id?}");
    pattern: "{controller=Statistics}/{action=Index}/{id?}");

app.Run();
