using System;

namespace CalculadoraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadora = new Calculadora();

            Console.WriteLine("Calculadora de Console");
            Console.WriteLine("Escolha uma operação:");
            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Sair");

            bool continuar = true;

            while (continuar)
            {
                Console.Write("\nEscolha uma opção (1-5): ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RealizarOperacao(calculadora, "Adição");
                        break;
                    case "2":
                        RealizarOperacao(calculadora, "Subtração");
                        break;
                    case "3":
                        RealizarOperacao(calculadora, "Multiplicação");
                        break;
                    case "4":
                        RealizarOperacao(calculadora, "Divisão");
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("Obrigado por usar a calculadora!");
        }

        static void RealizarOperacao(Calculadora calculadora, string operacao)
        {
            Console.WriteLine($"Você escolheu {operacao}");

            Console.Write("Digite o primeiro número: ");
            long num1 = long.Parse(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            long num2 = long.Parse(Console.ReadLine());

            decimal resultado = 0;

            try
            {
                switch (operacao)
                {
                    case "Adição":
                        resultado = calculadora.Somar(num1, num2);
                        break;
                    case "Subtração":
                        resultado = calculadora.Subtrair(num1, num2);
                        break;
                    case "Multiplicação":
                        resultado = calculadora.Multiplicar(num1, num2);
                        break;
                    case "Divisão":
                        resultado = calculadora.Dividir(num1, num2);
                        break;
                }

                Console.WriteLine($"Resultado: {resultado}\n");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
