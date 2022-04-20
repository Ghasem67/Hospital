using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorService
    {
        void Add(AddDoctorDto dto);
        void Edit(int Id,EditDoctorDTO editDoctorDTO);
        void Delete(int  Id);
        List<ShowDoctorDTO> GetAll();
    }
}
