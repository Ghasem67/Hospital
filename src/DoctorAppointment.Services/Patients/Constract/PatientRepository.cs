using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientRepository
    {
        public void Add(Patient patient);
        public void Delete(Patient patient);
        public List<ShowPatientDTO> GetAll();
        public Patient Get(int id);
        public bool IsExistNationalCode(string nationalCode);
        public Patient GetbyNationalCode(string nationalCode);
    }
}
