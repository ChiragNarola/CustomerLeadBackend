using AutoMapper;
using CustomerLeadImageUpload.Business.Mapper;
using CustomerLeadImageUpload.Business.Services;
using CustomerLeadImageUpload.Business.Services.Interface;
using CustomerLeadImageUpload.Data;
using CustomerLeadImageUpload.Data.DBContext;
using CustomerLeadImageUpload.Data.Repository;
using CustomerLeadImageUpload.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

// Add services to the container
builder.Services.AddControllers();

// Register DbContext with PostgreSQL
builder.Services.AddDbContext<CustomerLeadImageUploadDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Register unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerImageService, CustomerImageService>();


// Add swagger if needed
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod());


app.Run();
