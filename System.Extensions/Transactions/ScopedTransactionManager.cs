using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Transactions
{
    public class ScopedTransactionManager : IUnitOfWork
    {
        private TransactionScope scope;

        public async Task BeginTransaction()
        {
            scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            await Task.Run(() => { });
        }

        public async Task Commit()
        {
            scope.Complete();

            scope.Dispose();

            scope = null;

            await Task.Run(() => { });
        }

        public async Task Rollback()
        {
            scope.Dispose();

            scope = null;

            await Task.Run(() => { });
        }
    }
}
