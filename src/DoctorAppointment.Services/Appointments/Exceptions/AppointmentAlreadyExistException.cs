using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Exceptions
{
    public class AppointmentAlreadyExistException:Exception
    {
        public AppointmentAlreadyExistException() { }
        public AppointmentAlreadyExistException(string message) : base(String.Format("AppointmentAlreadyExist {0}", message)) { }
    }
}
