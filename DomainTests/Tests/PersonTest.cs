using DomainTests.FakerData;

namespace DomainTests.Tests
{
    public class PersonTest
    {
        [Fact]
        public void DeveCriarUmaPessoa_E_VerificarSeDocumentoEValido()
        {
            //Arrange
            var person = new PersonFaker().Generate();

            var expectedOutcome = true; //resultado esperado
            //Act
            var result = person.DocumentIsValid();

            //Assert
            Assert.Equal(expectedOutcome, result);

        }
        [Fact]
        public void DeveRetornarQueDocumentoEInvalido()
        {
            //Arrange
            var person = new PersonFaker("111.111.111-11").Generate();
            var expectedOutcome = false; //resultado esperado

            //Act
            var result = person.DocumentIsValid();

            //Assert
            Assert.Equal(expectedOutcome, result);
        }
        [Fact]
        public void DeveRetornarQueEMaiorDe18()
        {
            //Arrange
            var person = new PersonFaker().Generate();
            var expectedOutcome = true; //resultado esperado

            //Act
            var result = person.IsAdult();

            //Assert
            Assert.Equal(expectedOutcome, result);
        }

        [Fact]
        public void DeveRetornarQueEManorDe18()
        {
            //Arrange
            var person = new PersonFaker(16).Generate();
            var expectedOutcome = false; //resultado esperado

            //Act
            var result = person.IsAdult();

            //Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
