using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Entity;
using Microsoft.AspNetCore.Identity;
using StoreAutoMVC.Interfaces;
using Microsoft.AspNetCore.Identity;
using StoreAutoMVC.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.OpenApi.Models;
using StoreAutoMVC.Sevices;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<IdentityDBContext>()
//    .AddDefaultTokenProviders();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<IdentityDBContext>(options => options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityDBContext>();


builder.Services.AddScoped<IDBContext, DBContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    c.ParameterFilter<ModelNameParameterFilterService>();
    c.ParameterFilter<BrandNameParameterFilterService>();
}).AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Cars}/{id?}");

app.MapRazorPages();

app.Run();