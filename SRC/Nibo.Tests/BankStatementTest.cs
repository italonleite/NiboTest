using Nibo.Business.Models;
using Nibo.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Nibo.Test
{
    public class BankStatementTest
    {
        [Fact]
        public void BankStatemenListTransaction_ToPropertyMemo_MustNotBeEmpty()
        {
            //Arrange
            var service = new IOService();
            var fileName = "extrato1.ofx";
            var builder = service.ReadFile(fileName);

            //Action
            var bank = new BankStatement();
            var BankStatement = bank.Create(builder, bank.Id);

            //Assert
            Assert.All(BankStatement.Transactions, Transactions => Assert.False(string.IsNullOrWhiteSpace(Transactions.Memo)));
            Assert.Equal(35, BankStatement.Transactions.Count);

        }
    }
}
