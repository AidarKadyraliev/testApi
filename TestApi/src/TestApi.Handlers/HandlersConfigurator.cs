using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TestApi.Handlers;

/// <summary>
///     Handlers configurator
/// </summary>
public static class HandlersConfigurator
{
    /// <summary>
    ///     Configure request handlers
    /// </summary>
    /// <param name="services">Service collection</param>
    public static void ConfigureRequestHandlers(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}