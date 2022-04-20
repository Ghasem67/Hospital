using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctorRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
           _doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

     

        public List<ShowDoctorDTO> GetAll()
        {
            return _doctors.Select(x => new ShowDoctorDTO {Field=x.Field,FirstName=x.FirstName,Id=x.Id,LastName=x.LastName,NationalCode=x.NationalCode }).ToList();
        }

        public Doctor GetOneDoctor(int Id)
        {
            return _doctors.Find(Id);
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _doctors.Any(_ => _.NationalCode == nationalCode);
        }
        public Doctor GetOneDoctorWithNatinalCode(string nationalCode)
        {
            return _doctors.First(x=>x.NationalCode.Equals(nationalCode));
        }
    }
}
