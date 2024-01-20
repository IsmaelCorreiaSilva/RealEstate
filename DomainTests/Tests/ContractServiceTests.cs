
using DomainTests.FakerData;

namespace DomainTests.Tests
{
    public class ContractServiceTests
    { 
        [Fact]
        public void DeveGererarAsParcelas_E_AplicarJurosEmCasoDeAtrasoMenorIgual7Dias()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var initialDate = DateTime.Today.AddDays(5);
            var endDate = DateTime.Today.AddYears(1);
            var expectedPay = true;

            //Act
            contract.CreateInstallments(initialDate, endDate);
            var installment = contract.Installments.FirstOrDefault();
            installment.Pay(1200);

            //var result = installment.CreateInstallment(1200, DateTime.Today.AddYears(-5));
            //esult.Pay(1200);
            //var resultPay = ;

            //Assert
            //Assert.Equal(expectedPay, resultPay);
        }
    }
}
