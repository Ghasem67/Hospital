using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode,
            };
            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode);

            if(isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public void Delete(int Id)
        {
            var Doctor=_repository.GetOneDoctor(Id);
            if (Doctor!=null)
            {
                _repository.Delete(Doctor);
                _unitOfWork.Commit();
            }
        }

        public void Edit(int Id,EditDoctorDTO editDoctorDTO)
        {
            var docter = _repository.GetOneDoctor(Id);
            if(docter != null)
            {
                docter.FirstName = editDoctorDTO.FirstName;
                docter.LastName = editDoctorDTO.LastName;
                docter.Field = editDoctorDTO.Field;
                docter.NationalCode = editDoctorDTO.NationalCode;
            }
            var OneDoctorWithNationalCode =_repository.GetOneDoctorWithNatinalCode(editDoctorDTO.NationalCode);
            if (!OneDoctorWithNationalCode.Id.Equals(Id))
            {
                throw new Exception();
            }
            _unitOfWork.Commit();
        }
        

        public List<ShowDoctorDTO> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
