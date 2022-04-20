using DoctorAppointment.Services.Patients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientServece
    {
        public void Add(CreatePatientDTO createPatientDTO);
        public void Edit(EditPatientDTO editPatientDTO);
        public void Delete(int id);
        public List<ShowPatientDTO> GetAll();
    }
}
