
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Constract
{
    public class EditAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}
