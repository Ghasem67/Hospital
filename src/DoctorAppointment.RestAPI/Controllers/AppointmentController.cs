using DoctorAppointment.Services.Appointments.Constract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public void Add(CreateAppointMentDTO createAppointMentDTO)
        {
            _appointmentService.Add(createAppointMentDTO);

        }
        [HttpPut]
        public void Edit(EditAppointmentDTO editAppointmentDTO)
        {
            _appointmentService.Edit(editAppointmentDTO);
        }
        [HttpDelete]
        public void Delete(int Id)
        {
            _appointmentService.Delete(Id);
        }
        [HttpGet]
        public List<ShowAppointmentDTO> Get()
        {
           return _appointmentService.GetAll();
        }
    }
}
