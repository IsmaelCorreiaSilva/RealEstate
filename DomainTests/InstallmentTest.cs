
using Domain.Entities;
using Domain.Exceptions;

namespace DomainTests
{
    public class InstallmentTest
    {
        [Fact]
        public void DeveCriarParcelaDeSeguroFianca()
        {
            //Arrange
            var installment = new Installment();
            var expectedDueDate = DateTime.Today.AddDays(7);
            var expectedValue = 2400;

            //Act
            var result = installment.CreateBailInsuranceInstallment(1200);
            
            //Assert
            Assert.Equal("Only", result.Number);
            Assert.Equal(expectedValue, result.Value);
            Assert.Equal(expectedDueDate, result.DueDate);

        }
        [Fact]
        public void DeveCriarParcelaDeSeguroFianca_E_RelizarOPagamento()
        {
            //Arrange
            var installment = new Installment();
            var expectedDueDate = DateTime.Today.AddDays(7);
            
            //Act
            var result = installment.CreateBailInsuranceInstallment(1200);
            result.Pay(2400);

            //Assert
            Assert.Equal("Paid", result.Status);
            Assert.Equal(DateTime.Today, result.Payday);
        }
        [Fact]
        public void DeveCriarParcelaDeSeguroFianca_E_RelizarOPagamentoMenorQueValorDoSeguro()
        {
            //Arrange
            var installment = new Installment();
         
            //Act + Assert
            installment.CreateBailInsuranceInstallment(1200);
            var exception = Assert.Throws<InstallmentDomainExpection>(() => installment.Pay(2000));
            Assert.Equal("Valor informado é menor que parcela!", exception.Message);
        }
    }
}
