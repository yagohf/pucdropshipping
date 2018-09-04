using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.TransactionContainer;

namespace Yagohf.PUC.Data.TransactionContainer
{
    public class TransactionContainer : ITransactionContainer
    {
        private readonly LojaDbContext _context;

        public TransactionContainer(LojaDbContext context)
        {
            this._context = context;
        }

        public void BeginTransaction()
        {
            this._context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this._context.Database.CommitTransaction();
        }

        public void DisposeTransaction()
        {
            if (this._context.Database.CurrentTransaction != null)
            {
                this._context.Database.CurrentTransaction.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            this._context.Database.RollbackTransaction();
        }
    }
}
