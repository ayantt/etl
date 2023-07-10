using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Enum;
using WebApplication1.Repository;
using WebApplication1.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

// Add services to the container.
builder.Services.AddRazorPages();

//Register DBContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAllergiesDetailRepo, AllergiesDetailRepo>();
builder.Services.AddScoped<IAllergiesRepo, AllergiesRepo>();
builder.Services.AddScoped<IDiseaseInformationRepo, DiseaseInformationRepo>();
builder.Services.AddScoped<INCDDetailsRepo, NCDDetailsRepo>();
builder.Services.AddScoped<INCDRepo, NCDRepo>();
builder.Services.AddScoped<IPatientInformationRepo, PatientInformationRepo>();

services.Configure<RazorViewEngineOptions>(o =>
{
    o.ViewLocationFormats.Clear();
    o.ViewLocationFormats.Add("/Views/Patient/Index" + RazorViewEngine.ViewExtension);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Patient}/{action=Index}");
});

app.Run();
