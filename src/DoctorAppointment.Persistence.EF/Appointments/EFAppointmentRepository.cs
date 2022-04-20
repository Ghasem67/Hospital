using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appointments.Constract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly DbSet<Appointment> _appointments;

        public EFAppointmentRepository(ApplicationDbContext context)
        {
            _appointments = context.Set<Appointment>();
        }

        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public Appointment Get(int id)
        {
            return _appointments.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Appointment GetwithPatientDate(int doctorId, int patientId, DateTime PatientDate)
        {
            return _appointments.FirstOrDefault(x => x.PatientId.Equals(patientId) && x.DoctorId.Equals(doctorId) && x.Date.Date == PatientDate.Date);
        }

        public List<ShowAppointmentDTO> GetAll()
        {
            return _appointments.Select(x =>new ShowAppointmentDTO {Id=x.Id,Date=x.Date,
                DoctorName=x.Doctor.FirstName+" "+x.Doctor.LastName,
                PatientName=x.Patient.NationalCode+" "+x.Patient.LastName } ).ToList();
        }

        public void Remove(Appointment appointment)
        {
            _appointments.Remove(appointment);
        }

        

       
    }
}
