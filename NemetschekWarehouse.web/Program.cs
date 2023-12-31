using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NemetschekWarehouse.Core.Contracts;
using NemetschekWarehouse.Core.Services;
using NemetschekWarehouse.Infrastructure.data;
using NemetschekWarehouse.Infrastructure.Data.Entities.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<WarehouseDb>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Guest>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 6;
            options.User.RequireUniqueEmail = true;
        })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WarehouseDb>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProduct, ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
