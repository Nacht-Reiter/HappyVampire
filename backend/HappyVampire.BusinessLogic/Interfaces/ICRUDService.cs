using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HappyVampire.BusinessLogic.Interfaces
{
    public interface ICRUDService<TEntity, TDTO> where TEntity : Entity where TDTO : BasicDTO
    {
        Task<TDTO> GetAsync(int id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<bool> AddAsync(TDTO item);
        Task<bool> DeleteAsync(int id);
        Task<TDTO> UpdateAsync(int id, TDTO item);
    }
}
