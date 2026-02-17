using Microsoft.EntityFrameworkCore;
using ResourceManagement.Application.Common;
using ResourceManagement.Application.Features.Resources;
using ResourceManagement.Application.Features.Resources.CreateResource;
using ResourceManagement.Application.Features.Resources.GetResource;
using ResourceManagement.Infrastructure;
using ResourceManagement.Infrastructure.Persistence;
using ResourceManagement.Presentation.Filters;
using ResourceManagement.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IDispatcher, Dispatcher>();
builder.Services.AddScoped<IRequestHandler<CreateResourceCommand, ResourceResponse>, CreateResourceHandler>();
builder.Services.AddScoped<IRequestHandler<GetResourceQuery, ResourceResponse?>, GetResourceHandler>();

var app = builder.Build();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
catch (Exception ex)
{

}

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
