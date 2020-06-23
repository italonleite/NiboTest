using Moq;
using Nibo.Business.Interfaces;
using Nibo.Business.Services;
using Nibo.Data.Repository;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace Nibo.Test
{

    public class IOServiceTest
    {
        [Fact]
        public void ShouldReadFile1()
        {


            // Arrange
            var service = new IOService();
            var fileName = "extrato1.ofx";

            // Action
            var builder = service.ReadFile(fileName);

            //Assert
            Assert.NotNull(builder);
            Assert.Equal(5120, builder.Length);
        }

        [Fact]
        public void ShouldReadFile2()
        {
            // Arrange
            var service = new IOService();
            var fileName = "extrato2.ofx";

            // Action
            var builder = service.ReadFile(fileName);

            //Assert
            Assert.NotNull(builder);
            Assert.Equal(4096, builder.Length);
        }
    }
}
