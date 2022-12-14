using Microsoft.AspNetCore.Mvc.Diagnostics;
using VivesShopMVC.Controllers;
using VivesShopMVC.Data;
using VivesShopMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<BigViewModel>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    var database = app.Services.GetRequiredService<BigViewModel>();
    database.ItemsDataBase = new ShopItemsDb();
    database.Cart = new Cart();
    database.ItemsDataBase.Seed();
    database.Cart.initialize();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
