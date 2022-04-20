using DoctorAppointment.Entities;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly DbSet<Patient> _patients;

        public EFPatientRepository(ApplicationDbContext context)
        {
            _patients = context.Set<Patient>();
        }

        public void Add(Patient patient)
        {
            _patients.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _patients.Remove(patient);
        }

        public Patient Get(int id)
        {
            return _patients.FirstOrDefault(x=>x.Id == id);
        }

        public List<ShowPatientDTO> GetAll()
        {
            return _patients.Select(x => new ShowPatientDTO {Id=x.Id,FirstName=x.FirstName,LastName=x.LastName,NationalCode=x.NationalCode }).ToList();
        }

        public Patient GetbyNationalCode(string nationalCode)
        {
            return _patients.First(_ => _.NationalCode.Equals(nationalCode));
        }

        public bool IsExistNationalCode(string nationalCode)
        {
           return _patients.Where(x => x.NationalCode == nationalCode).Any();
        }
    }
}
