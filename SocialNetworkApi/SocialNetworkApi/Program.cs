using SocialNetworkAPI.Application.UseCases;
using SocialNetworkAPI.Core.Interfaces;
using SocialNetworkAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllers();

// Registrar los casos de uso
builder.Services.AddScoped<PostMessage>();
builder.Services.AddScoped<FollowUser>();
builder.Services.AddScoped<GetUserDashboard>();

// Registrar como singleton
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar canalización de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
