using Domain.Entities;
using DomainTests.FakerData;

namespace DomainTests.Tests
{

    public class ContractTest
    {
        [Fact]
        public void DeveCriarUmContrato_E_RetornarUmContratoAberto()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var expected = EContractStatus.OPENED;

            //Act
            var result = contract.Status;

            //Assert
            Assert.Equal(expected, result);

        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocadorMaiorDeIdadeEDocumentoValido()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var expectedLocator = true;
            //Act
            var resultLocator = contract.LocatorIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);

        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocadorMenorDeIdadeEDocumentoValido()
        {
            //Arrange
            var contract = new ContractFaker(1200,-16).Generate();
            var expectedLocator = false;
            //Act
            var resultLocator = contract.LocatorIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);

        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocadorMaiorDeIdadeEDocumentoInvalido()
        {
            //Arrange
            var contract = new ContractFaker(1200, "111.111.111-11").Generate();
            var expectedLocator = false;
            //Act
            var resultLocator = contract.LocatorIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocatarioMenorDeIdadeEDocumentoValido()
        {
            //Arrange
            var contract = new ContractFaker(1200,-16).Generate();
            var expectedLocator = false;
            //Act
            var resultLocator = contract.RenterIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocatarioMaiorDeIdadeEDocumentoInvalido()
        {
            //Arrange
            var contract = new ContractFaker(1200,"111.111.111-11").Generate();
            var expectedLocator = false;
            //Act
            var resultLocator = contract.RenterIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_ImovelVistoriadoEmPeriodoMenorOuIgual7Dias()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var expectedImmobile = true;
            //Act
            var resulImmobile = contract.ImmobileIsValid();


            //Assert
            Assert.Equal(expectedImmobile, resulImmobile);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_ImovelVistoriadoEmPeriodoMaiorDe7Dias()
        {
            //Arrange
            var contract = new ContractFaker(1200,0,-10).Generate();
            var expectedImmobile = false;
            //Act
            var resultImmobile = contract.ImmobileIsValid();


            //Assert
            Assert.Equal(expectedImmobile, resultImmobile);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_TempoMinimoDeContratoDeUmAno()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var expected = DateTime.Today.AddYears(1);
            //Act
            var result = contract.MinimumContract;


            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_DataDeInicioDoContratoNoPassado()
        {
            //Arrange
            var contract = new ContractFaker(1200, new DateTime(2013,10,10), DateTime.Today.AddYears(3)).Generate();
            var expected = false;
            //Act
            var result = contract.ContractPeriodIsValid();


            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_DataDeFimDoContratoNoPassado()
        {
            //Arrange
            var contract = new ContractFaker(1200, DateTime.Today, DateTime.Today.AddMonths(-1)).Generate();
            var expected = false;
            //Act
            var result = contract.ContractPeriodIsValid();


            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_DataDeFimDoContratoMenorQueDataMinima()
        {
            //Arrange
            var contract = new ContractFaker(1200, DateTime.Today, DateTime.Today.AddMonths(6)).Generate();
            var expected = false;
            //Act
            var result = contract.ContractPeriodIsValid();


            //Assert
            Assert.Equal(expected, result);

        }
        [Fact]
        public void DeveCriarUmContratoDeAluguel_E_CriaSeguroCalcao2VezesOValorDoAluguel()
        {
            //Arrange
            var contract = new ContractFaker(1170).Generate();
            var expected = 2340;

            //Act
            var result = contract.BailInsurance.Value;


            //Assert
            Assert.Equal(expected, result);

        }
        [Fact]
        public void DeveCriarUmContratoDeAluguel_E_CriaSeguroCalcaoERealizaOPagamento()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var expected = true;

            //Act
            contract.PayBailInsurance(2400);
            var result = contract.BailInsuranceIsPaid();


            //Assert
            Assert.Equal(expected, result);

        }
        [Fact]
        public void DeveCriarUmContratoDeAluguel_E_CriaAs12PrimeirasParcelasDoContrato()
        {
            //Arrange
            var contract = new ContractFaker(1200).Generate();
            var initialDate = DateTime.Today;
            var endDate = DateTime.Today.AddYears(1);
            var expected = 12;

            //Act
            contract.CreateInstallments(initialDate, endDate);
            var result = contract.Installments.Count;


            //Assert
            Assert.Equal(expected, result);
        }
        
    }
}