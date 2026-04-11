using Microsoft.EntityFrameworkCore;
using user_mgmt.Data;
using user_mgmt.Models;
using user_mgmt.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(x =>
{
    x.AddProfiles([
        new UserProfile(),
    ]);
});

builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDb")));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
