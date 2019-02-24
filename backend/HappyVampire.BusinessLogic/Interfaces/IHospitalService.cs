using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;

namespace HappyVampire.BusinessLogic.Interfaces
{
    public interface IHospitalService : ICRUDService<Hospital, HospitalDTO>
    {
        Task<HospitalDTO> AddPatient(int hospitalId, PatientDTO patient);
        Task<HospitalDTO> UpdatePatient(int hospitalId, PatientDTO patient);
        Task<bool> DeletePatient(int hospitalId, int patientId);
    }
}
