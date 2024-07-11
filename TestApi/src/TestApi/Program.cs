using TestApi.Handlers;
using TestApi.Handlers.Services;
using TestApi.Repositories.UnitOfWork;
using TestApi.Repositories.UnitOfWork.Repositories;

var builder = WebApplication.CreateBuilder(args);

try
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureRequestHandlers();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<ICandidateService, CandidateService>();
    builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

    var app = builder.Build();

    if (!app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
finally
{
    //Aidar kot
}
