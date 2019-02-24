using HappyVampire.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HappyVampire.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task<DonorDTO> RegisterDonorAsync(string Uid, DonorDTO donor);
        Task<HospitalDTO> RegisterHospitalAsync(string Uid, HospitalDTO hospital);
    }
}
