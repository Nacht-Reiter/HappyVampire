using AutoMapper;
using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using HappyVampire.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.BusinessLogic.Services
{
    public class UserService : CRUDService<User, UserDTO>, IUserService
    {
        public UserService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}
