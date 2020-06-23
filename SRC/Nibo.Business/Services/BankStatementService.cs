
using Nibo.Business.Interfaces;
using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nibo.Business.Services
{
    public class BankStatementService : IBankStatementService
    {
        private IBankStatementRepository _repository { get; }

        public BankStatementService(IBankStatementRepository repository)
        {
            _repository = repository;
        }

        public BankStatementService()
        {

        }

        public async Task Save(BankStatement bankStatement)
        {
            await _repository.Save(bankStatement);
        }

        public void RemoveRecords()
        {
            DirectoryInfo di = new DirectoryInfo("F:\\Projetos\\NiboTest\\SRC\\Nibo.App\\wwwroot\\Data\\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            _repository.RemoveRecords();

        }

        public async Task<IEnumerable<Transaction>> RemoveDuplicates(IEnumerable<Transaction> transactions)
        {
            var list = transactions.Distinct().ToList();
            //Comente a linha abaixo para passar no teste(GetTransactionsNotDuplicate)
            await _repository.RemoveDuplicates(list);
            return list;
        }
    }
}
