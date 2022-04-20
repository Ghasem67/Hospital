using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Constract
{
    public class ShowAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string DoctorName { get; set; }

        public string  PatientName { get; set; }
    }
}
