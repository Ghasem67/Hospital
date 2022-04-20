using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Exceptions
{
    public class PatientAlreadyExistException:Exception
    {
        public PatientAlreadyExistException() { }
        public PatientAlreadyExistException(string message)
        :base(String.Format("PatientAlreadyExist{0}",message))
        { }
    }
}
