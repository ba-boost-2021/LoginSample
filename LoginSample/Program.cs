using LoginSample.Common;
using LoginSample.Data.Extensions;
using LoginSample.Service.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection(nameof(Settings)).Get<Settings>();
builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices();
builder.Services.AddData(builder.Configuration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.Key)),
                        ClockSkew = TimeSpan.Zero,
                    };
                });
builder.Services.AddAuthorization();
builder.Services.AddCors(option => { option.AddPolicy("all", p => { p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); }); });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("all");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
