using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using HappyVampire.DataAccess.Repository;

namespace HappyVampire.BusinessLogic.Services
{
    public class HospitalService : CRUDService<Hospital, HospitalDTO>, IHospitalService
    {
        public HospitalService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public async Task<HospitalDTO> AddPatient(int hospitalId, PatientDTO patient)
        {
            if (uow != null)
            {
                var hospital = await uow.Repository<Hospital>().GetAsync(hospitalId);
                if(hospital == null)
                {
                    return null;
                }
                hospital.Patients.Add(mapper.Map<Patient>(patient));
                var result = await uow.Repository<Hospital>().Update(hospital);
                if (result != null)
                {
                    await uow.SaveAsync();
                    return mapper.Map<HospitalDTO>(result);
                }
            }
            return null;
        }

        public async Task<bool> DeletePatient(int hospitalId, int patientId)
        {
            if (uow != null)
            {
                var hospital = await uow.Repository<Hospital>().GetAsync(hospitalId);
                if (hospital == null)
                {
                    return false;
                }
                var target = hospital.Patients.FirstOrDefault(s => s.Id == patientId);
                if(target == null)
                {
                    return false;
                }
                hospital.Patients.Remove(mapper.Map<Patient>(target));
                var result = await uow.Repository<Hospital>().Update(hospital);
                var info = await uow.Repository<Patient>().DeleteAsync(target.Id);
                if (result != null && info != null)
                {
                    await uow.SaveAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<HospitalDTO> UpdatePatient(int hospitalId, PatientDTO patient)
        {
            var pt = await uow.Repository<Patient>().Update(mapper.Map<Patient>(patient));
            await uow.SaveAsync();
            return mapper.Map<HospitalDTO>(await uow.Repository<Hospital>().GetAsync(hospitalId));
        }
    }
}
