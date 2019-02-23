using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using HappyVampire.DataAccess.Repository;

namespace HappyVampire.BusinessLogic.Services
{
    public class DonationService : CRUDService<Donation, DonationDTO>, IDonationService
    {
        private readonly IDonorService donorService;

        public DonationService(IUnitOfWork uow, IMapper mapper, IDonorService donorService) : base(uow, mapper)
        {
            this.donorService = donorService;
        }

        public override async Task<bool> AddAsync(DonationDTO item)
        {
            if (item != null)
            {
                var donor = item.Donor;
                donor.Rating += item.Amount;
                await uow.Repository<Donor>().Update(mapper.Map<Donor>(donor));
                await uow.SaveAsync();

            }

            return await base.AddAsync(item);
        }
    }
}

