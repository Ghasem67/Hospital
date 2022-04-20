using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Exceptions;
using DoctorAppointment.Services.Patients.Contracts;
using DoctorAppointment.Services.Patients.Exceptions;
using System;
using System.Collections.Generic;

namespace DoctorAppointment.Services.Patients
{
    public class PatientAppService : PatientServece
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly PatientRepository _patientRepository;
        public PatientAppService(UnitOfWork unitOfWork, PatientRepository patientRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }


        public void Add(CreatePatientDTO createPatientDTO)
        {
            var ispatientExist = _patientRepository.IsExistNationalCode(createPatientDTO.NationalCode);
            if (ispatientExist)
            {
                try
                {
                    throw new PatientAlreadyExistException("already exist");
                }
                catch (Exception ex)
                {
                    
                }
            }
            Patient patient = new Patient
            {
                FirstName = createPatientDTO.FirstName,
                LastName = createPatientDTO.LastName,
                NationalCode = createPatientDTO.NationalCode
            };

            _patientRepository.Add(patient);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var patient = _patientRepository.Get(id);
            if (patient != null)
            {
                _patientRepository.Delete(patient);
                _unitOfWork.Commit();
            }
        }

        public void Edit(EditPatientDTO editPatientDTO)
        {
            var patient = _patientRepository.Get(editPatientDTO.Id);
            if (patient != null)
            {
                patient.NationalCode = editPatientDTO.NationalCode;
                patient.LastName = editPatientDTO.LastName;
                patient.FirstName = editPatientDTO.FirstName;
            }
            var PatientWithNationalCode = _patientRepository.GetbyNationalCode(patient.NationalCode);
            if (PatientWithNationalCode.Id.Equals(patient.Id))
            {
                throw new Exception();
            }
            _unitOfWork.Commit();
        }


        public List<ShowPatientDTO> GetAll()
        {
            return _patientRepository.GetAll();
        }
    }
}
