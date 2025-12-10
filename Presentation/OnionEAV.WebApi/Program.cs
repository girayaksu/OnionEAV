using OnionEAV.Application.DependencyResolvers;
using OnionEAV.InnerInfrastructure.DependencyResolvers;
using OnionEAV.Persistence.DependencyResolvers;
using OnionEAV.WebApi.DependencyResolvers;
using OnionEAV.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextService();
builder.Services.AddDtoMapperService();
builder.Services.AddManagerService();
builder.Services.AddRepositoryService();
builder.Services.AddVmMapperService();
builder.Services.AddHandlerService();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
