﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using HappyVampire.DataAccess.Repository;

namespace HappyVampire.BusinessLogic.Services
{
    public class DonorService : CRUDService<Donor, DonorDTO>, IDonorService
    {
        public DonorService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}

