using Microsoft.EntityFrameworkCore;
using Nibo.Business.Interfaces;
using Nibo.Business.Models;
using Nibo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nibo.Data.Repository
{
    public class BankStatementRepository : Repository<BankStatement>, IBankStatementRepository
    {
        public BankStatementRepository(MyDbContext context) : base(context)
        { 
        }
            public async Task<BankStatement> ObterBankStatementTransaction(Guid id)
            {
                return await Db.BankStatements.AsNoTracking()
                    .Include(t => t.Transactions)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
        }      

    }

