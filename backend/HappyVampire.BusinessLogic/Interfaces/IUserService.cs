using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.BusinessLogic.Interfaces
{
    public interface IUserService : ICRUDService<User, UserDTO>
    {
    }
}
