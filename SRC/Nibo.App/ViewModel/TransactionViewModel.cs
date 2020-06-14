using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nibo.App.ViewModel
{
    public class TransactionViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BankStatementId { get; set; }

        public int Type { get; set; }

        public DateTime TransactionPostDate { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }

        public BankStatementViewModel BankStatement { get; set; }

        
    }
}