using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using Transfer.Application.Campaign.Email.Abstract;
using Transfer.Application.Campaign.Email.Concrete;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Transfer.ActionFilters;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;
using Transfer.Application.Transfer.Validator.FluentValidation.RequestValidator;
using Transfer.Business.Abstract;
using Transfer.Business.Concrete;
using Transfer.Client;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Core.CrosCuttingConcerns.Caching.Microsoft;
using Transfer.Core.CrosCuttingConcerns.MailService;
using Transfer.DataAccess.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.CQRS.Handlers.CommandHandler;
using Transfer.Server.CQRS.Handlers.QueryHandler;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.WebApi.Extensions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);
Log.Information("Starting web host");




builder.Host.UseSerilog((ctx, lc) => lc
 .WriteTo.Console());


builder.Services.AddControllers();
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(CreateBookRequestDtoValidator).Assembly);
    conf.AutomaticValidationEnabled = false;
});



var uriConfig = builder.Configuration["TransferClientBaseUri:BaseUri"];

builder.Services.AddHttpClient<TransferClient>(config =>
config.BaseAddress = new Uri(uriConfig)
);

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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Transfer.Application")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExpectionHandler();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();