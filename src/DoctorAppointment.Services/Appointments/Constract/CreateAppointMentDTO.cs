using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Constract
{
    public class CreateAppointMentDTO
    {
        public DateTime Date { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}
