using AutoMapper;
using Medical.Models.DTOs;
using Medical.Repository.Interfaces;
using Medical.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Medical.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddPatient(AddPatientRequestDto addPatient)
        {
            try
            {
                return await _patientRepository.AddPatient(_mapper.Map<AddPatientDto>(addPatient));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
