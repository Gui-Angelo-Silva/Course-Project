using backend.Repositories.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Entities;
using backend.Services.Interfaces;

namespace backend.Services.Server
{
    public static class DependenciesInjection
    {
        public static void AddRestaurantDependencies(this IServiceCollection services)
        {
            // Dependência: Restaurante
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IRestaurantService, RestaurantService>();

            // Dependência: Mesa
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ITableService, TableService>();
        }

        public static void AddUserDependencies(this IServiceCollection services)
        {
            // Dependência: Usuário
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
