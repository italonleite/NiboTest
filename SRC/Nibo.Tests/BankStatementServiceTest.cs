using Moq;
using Nibo.Business.Interfaces;
using Nibo.Business.Models;
using Nibo.Business.Services;
using Nibo.Data.Context;
using Nibo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nibo.Test
{
    public class BankStatementServiceTest
    {
        private BankStatementService service;

        public BankStatementServiceTest()
        {
            //Arrange(initialize all tests)
            var bsRepoMock = new Mock<BankStatementRepository>();

            service = new BankStatementService(bsRepoMock.Object);

        }


        [Fact]
        public async Task GetTransactionsNotDuplicate()
        {
            //Arrange
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e90"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 6, 10) });
            transactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e91"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 6, 10) });
            transactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e92"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 7, 10) });
            transactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e93"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 8, 10) });
            transactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e94"), Type = EType.Credit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 6, 10) });

            var expectedTransactions = new List<Transaction>();
            expectedTransactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e91"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 6, 10) });
            expectedTransactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e92"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 7, 10) });
            expectedTransactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e93"), Type = EType.Debit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 8, 10) });
            expectedTransactions.Add(new Transaction() { Id = Guid.Parse("ac64a804-7b8f-422d-95ae-d9b67dd73e94"), Type = EType.Credit, Amount = 100M, Memo = "Curso de TDD", TransactionPostDate = new System.DateTime(2020, 6, 10) });


            // Action
            var actualTransactions = await service.RemoveDuplicates(transactions);


            //Assert
            Assert.Equal(expectedTransactions, actualTransactions);


        }
    }
}
