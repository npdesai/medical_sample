using Medical.Models.DTOs;
using System.Threading.Tasks;

namespace Medical.Repository.Interfaces
{
    public interface IPatientRepository
    {
        Task<bool> AddPatient(AddPatientDto addPatient);
    }
}
