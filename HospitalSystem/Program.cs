using HospitalData;
using HospitalSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.Models;




//****************************************

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Hizmetleri konteynere ekle.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HospitalDataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<HospitalDataContext>();

var app = builder.Build();

// HTTP isteði hattýný yapýlandýr.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Varsayýlan HSTS deðeri 30 gündür. Üretim senaryolarý için bunu deðiþtirebilirsiniz, bkz. https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Seed();
app.Run();