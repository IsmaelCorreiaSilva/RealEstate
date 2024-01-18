using DomainTests.FakerData;

namespace DomainTests.Tests
{
    public class ImmobileTest
    {
        [Fact]
        public void DeveCriarUmImovel_E_VerificaAInspecaoDeAte7Dias()
        {
            //Arrange
            var immobile = new ImmobileFaker().Generate();
            var expectedOutcome = true;
            //Act
            var result = immobile.InspectionIsValid();
            //Assert
            Assert.Equal(expectedOutcome, result);
        }
        [Fact]
        public void DeveCriarUmImovel_E_VerificaInspecaoDeMaisDe7Dias()
        {
            //Arrange
            var immobile = new ImmobileFaker(-10).Generate();
            var expectedOutcome = false;
            //Act
            var result = immobile.InspectionIsValid();
            //Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
