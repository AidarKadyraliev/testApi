using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TestApi.Handlers;
using TestApi.Handlers.Services;
using TestApi.Repositories;
using TestApi.Repositories.UnitOfWork;
using TestApi.Repositories.UnitOfWork.Repositories;

var builder = WebApplication.CreateBuilder(args);

try
{
	builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureRequestHandlers();
	builder.Services.AddDbContext<CandidatesDbContext>(options =>
	{
		options.EnableSensitiveDataLogging();

		options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b =>
		{
			b.MigrationsAssembly(typeof(CandidatesDbContext).Assembly.FullName);
			b.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
		});
	});
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<ICandidateService, CandidateService>();
    builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

	var app = builder.Build();
	var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
	using (var scope = scopeFactory.CreateScope())
	{
		var context = scope.ServiceProvider.GetRequiredService<CandidatesDbContext>();
		context.Database.Migrate();
	}
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
