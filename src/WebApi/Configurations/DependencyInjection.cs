using TemplateNet6.Application.InterfacesRepositories;
using TemplateNet6.Application.InterfacesServices;
using TemplateNet6.Application.UseCase;
using TemplateNet6.Infrastructure.Repositories;
using TemplateNet6.Infrastructure.Services;
using TemplateNet6.WebApi.Mapping;

namespace TemplateNet6.WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            #region USECASES
            services.AddScoped<ITipoCuentaUseCase, TipoCuentaUseCase>();
            #endregion

            #region REPOSITORIES
            services.AddScoped<ITipoCuentaRepository, TipoCuentaRepository>();
            #endregion

            #region SERVICES
            //API
            //services.AddScoped<ICritoApiService, CriptoApiService>();

            //OTHERS
            services.AddSingleton<IDbConnectionService, DbConnectionService>();
            services.AddSingleton<ILoggerService, Log4NetLoggerService>();
            #endregion

            #region OTHERS
            LoggerConfiguration.Configure();
            services.AddAutoMapper(typeof(WebApiMapping));
            #endregion
        }
    }
}
