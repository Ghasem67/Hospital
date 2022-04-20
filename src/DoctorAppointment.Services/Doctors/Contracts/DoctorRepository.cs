using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository 
    {
        void Add(Doctor doctor);
        bool IsExistNationalCode(string nationalCode);
        List<ShowDoctorDTO> GetAll();
        void Delete(Doctor doctor);
        Doctor GetOneDoctor(int Id);
        public Doctor GetOneDoctorWithNatinalCode(string nationalCode);
    }
}
