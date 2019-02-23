using System;
using System.Collections.Generic;
using System.Text;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;

namespace HappyVampire.BusinessLogic.Interfaces
{
    public interface IDonorService : ICRUDService<Donor, DonorDTO>
    {
    }
}
