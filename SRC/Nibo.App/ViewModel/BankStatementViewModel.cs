using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nibo.App.ViewModel
{
    public class BankStatementViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StatementStart { get; set; }

        public DateTime StatementEnd { get; set; }

        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}

