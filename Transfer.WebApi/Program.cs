using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Transfer.DataAccess.Concrate;
using Transfer.Entity;
using Transfer.WebApi.CQRS.Handlers.QueryHandler;
using Transfer.WebApi.CQRS.Queries.Request;
using Transfer.WebApi.CQRS.Queries.Response;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<TransferContext>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient<IRequestHandler<GetAllVehicleQueryRequest, List<GetAllVehicleQueryResponse>>, GetAllVehiclesQueryHandler>();
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
