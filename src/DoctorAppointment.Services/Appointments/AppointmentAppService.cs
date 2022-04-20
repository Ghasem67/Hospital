using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appointments.Constract;
using DoctorAppointment.Services.Appointments.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _appointments;
        private readonly UnitOfWork _unitOfWork;
        public AppointmentAppService(AppointmentRepository appointments, UnitOfWork unitOfWork)
        {
            _appointments = appointments;
            _unitOfWork = unitOfWork;
        }

        public void Add(CreateAppointMentDTO appointmentdto)
        {
            Appointment appointment = new Appointment
            {
                Date = appointmentdto.Date,
                DoctorId=appointmentdto.DoctorId,
                PatientId=appointmentdto.PatientId
            };
          var OnePatient=  _appointments.GetwithPatientDate(appointmentdto.DoctorId, appointmentdto.PatientId, appointmentdto.Date);
            if (OnePatient!=null)
            {
                throw new AppointmentAlreadyExistException();
            }
            _appointments.Add(appointment);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var appointment=_appointments.Get(id);
            _appointments.Remove(appointment);
            _unitOfWork.Commit();
        }

        public void Edit(EditAppointmentDTO editAppointmentDTO)
        {
            var appointment = _appointments.Get(editAppointmentDTO.Id);
            if (appointment!=null)
            {
                appointment.Date = editAppointmentDTO.Date;
                appointment.DoctorId=editAppointmentDTO.DoctorId;
                appointment.PatientId=editAppointmentDTO.PatientId;
            }
            var OnePatient = _appointments.GetwithPatientDate(editAppointmentDTO.DoctorId,
                editAppointmentDTO.PatientId, editAppointmentDTO.Date);
            if (OnePatient != null)
            {
                throw new AppointmentAlreadyExistException();
            }
            _unitOfWork.Commit();
        }

        public List<ShowAppointmentDTO> GetAll()
        {
           return _appointments.GetAll();
        }
    }
}
