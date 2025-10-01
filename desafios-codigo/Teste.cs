using System;

class Programa
{
    static void Main()
    {
        string entrada = Console.ReadLine();

        // TODO: Verifique se a entrada é igual a "basico"

        // TODO: Se for, imprima a recomendação para o plano básico

        // TODO: Caso contrário, verifique se a entrada é igual a "intermediario"

        // TODO: Se for, imprima a recomendação para o plano intermediario

        // TODO: Se não for nenhum dos anteriores, verifique se é "avancado" ou "premium"

        // Lê a entrada do usuário
        string entrada = Console.ReadLine();

        // TODO: Divida a entrada em partes
        string[] partes = texto.Split(' ');



        // TODO: Implemente o primeiro elemento, que é o número de dias (interações)

        Console.WriteLine("{qtIteracoes} interacoes", qtIteracoes);



        if (entrada == "basico")
        {
            Console.WriteLine("Recomendado: plano avancado");
        }
        else if (entrada == "intermediario")
        {
            Console.WriteLine("Recomendado: plano intermediario");
        }
        else if (entrada == "avancado")
        {
            Console.WriteLine("Recomendado: plano avancado");
        }
        else
        {
            Console.WriteLine("Recomendado: plano premium");
        }
    }
}