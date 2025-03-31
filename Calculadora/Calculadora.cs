namespace CalculadoraApp
{
    public class Calculadora
    {
        public long Somar(long a, long b)
        {
            return a + b;
        }

        public long Subtrair(long a, long b)
        {
            return a - b;
        }

        public long Multiplicar(long a, long b)
        {
            return a * b;
        }

        public decimal Dividir(long a, long b)
        {
            if (b == 0)
                throw new DivideByZeroException("Nao eh possivel dividir por zero.");
            return (decimal)a / b;
        }
    }

}
