using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.Core.Interfaces.Repositories;
using TransaccionesBancarias.Core.Interfaces.Services;
using TransaccionesBancarias.Core.Services.Implementation;
using TransaccionesBancarias.Infrastructure.Repositories;
using TransaccionesBancarias.Infrastructure_.Repositories;

namespace TransaccionesBancarias.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            #region Servicios repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            #endregion
            #region Servicios
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IConfiguracionService, ConfiguracionService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<IPersonaService, PersonaService>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
           
        }
    }
}
