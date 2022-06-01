using Medical.Services.Interfaces;
using Medical.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Services
{
    public static class RegisterServices
    {
        public static void RegisterMedicalServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IPatientService, PatientService>();
        }
    }
}
