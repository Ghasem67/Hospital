using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Constract
{
    public interface AppointmentRepository
    {
        public void Add(Appointment appointment);

        public void Remove(Appointment appointment);
        public Appointment Get(int id);
        public List<ShowAppointmentDTO> GetAll();
        public Appointment GetwithPatientDate(int doctorId, int patientId, DateTime PatientDate);

    }
}
