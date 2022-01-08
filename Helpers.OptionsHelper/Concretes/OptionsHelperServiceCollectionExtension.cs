using Helpers.OptionsHelper.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpers.OptionsHelper.Concretes
{
    public static class OptionsHelperServiceCollectionExtension
    {
        public static IServiceCollection AddDefaultOptionsHelper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(sp =>
            {
                var enviromentVariableHelper = sp.GetRequiredService<IEnviromentVariableHelper>();
                return new DefaultOptionsHelper(configuration, enviromentVariableHelper);
            });

            return services;
        }
    }
}
