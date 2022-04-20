using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        private readonly PatientServece _patientServece;
        public PatientsController(PatientServece patientServece)
        {
            _patientServece = patientServece;
        }
        [HttpPost]
        public void Add(CreatePatientDTO createPatientDTO)
        {
            _patientServece.Add(createPatientDTO);
        }
        [HttpPut]
        public void Edit(EditPatientDTO editPatientDTO)
        {
            _patientServece.Edit(editPatientDTO);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _patientServece.Delete(id);
        }
        [HttpGet]
        public List<ShowPatientDTO> Get()
        {
            return _patientServece.GetAll();
        }
    }
}
