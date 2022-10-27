using Compras.Repository;
using Compras.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRepositoryBase, RepositoryBase>();
builder.Services.AddTransient<IServiceBase, ServiceBase>();
builder.Services.AddTransient<IContratacionesService, ContratacionesService>();
builder.Services.AddTransient<IAdministrativeUnitsService, AdministrativeUnitsService>();
builder.Services.AddTransient<ISuppliersService, SuppliersService>();
builder.Services.AddTransient<ILicitacionesService, LicitacionesService>();
builder.Services.AddTransient<ILookUpService, LookUpService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(option => option.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();