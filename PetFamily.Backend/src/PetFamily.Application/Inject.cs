using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Volunteers.CreateVolunteer;

namespace PetFamily.Infrastructure
{
    public static class Inject
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<CreateVolunteerHandler>();

            return services;
        }
    }
}
