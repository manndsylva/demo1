using BookStore.API.Models;
using BookStoreAPI.Data;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB")));

//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddUserStore<BookStoreContext>()
    .AddDefaultTokenProviders();

/*builder.Services.AddIdentityCore<IdentityRole>()
    .AddEntityFrameworkStores<BookStoreContext>()
    .AddDefaultTokenProviders();*/
//Cors
builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
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
