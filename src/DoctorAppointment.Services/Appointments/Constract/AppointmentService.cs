using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Constract
{
    public interface AppointmentService
    {
        void Add(CreateAppointMentDTO appointmentdto);
        void Delete(int id);
        void Edit(EditAppointmentDTO appointment);
         List<ShowAppointmentDTO> GetAll();
    }
}
