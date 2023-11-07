using Domain.Entities;

namespace DomainTests
{
    public class ContractTest
    {
        [Fact]
        public void DeveCriarUmContrato_E_RetornarUmContratoAberto()
        {
            //Arrange
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today;

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat,1200);
            var expectedOutcome = "open";

            //Act
            var result = contract.Status;

            //Assert
            Assert.Equal(expectedOutcome, result);

        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocadorMaiorDeIdadeEDocumentoValido()
        {
            //Arrange
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today;

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(2010, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today;

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today;

            var locator = new Person("111.111.111-11", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
            var expectedLocator = false;
            //Act
            var resultLocator = contract.LocatorIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocatarioMaiorDeIdadeEDocumentoValido()
        {
            //Arrange
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today;

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat,1200);
            var expectedLocator = true;
            //Act
            var resultLocator = contract.RenterIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_LocatarioMenorDeIdadeEDocumentoValido()
        {
            //Arrange
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(2010, 02, 20);
            var inspectionDate = DateTime.Today;

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today;

            var immobile = new Immobile(inspectionDate, address, "active");
            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("333.333.333-33", "Maria de Souza", dateBirthRenter);
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
            var expectedLocator = false;
            //Act
            var resultLocator = contract.RenterIsValid();


            //Assert
            Assert.Equal(expectedLocator, resultLocator);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_ImovelVistoriadoComMenosOuIgual7Dias()
        {
            //Arrange
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-7);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
            var expectedImmobile = true;
            //Act
            var resulImmobile = contract.ImmobileIsValid();


            //Assert
            Assert.Equal(expectedImmobile, resulImmobile);
        }
        [Fact]
        public void DeveCriarUmContrato_Com_ImovelVistoriadoComMaiorDe7Dias()
        {
            //Arrange
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 11, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = new DateTime(2023, 10, 1);
            var endContrat = new DateTime(2025, 11, 1);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = DateTime.Today.AddDays(2);
            var endContrat = new DateTime(2023, 10, 10);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = DateTime.Today.AddDays(2);
            var endContrat = new DateTime(2023, 10, 10);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = DateTime.Today.AddDays(2);
            var endContrat = new DateTime(2023, 10, 10);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1170);
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
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var startContrat = DateTime.Today.AddDays(2);
            var endContrat = new DateTime(2023, 10, 10);
            var dateBirthLocator = new DateTime(1980, 05, 18);
            var dateBirthRenter = new DateTime(1993, 02, 20);
            var inspectionDate = DateTime.Today.AddDays(-10);

            var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
            var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
            var immobile = new Immobile(inspectionDate, address, "active");
            var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
            var expected = true;
            //var expectedPay = true;
            
            //Act
            contract.PayBailInsurance(2400);
            var result = contract.BailInsuranceIsPaid();


            //Assert
            Assert.Equal(expected, result);
            //Assert.Equal(expectedPay, resultPay);

        }

        //[Fact]
        //public void DeveCriarUmContratoDeAluguel_E_CriaSeguroCalcaoERealizaOPagamentoMenorQueOEsperado()
        //{
        //    //Arrange
        //    var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
        //    var startContrat = DateTime.Today.AddDays(2);
        //    var endContrat = new DateTime(2023, 10, 10);
        //    var dateBirthLocator = new DateTime(1980, 05, 18);
        //    var dateBirthRenter = new DateTime(1993, 02, 20);
        //    var inspectionDate = DateTime.Today.AddDays(-10);

        //    var locator = new Person("987.001.920-07", "João da Silva", dateBirthLocator);
        //    var renter = new Person("523.002.980-31", "Maria de Souza", dateBirthRenter);
        //    var immobile = new Immobile(inspectionDate, address, "active");
        //    var contract = new Contract(locator, renter, immobile, startContrat, endContrat, 1200);
        //    var expected = false;
        //    //Act
        //    contract.PayBailInsurance(2000);
        //    var result = contract.BailInsuranceIsPaid();
            

        //    //Assert
        //    Assert.Equal(expected, result);
        //}

    }
}