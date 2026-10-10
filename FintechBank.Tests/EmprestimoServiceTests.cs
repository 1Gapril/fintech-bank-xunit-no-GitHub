using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace FintechBank.Tests
{
    // CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito):
    // Se scoreCredito >= 700: taxa de juros total de 5% sobre o valor
    // (multiplicar valorTotal por 1.05m)
    //  Se scoreCredito entre 500 e 699: taxa de juros total de 12% (1.12m)
    //  Se scoreCredito < 500: taxa de juros total de 20% (1.20m).
    //  Retornar o valor da parcela individual (valorComJuros / parcelas).


  // AprovarEmprestimo(decimal rendaMensal, decimal valorParcela): 
  // O empréstimo só é aprovado (true) se o valorParcela comprometer no máximo 30% da renda
  // Mensal (valorParcela <= rendaMensal * 0.30m).

    public class EmprestimoServiceTests
    {
        [Theory]
        [InlineData(10000.00, 10, 800, 1050.00)] // (Score alto: 5% de juros ->R$ 10.500 / 10 = R$ 1.050)
        [InlineData(10000.00, 10, 600, 1120.00)] // (Score médio: 12% dejuros -> R$ 11.200 / 10 = R$ 1.120)
        [InlineData(10000.00, 10, 400, 1200.00)] //(Score baixo: 20% de juros-> R$ 12.000 / 10 = R$ 1.200)
    public void  CalcularValorParcelaDoEmprestimo_DeveRetornarValorComOsJurosComBaseNoScore (decimal valorTotal, int parcelas, int scoreCredito,decimal valor_esperado)
    {
        // arranjo (arrange)
            var service = new FintechBankService(); 
 
       //ação (act)
       decimal valor = service.CalcularValorParcela(valorTotal,parcelas,scoreCredito);
      // verificação (assert)
      Assert.Equal (valor_esperado,valor);
    }

    [Theory]
    [InlineData(5000.00, 1500.00, true)] // (Parcela = 30% da renda ->Aprovado)
    [InlineData(5000.00, 1600.00, false)] // (Parcela > 30% da renda -> Recusado)
    public void AprovarEmprestimo_DeveRetornarVerdadeiroCasoSejaIgualOuMenorQueUmTercoDaRenda (decimal rendaMensal, decimal valorParcela, bool aprovado)
     {
    //arranjo(arrange)
     var service = new FintechBankService();
     //ação (act)
     bool resultado = service.AprovarEmprestimo ( rendaMensal, valorParcela);

     // verificação (assert)
     Assert.Equal (aprovado,resultado);
     }
    }
}
