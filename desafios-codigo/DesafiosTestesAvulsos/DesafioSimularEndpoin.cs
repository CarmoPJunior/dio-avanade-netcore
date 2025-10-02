using System;

class Program
{
    static void Main()
    {
        // Lê uma linha do console e armazena na variável 'endpoint'.
        string endpoint = Console.ReadLine()?.Trim() ?? string.Empty;

        // Usa switch expression para simplificar os testes.
        switch (endpoint.ToLower())
        {
            case "/clientes":
                Console.WriteLine("Listando clientes...");
                break;

            case "/produtos":
                Console.WriteLine("Exibindo produtos disponíveis...");
                break;

            case "/relatorios":
                Console.WriteLine("Gerando relatório de desempenho...");
                break;

            default:
                Console.WriteLine("Endpoint não reconhecido.");
                break;
        }
    }
}
