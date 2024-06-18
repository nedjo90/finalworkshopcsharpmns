using backend;
using backend.Contract;
using backend.Exceptions;
using backend.MigrationsManager;
using backend.Repository;
using backend.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBackendManager, BackendManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddControllers();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

WebApplication app = builder.Build();

app.UseExceptionHandler();
app.UseAuthentication();
app.MapControllers();

app.MigrateDatabase();
app.Run();