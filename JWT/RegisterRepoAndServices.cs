using JWT.Data;
using JWT.Service;

namespace JWT
{
    public static class RegisterRepoAndServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            Configure(services, DataRegister.GetTypes());
            Configure(services, ServiceRegister.GetTypes());
        }

        public static void Configure(IServiceCollection services, Dictionary<Type, Type> dictionary)
        {
            foreach (var type in dictionary)
            {
                services.AddScoped(type.Key, type.Value);
            }
            services.AddMvc();
            services.AddHttpContextAccessor();
        }
    }
}
