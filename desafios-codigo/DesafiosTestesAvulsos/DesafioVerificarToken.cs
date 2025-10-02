using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Solicita ao usuário que insira o token de acesso
        string token = Console.ReadLine()?.Trim() ?? string.Empty;

        // TODO: Verifique se o token tem exatamente 10 caracteres
        

        // TODO: Verifica se o primeiro caractere é a letra 'A' maiúscula
        

        // TODO: Verifica se há pelo menos um dígito numérico no token
            

        // TODO: Verifique se todas as condições foram satisfeitas
       
            // TODO: Token válido
            
            // Token inválido
            
        bool tamanhoCorreto = token.Length == 10;
        bool comecaComA = token.StartsWith("A");
        bool temDigito = token.Any(char.IsDigit);

        if (tamanhoCorreto && comecaComA && temDigito)
        {
            Console.WriteLine("Acesso permitido");
        }
        else
        {
            Console.WriteLine("Acesso negado");
        }

    }
}