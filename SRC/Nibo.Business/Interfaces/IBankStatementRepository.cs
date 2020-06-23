using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nibo.Business.Interfaces
{
    public interface IBankStatementRepository : IRepository<BankStatement>
    {
        void RemoveRecords();
        Task RemoveDuplicates(IEnumerable<Transaction> transactions);
        Task<IEnumerable<BankStatement>> GetBankStatementTransactions();
    }
    
}
