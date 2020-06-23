using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Business.Models
{
    public class BankStatement : Entity
    {

        public List<Transaction> Transactions { get; set; }

        public BankStatement(List<Transaction> transactions)
        {

            Transactions = transactions;
        }

        public BankStatement()
        {

        }

        public BankStatement Create(StringBuilder builder, Guid id)
        {

            var transactions = CreateTransactions(builder, id);
            var bankStatementTransaction = new BankStatement(transactions);
            bankStatementTransaction.Id = id;

            return bankStatementTransaction;

        }

        public List<Transaction> CreateTransactions(StringBuilder builder, Guid id)
        {
            var lines = builder.ToString().Split("\r\n"); // get number lines
            var length = lines.Length;

            var transactions = new List<Transaction>();
            var transaction = new Transaction();
            transaction.BankStatementId = id;
            for (int i = 0; i < length; i++)
            {
                var line = lines[i];

                var isTransaction = line.Contains("TRNTYPE")
                                    || line.Contains("DTPOSTED")
                                    || line.Contains("TRNAMT")
                                    || line.Contains("MEMO");

                if (isTransaction)
                {
                    transaction.SetValue(line);

                    if (!string.IsNullOrEmpty(transaction.Memo))
                    {

                        transactions.Add(transaction);
                        transaction = new Transaction();
                        transaction.BankStatementId = id;
                    }

                }
            }

            return transactions;
        }

    }
}
