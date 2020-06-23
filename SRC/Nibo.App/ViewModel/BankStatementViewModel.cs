using Microsoft.AspNetCore.Http;
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

        public IFormFile FileUpload { get; set; }

        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}

