using CalculadoraApp;

public class CalculadoraTests
{
    private Calculadora _calculadora;

    public CalculadoraTests()
    {
        _calculadora = new Calculadora();
    }

    [Fact]
    public void DeveRetornar3_QuandoSomar1e2()
    {
        var resultado = _calculadora.Somar(1, 2);
        Assert.Equal(3, resultado);
    }

    [Fact]
    public void DeveRetornar0_QuandoSomar0e0()
    {
        var resultado = _calculadora.Somar(0, 0);
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void DeveRetornarNumeroNegativo_QuandoSomarNegativoMaiorEPositivo()
    {
        var resultado = _calculadora.Somar(-5, 3);
        Assert.Equal(-2, resultado);
    }

    [Fact]
    public void DeveRetornarValorCorreto_QuandoSomarNumerosGrandes()
    {
        var resultado = _calculadora.Somar(10000000000, 20000000000);
        Assert.Equal(30000000000, resultado);
    }

    // Testes para Subtração
    [Fact]
    public void DeveRetornar1_QuandoSubtrair1de2()
    {
        var resultado = _calculadora.Subtrair(2, 1);
        Assert.Equal(1, resultado);
    }

    [Fact]
    public void DeveRetornar0_QuandoSubtrairNumeroPorEleMesmo()
    {
        var resultado = _calculadora.Subtrair(5, 5);
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void DeveRetornarNegativo_QuandoSubtrairMaiorDeMenor()
    {
        var resultado = _calculadora.Subtrair(5, 10);
        Assert.Equal(-5, resultado);
    }

    [Fact]
    public void DeveRetornarValorCorreto_QuandoSubtrairNumerosGrandes()
    {
        var resultado = _calculadora.Subtrair(100000000000, 50000000000);
        Assert.Equal(50000000000, resultado);
    }

    // Testes para Multiplicação
    [Fact]
    public void DeveRetornar6_QuandoMultiplicar2e3()
    {
        var resultado = _calculadora.Multiplicar(2, 3);
        Assert.Equal(6, resultado);
    }

    [Fact]
    public void DeveRetornar0_QuandoMultiplicarPorZero()
    {
        var resultado = _calculadora.Multiplicar(5, 0);
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void DeveRetornarNegativo_QuandoMultiplicarNegativoPorPositivo()
    {
        var resultado = _calculadora.Multiplicar(-2, 3);
        Assert.Equal(-6, resultado);
    }

    [Fact]
    public void DeveRetornarPositivo_QuandoMultiplicarDoisNegativos()
    {
        var resultado = _calculadora.Multiplicar(-2, -3);
        Assert.Equal(6, resultado);
    }

    [Fact]
    public void DeveRetornarValorCorreto_QuandoMultiplicarNumerosGrandes()
    {
        var resultado = _calculadora.Multiplicar(100000, 50000);
        Assert.Equal(5000000000, resultado);
    }

    // Testes para Divisão
    [Fact]
    public void DeveRetornar2_QuandoDividir6por3()
    {
        var resultado = _calculadora.Dividir(6, 3);
        Assert.Equal(2, resultado);
    }

    [Fact]
    public void DeveLancarExcecao_QuandoDividirPorZero()
    {
        Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(5, 0));
    }

    [Fact]
    public void DeveRetornar1_QuandoDividirNumeroPorEleMesmo()
    {
        var resultado = _calculadora.Dividir(5, 5);
        Assert.Equal(1, resultado);
    }

    [Fact]
    public void DeveRetornarDecimal_QuandoDivisaoNaoForExata()
    {
        decimal resultado = _calculadora.Dividir(7, 3);

        Assert.InRange(resultado, 2.332m, 2.334m);
    }
}