using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using Transfer.Business.Abstract;
using Transfer.Business.Concrete;
using Transfer.Client;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Core.CrosCuttingConcerns.Caching.Microsoft;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.CQRS.Handlers.CommandHandler;
using Transfer.Server.CQRS.Handlers.QueryHandler;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);
Log.Information("Starting web host");

builder.Host.UseSerilog((ctx, lc) => lc
 .WriteTo.Console());
builder.Services.AddControllers();
builder.Services.AddHttpClient<TransferClient>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<IBookDal, BookDal>();
builder.Services.AddSingleton<IBookService, BookManager>();
builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<ICacheManager, MemoryCacheManager>();
builder.Services.AddDbContext<TransferContext>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Transfer.Server")));

builder.Services.AddTransient<IRequestHandler<GetUserRequest, GetUserResponse>, GetUserQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreateUserRequest, CreateUserResponse>, CreateUserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateBookTransferRequest, CreateBookTransferResponse>, CreateBookOnewWayCommandHanlder>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
