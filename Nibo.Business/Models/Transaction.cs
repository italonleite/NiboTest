using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Business.Models
{
   public class Transaction : Entity
    {
        public Guid BankStatementId { get; set; }
       
        public Type Type { get; set; }

        public DateTime TransactionPostDate { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }

        public BankStatement BankStatement { get; set; }

    }
}
