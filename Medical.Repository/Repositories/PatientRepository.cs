using Medical.Common;
using Medical.Common.Helpers;
using Medical.Models.DTOs;
using Medical.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Medical.Repository.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository()
        {
            _connectionString = MemCache.ConnectionStrings.HS33Connection;
        }

        public async Task<bool> AddPatient(AddPatientDto addPatient)
        {
            try
            {
                SqlCommand cmd = new()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_CreatePatient"
                };

                cmd.Parameters.Add(new SqlParameter("@IDDevice", addPatient.IDDevice));
                cmd.Parameters.Add(new SqlParameter("@Name", addPatient.FirstName));
                cmd.Parameters.Add(new SqlParameter("@Gender", addPatient.Gender));
                cmd.Parameters.Add(new SqlParameter("@DOB", addPatient.DOB));
                cmd.Parameters.Add(new SqlParameter("@IndForMonitor", addPatient.IndForMonitor));
                cmd.Parameters.Add(new SqlParameter("@Comment", addPatient.Comment));
                cmd.Parameters.Add(new SqlParameter("@LastName", addPatient.LastName));
                cmd.Parameters.Add(new SqlParameter("@MI", addPatient.MI));
                cmd.Parameters.Add(new SqlParameter("@SSN", addPatient.SSN));
                cmd.Parameters.Add(new SqlParameter("@PatientIDClinic", addPatient.PatientIDClinic));
                cmd.Parameters.Add(new SqlParameter("@Contact1", addPatient.Contact1));
                cmd.Parameters.Add(new SqlParameter("@Contact2", addPatient.Contact2));
                cmd.Parameters.Add(new SqlParameter("@Contact3", addPatient.Contact3));
                cmd.Parameters.Add(new SqlParameter("@Address", addPatient.Address));
                cmd.Parameters.Add(new SqlParameter("@Address2", addPatient.Address2));
                cmd.Parameters.Add(new SqlParameter("@City", addPatient.City));
                cmd.Parameters.Add(new SqlParameter("@State", addPatient.State));
                cmd.Parameters.Add(new SqlParameter("@Zip", addPatient.Zip));
                cmd.Parameters.Add(new SqlParameter("@IDPhysicianReferring", addPatient.IDPhysicianReferring));
                cmd.Parameters.Add(new SqlParameter("@IDClinicPhysicianReading", addPatient.IDClinicPhysicianReading));
                cmd.Parameters.Add(new SqlParameter("@IDClinicPhysicianOrdering", addPatient.IDClinicPhysicianOrdering));
                cmd.Parameters.Add(new SqlParameter("@IDClinicPhysicianReferring", addPatient.IDClinicPhysicianReferring));
                cmd.Parameters.Add(new SqlParameter("@IsRemoved", addPatient.IsRemoved));
                cmd.Parameters.Add(new SqlParameter("@TimeZoneStandardName", addPatient.TimeZoneStandardName));
                cmd.Parameters.Add(new SqlParameter("@DST", addPatient.DST));
                cmd.Parameters.Add(new SqlParameter("@IDCenter", addPatient.IDCenter));
                cmd.Parameters.Add(new SqlParameter("@Medications", addPatient.Medications));
                cmd.Parameters.Add(new SqlParameter("@CardiacDevice", addPatient.CardiacDevice));
                cmd.Parameters.Add(new SqlParameter("@StudyMode", addPatient.StudyMode));
                cmd.Parameters.Add(new SqlParameter("@StudyDuration", addPatient.StudyDuration));
                cmd.Parameters.Add(new SqlParameter("@OrderingPhysicianLastName", addPatient.OrderingPhysicianLastName));
                cmd.Parameters.Add(new SqlParameter("@OrderingPhysicianFirstName", addPatient.OrderingPhysicianFirstName));
                cmd.Parameters.Add(new SqlParameter("@OrderingPhysicianPhone", addPatient.OrderingPhysicianPhone));
                cmd.Parameters.Add(new SqlParameter("@OrderingPhysicianClinicName", addPatient.OrderingPhysicianClinicName));
                cmd.Parameters.Add(new SqlParameter("@ReadingPhysicianLastName", addPatient.ReadingPhysicianLastName));
                cmd.Parameters.Add(new SqlParameter("@ReadingPhysicianFirstName", addPatient.ReadingPhysicianFirstName));
                cmd.Parameters.Add(new SqlParameter("@ReadingPhysicianPhone", addPatient.ReadingPhysicianPhone));
                cmd.Parameters.Add(new SqlParameter("@ReadingPhysicianClinicName", addPatient.ReadingPhysicianClinicName));

                using Database db = new(_connectionString);
                using SqlDataReader rdr = await db.ExecuteReaderAsync(cmd);

                return rdr?.RecordsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
