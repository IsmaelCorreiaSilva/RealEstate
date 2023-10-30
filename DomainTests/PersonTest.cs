
using Domain.Entities;

namespace DomainTests
{
    public class PersonTest
    {
        [Fact]
        public void DeveCriarUmaPessoa_E_VerificarSeDocumentoEValido()
        {
            //Arrange
            var person = new Person("987.001.920-07", "Carlar da Silva", new DateTime(1995,05,19));
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
            //var person = new Person("111.111.111-11", "Carlar da Silva", new DateTime(1995, 05, 19));
            var person = new Person("411.777.679-88", "Carlar da Silva", new DateTime(1995, 05, 19));
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
            var person = new Person("987.001.920-07", "Carlar da Silva", new DateTime(1995, 05, 19));
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
            var person = new Person("987.001.920-07", "Carlar da Silva", new DateTime(2010, 05, 19));
            var expectedOutcome = false; //resultado esperado

            //Act
            var result = person.IsAdult();

            //Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
