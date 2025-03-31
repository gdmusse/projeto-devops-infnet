using CalculadoraApp;
using Xunit;
namespace CalculadoraTests
{
    public class CalculadoraTests
    {
        [Fact]
        public void DeveRetornar3_QuandoSomar1e2()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Somar(1, 2);
            Assert.Equal(3, resultado);
        }

        [Fact]
        public void DeveRetornar0_QuandoSomar0e0()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Somar(0, 0);
            Assert.Equal(0, resultado);
        }

        [Fact]
        public void DeveRetornarNumeroNegativo_QuandoSomarNegativoMaiorEPositivo()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Somar(-5, 3);
            Assert.Equal(-2, resultado);
        }

        [Fact]
        public void DeveRetornarValorCorreto_QuandoSomarNumerosGrandes()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Somar(1000000, 5000000);
            Assert.Equal(6000000, resultado);
        }

        [Fact]
        public void DeveRetornar1_QuandoSubtrair1de2()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Subtrair(2, 1);
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void DeveRetornar0_QuandoSubtrairNumeroPorEleMesmo()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Subtrair(3, 3);
            Assert.Equal(0, resultado);
        }

        [Fact]
        public void DeveRetornarNegativo_QuandoSubtrairMaiorDeMenor()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Subtrair(2, 5);
            Assert.Equal(-3, resultado);
        }

        [Fact]
        public void DeveRetornarValorCorreto_QuandoSubtrairNumerosGrandes()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Subtrair(100000, 50000);
            Assert.Equal(50000, resultado);
        }

        [Fact]
        public void DeveRetornar6_QuandoMultiplicar2e3()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Multiplicar(2, 3);
            Assert.Equal(6, resultado);
        }

        [Fact]
        public void DeveRetornar0_QuandoMultiplicarPorZero()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Multiplicar(0, 100);
            Assert.Equal(0, resultado);
        }

        [Fact]
        public void DeveRetornarNegativo_QuandoMultiplicarNegativoPorPositivo()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Multiplicar(-2, 5);
            Assert.Equal(-10, resultado);
        }

        [Fact]
        public void DeveRetornarPositivo_QuandoMultiplicarDoisNegativos()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Multiplicar(-2, -5);
            Assert.Equal(10, resultado);
        }

        [Fact]
        public void DeveRetornarValorCorreto_QuandoMultiplicarNumerosGrandes()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Multiplicar(10000, 50000);  

            Assert.Equal(500000000, resultado); 
        }

        [Fact]
        public void DeveRetornar2_QuandoDividir6por3()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Dividir(6, 3);
            Assert.Equal(2, resultado);
        }

        [Fact]
        public void DeveLancarExcecao_QuandoDividirPorZero()
        {
            var calculadora = new Calculadora();
            var ex = Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));

            Assert.Equal("Nao eh possivel dividir por zero.", ex.Message);
        }

        [Fact]
        public void DeveRetornar1_QuandoDividirNumeroPorEleMesmo()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Dividir(5, 5);
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void DeveRetornarDecimal_QuandoDivisaoNaoForExata()
        {
            var calculadora = new Calculadora();
            decimal resultado = calculadora.Dividir(7, 3);

            Assert.InRange(resultado, 2.332m, 2.334m);
        }
    }
}
