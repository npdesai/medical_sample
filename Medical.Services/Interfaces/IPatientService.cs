using Medical.Models.DTOs;
using System.Threading.Tasks;

namespace Medical.Services.Interfaces
{
    public interface IPatientService
    {
        Task<bool> AddPatient(AddPatientRequestDto addPatient);
    }
}
