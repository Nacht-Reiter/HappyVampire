using HappyVampire.DataAccess.Entities;
using System.Threading.Tasks;

namespace HappyVampire.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> SaveAsync();
    }
}
