using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using book_collector.Data;
using book_collector.Areas.Identity.Data;
using book_collector.Interfaces;
using book_collector.Repositories;
using book_collector.Helpers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("book_collectorContextConnection") ?? throw new InvalidOperationException("Connection string 'book_collectorContextConnection' not found.");

builder.Services.AddDbContext<book_collectorContext>(options =>
    options.UseSqlServer(connectionString));;
builder.Services.AddTransient<IUnitOfWork, UnitOfWorkRepo>();
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Helper());
});

var mapper  = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDefaultIdentity<book_collectorUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<book_collectorContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();// For Partial Page of Authentications and Authorization.

app.Run();
