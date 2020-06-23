using Microsoft.EntityFrameworkCore;
using Nibo.Business.Interfaces;
using Nibo.Business.Models;
using Nibo.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibo.Data.Repository
{
    public class BankStatementRepository : Repository<BankStatement>, IBankStatementRepository
    {
        public BankStatementRepository(MyDbContext context) : base(context)
        {
        }
        public BankStatementRepository()
        {

        }
        public async Task<IEnumerable<BankStatement>> GetBankStatementTransactions()
        {
            return await Db.BankStatements.AsNoTracking().Include(f => f.Transactions)
               .ToListAsync();
        }


        public void RemoveRecords()
        {

            Db.BankStatements.RemoveRange(Db.BankStatements.ToList());
            Db.SaveChanges();

        }

        public async Task RemoveDuplicates(IEnumerable<Transaction> transactions)
        {
            RemoveRecords();
            var bs = new BankStatement();
            bs.Transactions = transactions.ToList();
            await Save(bs);
        }
    }

}

