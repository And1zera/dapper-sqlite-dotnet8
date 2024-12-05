using dapperdotnet8.Application.Services;
using dapperdotnet8.Domain.Interfaces.Services;
using dapperdotnet8.Data.Dapper.Context;
using dapperdotnet8.Data.Repository;
using dapperdotnet8.Domain.Interfaces.Context;
using dapperdotnet8.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace dapperdotnet8.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        //Context
        services.AddScoped<IDbContext, DbContext>();
        //Services
        services.AddScoped<IUserService, UserService>();
        //Queues
        //Extensions        
        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //Repositorys

    }
}