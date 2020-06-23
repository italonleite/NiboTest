using Nibo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Nibo.Business.Models
{
    public class Transaction : Entity, IEquatable<Transaction>
    {
        public Guid BankStatementId { get; set; }

        public EType Type { get; set; }

        public DateTime TransactionPostDate { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }

        public BankStatement BankStatement { get; set; }



        public void SetValue(string line)
        {
            var pos = line.IndexOf(">") + 1;
            var value = line.Substring(pos);


            if (line.Contains("TRNTYPE"))
            {
                if (value == "DEBIT")
                {
                    Type = EType.Debit;
                }
                else
                {
                    Type = EType.Credit;
                }
            }
            else if (line.Contains("DTPOSTED"))
            {
                // 20140201100000 [-03:EST]            

                int year, month, day, hour, minute, second;
                year = int.Parse(value.Substring(0, 4));
                month = int.Parse(value.Substring(4, 2));
                day = int.Parse(value.Substring(6, 2));
                hour = int.Parse(value.Substring(8, 2));
                minute = int.Parse(value.Substring(10, 2));
                second = int.Parse(value.Substring(12, 2));


                long ano = long.Parse(value.Remove(14));

                TransactionPostDate = new DateTime(year, month, day, hour, minute, second);

            }
            else if (line.Contains("TRNAMT"))
            {
                Amount = Decimal.Parse(value);

            }
            else if (line.Contains("MEMO"))
            {
                Memo = value;

            }
        }

        public bool Equals(Transaction other)
        {
            return other is Transaction transaction
                   && Type == transaction.Type
                   && TransactionPostDate == transaction.TransactionPostDate
                   && Amount == transaction.Amount
                   && Memo == transaction.Memo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, TransactionPostDate, Amount, Memo);
        }
    }

}
