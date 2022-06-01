using Medical.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medical.Models.DTOs
{
    public class AddPatientRequestDto
    {
        public PatientDto Patient { get; set; }
        public OrderingPhysicianDto ordering_physician { get; set; }
        public ReadingPhysicianDto reading_physician { get; set; }
    }

    public class PatientDto
    {
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string PatientId { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(200)]
        public string Address2 { get; set; }
        [StringLength(200)]
        public string City { get; set; }
        public int State { get; set; }
        [StringLength(10)]
        public string Zip { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(3)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public StudyMode StudyMode { get; set; }
        public int StudyDuration { get; set; }
        [StringLength(500)]
        public string Indication { get; set; }
    }

    public class OrderingPhysicianDto
    {
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string OrderingPhone { get; set; }
        public string ClinicName { get; set; }
    }

    public class ReadingPhysicianDto
    {
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string ReadingPhone { get; set; }
        public string ClinicName { get; set; }
    }
}
