using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Business.Models
{
   public class BankStatement : Entity
    {
        public SignOn SignOn { get; set; }

        public Status Status { get; set; }

        public string Currency { get; set; }

        public BankAccount BankAccount { get; set; }

        public DateTime StatementStart { get; set; }

        public DateTime StatementEnd { get; set; }   

        public IEnumerable<Transaction> Transactions { get; set; }

        public Balance Balance { get; set; }
    }
}
