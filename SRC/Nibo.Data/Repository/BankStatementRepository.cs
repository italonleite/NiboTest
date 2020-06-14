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

        public async Task<IEnumerable<BankStatement>> ObterBankStatementTransaction()
        {
            return await Db.BankStatements.AsNoTracking().Include(f => f.Transactions)
               .ToListAsync();

        }

       
    }      

    }

