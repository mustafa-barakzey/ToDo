using brk.Todo.Application;
using brk.Todo.Infra;
using brk.Todo.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option =>
{
    option.DefaultPolicyName = "public";
    option.AddPolicy("public", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services
        .AddHttpContextAccessor()
        .AddInfraServices(builder.Configuration)
        .AddApplicationServices()
        .AddEndpoints();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("public");
app.UseAuthentication();
app.UseAuthorization();
// app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();