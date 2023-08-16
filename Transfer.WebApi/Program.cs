using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;
using System.Reflection;
using Transfer.Business.Abstract;
using Transfer.Business.Concrete;
using Transfer.Client;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Core.CrosCuttingConcerns.Caching.Microsoft;
using Transfer.Core.CrosCuttingConcerns.MailService;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.CQRS.Handlers.CommandHandler;
using Transfer.Server.CQRS.Handlers.QueryHandler;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;
using Transfer.Server.Mapper;
using Transfer.WebApi.Extensions;

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
var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddTransient<IEmailService, EmailManager>();
builder.Services.AddSingleton<IBookDal, BookDal>();
builder.Services.AddSingleton<IBookService, BookManager>();
builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<ICacheManager, MemoryCacheManager>();
builder.Services.AddDbContext<TransferContext>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Transfer.Server")));

builder.Services.AddTransient<IRequestHandler<GetUserRequest, GetUserResponse>, GetUserQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CreateUserRequest, CreateUserResponse>, CreateUserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateBookRequest, CreateBookResponse>, CreateBookCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateValidateRequest, CreateValidateResponse>, CreateValidationCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetOneWayRequest, List<GetOneWayResponse>>, GetOneWayQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetRoundWayRequest, List<GetRoundWayResponse>>, GetRoundWayQueryHandler>();

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
