using CustomerLeadImageUpload.Data.Models;
using CustomerLeadImageUpload.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerLeadImageUpload.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;

        int Save();
        Task<int> SaveAsync();

        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        Task<IDbContextTransaction> BeginTransactionAsync();
        public Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }

}
