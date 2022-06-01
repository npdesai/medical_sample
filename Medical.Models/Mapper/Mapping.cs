using AutoMapper;
using Medical.Models.DTOs;

namespace Medical.Models.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddPatientRequestDto, AddPatientDto>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Patient.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.Patient.LastName))
                .ForMember(d => d.PatientIDClinic, o => o.MapFrom(s => s.Patient.PatientId))
                .ForMember(d => d.DOB, o => o.MapFrom(s => s.Patient.DateOfBirth))
                .ForMember(d => d.Contact1, o => o.MapFrom(s => s.Patient.Phone))
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.Patient.Gender))
                .ForMember(d => d.Contact2, o => o.MapFrom(s => s.Patient.Email))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Patient.Address))
                .ForMember(d => d.Address2, o => o.MapFrom(s => s.Patient.Address2))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Patient.City))
                .ForMember(d => d.State, o => o.MapFrom(s => s.Patient.State))
                .ForMember(d => d.Zip, o => o.MapFrom(s => s.Patient.Zip))
                .ForMember(d => d.StudyMode, o => o.MapFrom(s => s.Patient.StudyMode))
                .ForMember(d => d.StudyDuration, o => o.MapFrom(s => s.Patient.StudyDuration))
                .ForMember(d => d.IndForMonitor, o => o.MapFrom(s => s.Patient.Indication))
                .ForMember(d => d.OrderingPhysicianFirstName, o => o.MapFrom(s => s.ordering_physician.FirstName))
                .ForMember(d => d.OrderingPhysicianLastName, o => o.MapFrom(s => s.ordering_physician.LastName))
                .ForMember(d => d.OrderingPhysicianPhone, o => o.MapFrom(s => s.ordering_physician.OrderingPhone))
                .ForMember(d => d.OrderingPhysicianClinicName, o => o.MapFrom(s => s.ordering_physician.ClinicName))
                .ForMember(d => d.ReadingPhysicianFirstName, o => o.MapFrom(s => s.reading_physician.FirstName))
                .ForMember(d => d.ReadingPhysicianLastName, o => o.MapFrom(s => s.reading_physician.LastName))
                .ForMember(d => d.ReadingPhysicianPhone, o => o.MapFrom(s => s.reading_physician.ReadingPhone))
                .ForMember(d => d.ReadingPhysicianClinicName, o => o.MapFrom(s => s.reading_physician.ClinicName))
                .ReverseMap();
        }
    }
}
