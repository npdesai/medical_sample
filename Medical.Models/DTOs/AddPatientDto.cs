using Medical.Models.Enums;
using System;

namespace Medical.Models.DTOs
{
    public class AddPatientDto
    {
        public int IDDevice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string IndForMonitor { get; set; }
        public string Comment { get; set; }
        public string MI { get; set; }
        public string SSN { get; set; }
        public string PatientIDClinic { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Contact3 { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string Zip { get; set; }
        public StudyMode StudyMode { get; set; }
        public int StudyDuration { get; set; }
        public int IDPhysicianReferring { get; set; }
        public int IDClinicPhysicianReading { get; set; }
        public int IDClinicPhysicianOrdering { get; set; }
        public int IDClinicPhysicianReferring { get; set; }
        public int IsRemoved { get; set; }
        public string TimeZoneStandardName { get; set; }
        public int DST { get; set; }
        public int IDCenter { get; set; }
        public string Medications { get; set; }
        public string CardiacDevice { get; set; }
        public string OrderingPhysicianLastName { get; set; }
        public string OrderingPhysicianFirstName { get; set; }
        public string OrderingPhysicianPhone { get; set; }
        public string OrderingPhysicianClinicName { get; set; }
        public string ReadingPhysicianLastName { get; set; }
        public string ReadingPhysicianFirstName { get; set; }
        public string ReadingPhysicianPhone { get; set; }
        public string ReadingPhysicianClinicName { get; set; }
    }
}
