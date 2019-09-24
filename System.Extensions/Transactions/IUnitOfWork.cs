using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Transactions
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();

        Task Commit();

        Task Rollback();
    }
}
