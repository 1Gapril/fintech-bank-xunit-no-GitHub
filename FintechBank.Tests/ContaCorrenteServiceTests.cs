using System;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using Xunit; // IMPORTANTE: Lembre-se de adicionar o xUnit para reconhecer o Theory e o Assert

namespace FintechBank.Tests
{
    public class ContaCorrenteServiceTests
    {
        [Theory] 
        [InlineData(6000.00, false, 0.00)] // (Saldo alto -> Isento)
        [InlineData(500.00, true, 0.00)] // (Cliente Especial -> Isento)
        [InlineData(2500.00, false, 12.50)] // (Saldo intermediário -> R$12,50) 
        [InlineData(300.00, false, 25.00)] // (Saldo baixo -> R$ 25,00)
        public void CalcularTaxaDeManutencao_EseClienteEspecial_DeveRetornarTaxasCorretas(decimal saldo, bool cliente_especial, decimal valor_esperado)
        { 
            
            // arranjo (arrange)
            var service = new FintechBankService(); 
            // ação (act)
           
            decimal resultado = service.CalcularTaxaDeManutencao(saldo, cliente_especial); 

            // verificação (assert)
            Assert.Equal(valor_esperado, resultado);

        } 
        [Theory]
        [InlineData(1000.00, 500.00, 1200.00, true)]  // (Dentro do limite total -> true)
        [InlineData(1000.00, 500.00, 1600.00, false)] // (Excede saldo + limite-> false)

        public void ValidacaoDeSaque_DeveRetornarSeSaqueEstaDentroOuForaDoLimite ( decimal saldo, decimal limiteChequeEspecial,decimal valor_saque, bool resultado_esperado){
       //arranjo(arrange)
     var service = new FintechBankService();
     //ação (act)
     bool resultado = service.PodeRealizarSaque(saldo,limiteChequeEspecial,valor_saque);

     // verificação (assert)
     Assert.Equal (resultado_esperado,resultado);
    }
    
    }


}
