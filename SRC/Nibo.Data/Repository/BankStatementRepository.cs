using Nibo.Business.Interfaces;
using Nibo.Business.Models;
using Nibo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Data.Repository
{
    public class BankStatementRepository : Repository<BankStatement>, IBankStatementRepository
    {
        public BankStatementRepository(MeuDbContext context) : base(context)
        {

        }      

    }
}
