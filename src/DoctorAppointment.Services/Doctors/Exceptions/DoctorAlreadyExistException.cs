using System;

namespace DoctorAppointment.Services.Doctors.Exceptions
{
    [Serializable]
    public class DoctorAlreadyExistException : Exception
    {
        public DoctorAlreadyExistException() { }
        public DoctorAlreadyExistException(string name)
            :base(String.Format("DoctorAlreadyExist {0}", name))
        { }
    }
}