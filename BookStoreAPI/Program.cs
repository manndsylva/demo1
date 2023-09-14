using BookStore.API.Models;
using BookStoreAPI.Data;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddAutoMapper(typeof(Program));

//For Book Store context
builder.Services.AddDbContext<BookStoreContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookConnectionString")));

//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreContext>()
    .AddDefaultTokenProviders();

//Cors
builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//For Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
    {
        option.SaveToken = true;
        option.RequireHttpsMetadata = false;
        option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "JWT:ValidAudience",
            ValidIssuer = "JWT:ValidIssuer",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT:Secret"))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
