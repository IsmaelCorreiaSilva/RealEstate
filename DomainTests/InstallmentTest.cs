﻿
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
            var expectedDueDate = installment.CreateDueDate(DateTime.Today);
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
            var expectedDueDate = installment.CreateDueDate(DateTime.Today);

            //Act
            var result = installment.CreateBailInsuranceInstallment(1200);
            result.Pay(2400);

            //Assert
            Assert.Equal(EInstallmentStatus.PAID, result.Status);
            Assert.Equal(DateTime.Today, result.Payday);
        }
        //[Fact]
        //public void DeveCriarParcelaDeSeguroFianca_E_RelizarOPagamentoMenorQueValorDoSeguro()
        //{
        //    //Arrange
        //    var installment = new Installment();

        //    //Act + Assert
        //    installment.CreateBailInsuranceInstallment(1200);
        //    var exception = Assert.Throws<InstallmentDomainExpection>(() => installment.Pay(2000));
        //    Assert.Equal("Valor informado é menor que parcela!", exception.Message);
        //}
        [Fact]
       public void DeveCriarParcelaNormal()
       {
            //Arrange
            var installment = new Installment();
            var expectedDueDate = installment.CreateDueDate(DateTime.Today);

            //Act
            var result = installment.CreateInstallment(1200, DateTime.Today);
            

            //Assert
            Assert.Equal(EInstallmentStatus.OPENED, result.Status);

        }
        //[Fact]
        //public void DeveCriarParcelaNormal_E_RealizarOPagamento()
        //{
        //    //Arrange
        //    var installment = new Installment();
        //    var expectedDueDate = DateTime.Today;

        //    //Act
        //    var result = installment.CreateInstallment(1200, DateTime.Today);
        //    result.Pay(1200);

        //    //Assert
        //    Assert.Equal(EInstallmentStatus.PAID, result.Status);
        //    Assert.Equal(expectedDueDate, result.Payday);

        //}
    }
}
