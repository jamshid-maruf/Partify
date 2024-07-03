using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.DbContexts;
using Partify.Service.Helpers;
using Partify.WebApi.Extensions;
using Partify.WebApi.Helpers;
using Partify.WebApi.MapperConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options
	=> options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMemoryCache();

builder.Services.AddApiServices();

builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

builder.Services.AddExceptions();

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddProblemDetails();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

ServiceHelper.InitializeServices(app.Services);

HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
EnvironmentHelper.JwtKey = app.Configuration.GetSection("Jwt:Key").Value;
EnvironmentHelper.TokenLifeTimeInHour = app.Configuration.GetSection("Jwt:LifeTime").Value;
EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:SmtpHost").Value;
EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:SmtpPort").Value;
EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:EmailPassword").Value;

app.UseSwagger();

app.UseSwaggerUI();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();