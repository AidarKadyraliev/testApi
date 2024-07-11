using TestApi.Handlers;

var builder = WebApplication.CreateBuilder(args);

try
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureRequestHandlers();

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
