using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorsController(DoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddDoctor(AddDoctorDto dto)
        {
            _service.Add(dto);
        }
        [HttpPut("{Id}")]
        public void Edit(int Id,EditDoctorDTO editDoctorDTO)
        {
            _service.Edit(Id,editDoctorDTO);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _service.Delete(Id);
        }
        [HttpGet]
        public List<ShowDoctorDTO> Get()
        {
          return  _service.GetAll();
        }

    }
}
