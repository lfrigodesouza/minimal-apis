using System;
using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using minimal_apis.Commands;
using minimal_apis.Queries;
using MinimalApis.Data;
using MinimalApis.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureServices((context, services) =>
{
    services.AddSingleton<IUserRepository, UserRepository>();
    services.AddMediatR(Assembly.GetExecutingAssembly());
});
await using var app = builder.Build();
var mediator = app.Services.GetService<IMediator>();

app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.MapGet("/user/all", (Func<List<User>>)(() => mediator.Send(new AllUsersQuery()).Result));
app.MapGet("/user/{id:long}", (Func<long, User>)((long id) => mediator.Send(new UserQuery(id)).Result));

app.MapPost("/user", (Func<AddUserCommand, User>)((AddUserCommand user) => mediator.Send(user).Result));
app.MapDelete("/user/{id:long}", (Action<long>)((long id) => mediator.Send(new DeleteUserCommand(id))));

await app.RunAsync();