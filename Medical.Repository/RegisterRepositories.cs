using Medical.Repository.Interfaces;
using Medical.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Repository
{
    public static class RegisterRepositories
    {
        public static void RegisterMedicalRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
        }
    }
}
