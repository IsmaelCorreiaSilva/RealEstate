
using Domain.Entities;

namespace DomainTests
{
    public class ImmobileTest
    {
        [Fact]
        public void DeveCriarUmImovel_E_VerificaAInspecaoDeAte7Dias()
        {
            //Arrange
            var address = new Address("19050-501","Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo","testes");
            var immobile = new Immobile("2023/0001", new DateTime(2023,10,25), address);
            var expectedOutcome = true;
            //Act
            var result = immobile.InspectionIsValid();
            //Assert
            Assert.Equal(expectedOutcome, result);
        }
        [Fact]
        public void DeveCriarUmImovel_E_VerificaInspecaoDeMaisDe7Dias()
        {
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "testes");
            var immobile = new Immobile("2023/0001", new DateTime(2023, 10, 05), address);
            var expectedOutcome = false;
            //Act
            var result = immobile.InspectionIsValid();
            //Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
