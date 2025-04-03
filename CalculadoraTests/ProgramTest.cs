using System;
using System.IO;
using Xunit;

namespace CalculadoraApp.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void DeveRetornarSomaCorreta()
        {
            var resultado = Program.Calcular("1", 5, 3);
            Assert.Equal("Resultado: 8", resultado);
        }

        [Fact]
        public void DeveRetornarErroDivisaoPorZero()
        {
            var resultado = Program.Calcular("4", 5, 0);
            Assert.Contains("Erro:", resultado);
        }

        [Fact]
        public void DeveRetornarOpcaoInvalida()
        {
            var resultado = Program.Calcular("999", 5, 3);
            Assert.Equal("Opção inválida.", resultado);
        }

        [Fact]
        public void DeveRetornarSubtracaoCorreta()
        {
            var resultado = Program.Calcular("2", 10, 5);
            Assert.Equal("Resultado: 5", resultado);
        }

        [Fact]
        public void DeveRetornarMultiplicacaoCorreta()
        {
            var resultado = Program.Calcular("3", 5, 3);
            Assert.Equal("Resultado: 15", resultado); 
        }

        [Fact]
        public void DeveRetornarDivisaoCorreta()
        {
            var resultado = Program.Calcular("4", 6, 3);
            Assert.Equal("Resultado: 2", resultado);
        }

        [Fact]
        public void DeveExibirMenuCorretoNoConsole()
        {
            using (var sw = new StringWriter())
            using (var sr = new StringReader("5\n")) 
            {
                Console.SetOut(sw);
                Console.SetIn(sr);
                Program.ExecutarCalculadora(); 

                var resultado = sw.ToString().Trim();
                Assert.Contains("Escolha uma operação", resultado);
                Assert.Contains("1. Somar", resultado);
                Assert.Contains("2. Subtrair", resultado);
                Assert.Contains("3. Multiplicar", resultado);
                Assert.Contains("4. Dividir", resultado);
                Assert.Contains("5. Sair", resultado);
                Assert.Contains("Encerrando o programa...", resultado);
            }
        }

        [Fact]
        public void DeveLidarComEntradaNaoNumerica()
        {
            using (var sw = new StringWriter())
            using (var sr = new StringReader("1\nabc\n5\n"))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);
                Program.ExecutarCalculadora();

                var resultado = sw.ToString().Trim();
                Assert.Contains("Entrada inválida!", resultado);
            }
        }

        [Fact]
        public void DeveRetornarSomaNegativa()
        {
            var resultado = Program.Calcular("1", -5, 3);
            Assert.Equal("Resultado: -2", resultado); 
        }

        [Fact]
        public void DeveRetornarMultiplicacaoPorZero()
        {
            var resultado = Program.Calcular("3", 5, 0);
            Assert.Equal("Resultado: 0", resultado); 
        }

        [Fact]
        public void DeveRetornarMultiplicacaoComNumeroNegativo()
        {
            var resultado = Program.Calcular("3", -5, 3);
            Assert.Equal("Resultado: -15", resultado); 
        }

        [Fact]
        public void DeveRetornarSubtracaoComNumeroNegativo()
        {
            var resultado = Program.Calcular("2", -10, 5);
            Assert.Equal("Resultado: -15", resultado);
        }

        [Fact]
        public void DeveRetornarSubtracaoComZero()
        {
            var resultado = Program.Calcular("2", 0, 7);
            Assert.Equal("Resultado: -7", resultado);
        }

        [Fact]
        public void DeveRetornarMultiplicacaoDeDoisNegativos()
        {
            var resultado = Program.Calcular("3", -4, -6);
            Assert.Equal("Resultado: 24", resultado);
        }

        [Fact]
        public void DeveExecutarCalculadoraESomarCorretamente()
        {
            using (var sw = new StringWriter())
            using (var sr = new StringReader("1\n5\n3\n5\n")) // Opção 1 (Soma), 5 + 3, depois opção 5 (Sair)
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                Program.ExecutarCalculadora();  // Executa o método interativo

                var resultado = sw.ToString();

                Assert.Contains("Resultado: 8", resultado); // Valida se a soma foi feita corretamente
            }
        }

    }
}