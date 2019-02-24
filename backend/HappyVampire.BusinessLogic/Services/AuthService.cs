using AutoMapper;
using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using HappyVampire.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVampire.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;
        protected readonly IUserService userService;

        public AuthService(IUnitOfWork uow, IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.userService = userService;
        }

        public async Task<DonorDTO> RegisterDonorAsync(string Uid, DonorDTO donor)
        {
            await userService.AddAsync(new UserDTO { Id = 0, Uid = Uid, IsDonor = true });
            var user = (await userService.GetAllAsync()).FirstOrDefault(u => u.Uid == Uid);
            if (uow != null && user != null)
            {
                donor.User = user;
                var result = await uow.Repository<Donor>().CreateAsync(mapper.Map<Donor>(donor));
                if (result != null)
                {
                    await uow.SaveAsync();
                    return mapper.Map<DonorDTO>(result);
                }
            }
            return null;
        }

        public async Task<HospitalDTO> RegisterHospitalAsync(string Uid, HospitalDTO hospital)
        {
            await userService.AddAsync(new UserDTO { Id = 0, Uid = Uid, IsDonor = false });
            var user = (await userService.GetAllAsync()).FirstOrDefault(u => u.Uid == Uid);
            if (uow != null && user != null)
            {
                hospital.User = user;
                var result = await uow.Repository<Hospital>().CreateAsync(mapper.Map<Hospital>(hospital));
                if (result != null)
                {
                    await uow.SaveAsync();
                    return mapper.Map<HospitalDTO>(result);
                }
            }
            return null;
        }
    }
}
