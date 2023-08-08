using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;
using Transfer.WebApi.CQRS.Handlers.QueryHandler;
using Transfer.WebApi.CQRS.Queries.Request;
using Transfer.WebApi.CQRS.Queries.Response;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);
Log.Information("Starting web host");
builder.Services.AddControllers();
builder.Host.UseSerilog((ctx, lc) => lc
 .WriteTo.Console());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<TransferContext>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient<IRequestHandler<GetAllVehicleQueryRequest, List<GetAllVehicleQueryResponse>>, GelAllBooksHandler>();
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
