
using Domain.Entities;

namespace DomainTests
{
    public class ImmobileTest
    {
        [Fact]
        public void DeveCriarUmImovel_E_VerificaAInspecaoDeAte7Dias()
        {
            //Arrange
            var address = new Address("19050-501","Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var inspectionDate = DateTime.Today.AddDays(-7);
            var immobile = new Immobile(inspectionDate, address,"active");
            var expectedOutcome = true;
            //Act
            var result = immobile.InspectionIsValid();
            //Assert
            Assert.Equal(expectedOutcome, result);
        }
        [Fact]
        public void DeveCriarUmImovel_E_VerificaInspecaoDeMaisDe7Dias()
        {
            var address = new Address("19050-501", "Rua dos Laranjais", "150", "Vila Maria", "São Paulo", "São Paulo", "Esquina com a Rua São Pedro");
            var inspectionDate = DateTime.Today.AddDays(-10);
            var immobile = new Immobile(inspectionDate, address, "active");
            var expectedOutcome = false;
            //Act
            var result = immobile.InspectionIsValid();
            //Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
