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

            // Dependência: Temática
            services.AddScoped<IThematicRepository, ThematicRepository>();
            services.AddScoped<IThematicService, ThematicService>();

            // Dependência: Temática de Restaurante
            services.AddScoped<IThematicRestaurantRepository, ThematicRestaurantRepository>();
            services.AddScoped<IThematicRestaurantService, ThematicRestaurantService>();
        }

        public static void AddUserDependencies(this IServiceCollection services)
        {
            // Dependência: Usuário
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();
        }
    }
}
