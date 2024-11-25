using Microsoft.EntityFrameworkCore;
using product.Models;
using product.Repository;
using product.Repository.Interfaces;
using product.Services;
using product.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();// httpclient ÈÑÇ? 
builder.Services.AddHttpClient<icategory, categoryrepository>();// 
builder.Services.AddHttpClient<Itodorepository, todoreposetory>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBaseServices, BaseServices>();
builder.Services.AddScoped<icategory, categoryrepository>();
builder.Services.AddScoped<Iproductrepository, productrep>();
builder.Services.AddScoped<ItodosServices, todosServices>();
builder.Services.AddScoped<Itodorepository, todoreposetory>();




builder.Services.AddDbContext<DBp>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
