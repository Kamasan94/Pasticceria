using Castle.Windsor.Installer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pasticceria.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" }));

//Aggiunto DbContext
builder.Services.AddDbContext<PasticceriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddCors();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseCors(options =>
  options.WithOrigins("http://localhost:4200")
  .AllowAnyMethod()
  .AllowAnyHeader());


app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));

app.MapRazorPages();

app.UseEndpoints(endpoints =>
  endpoints.MapControllers());


app.Run();
