using System;

namespace CalculadoraApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecutarCalculadora();
        }

        public static void ExecutarCalculadora()
        {
            var calculadora = new Calculadora();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Escolha uma operação:");
                Console.WriteLine("1. Somar");
                Console.WriteLine("2. Subtrair");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Sair");

                Console.Write("Digite a opção: ");
                string opcao = Console.ReadLine();

                if (opcao == "5")
                {
                    Console.WriteLine("Encerrando o programa...");
                    continuar = false;
                }
                else
                {
                    Console.Write("Digite o primeiro número: ");
                    if (!long.TryParse(Console.ReadLine(), out long num1))
                    {
                        Console.WriteLine("Entrada inválida!");
                        continue;
                    }

                    Console.Write("Digite o segundo número: ");
                    if (!long.TryParse(Console.ReadLine(), out long num2))
                    {
                        Console.WriteLine("Entrada inválida!");
                        continue;
                    }

                    string resultado = Calcular(opcao, num1, num2);
                    Console.WriteLine(resultado);
                }
            }
        }

        public static string Calcular(string opcao, long num1, long num2)
        {
            var calculadora = new Calculadora();
            try
            {
                return opcao switch
                {
                    "1" => $"Resultado: {calculadora.Somar(num1, num2)}",
                    "2" => $"Resultado: {calculadora.Subtrair(num1, num2)}",
                    "3" => $"Resultado: {calculadora.Multiplicar(num1, num2)}",
                    "4" => $"Resultado: {calculadora.Dividir(num1, num2)}",
                    _ => "Opção inválida."
                };
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
        }
    }
}
