using cache.Integration;
using cache.Services;
using cache.Services.Interface;
using cache.Services.PessoaService;
using Microsoft.Extensions.DependencyInjection;

namespace cache.Sccoped
{
    public static class ServiceProvide
    {
        private static IServiceCollection servicos = new ServiceCollection();
        private static ServiceProvider serviceProvider;

        private static void SetServiceProvider()
        {
            ConfigureServices(servicos);
            serviceProvider = servicos.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IConsultaExterna, ConsultaExterna>();
            services.AddTransient<IMemoryCacheService, MemoryCacheService>();
        }

        public static IPessoaService ObterInjecaoServicoCpf()
        {
            SetServiceProvider();
            return serviceProvider.GetService<IPessoaService>();
        }
    }
}