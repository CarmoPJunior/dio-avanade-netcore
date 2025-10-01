using System;
using System.Globalization;


class Projeto
{
// TODO: Crie a Classe que representa um Projeto com suas informações

     // Nome do projeto
    // Nome do consultor
    // Nota de qualidade
    // Nota de prazo
    // Nota de satisfação
    
    public string NomeProjeto { get; set; }
    public string NomeConsultor { get; set; }
    public int NotaQualidade { get; set; }
    public int NotaPrazo { get; set; }
    public int NotaSatisfacao { get; set; }
    

    // TODO: Crie o método que calcula a média das notas
    
    public decimal CalcularMedia()
    {
      
      return (NotaQualidade + NotaPrazo + NotaSatisfacao) / 3m;
      
      
    }
   

    // Método que imprime as informações no formato solicitado
    public void ExibirInformacoes()
    {
        Console.WriteLine($"Projeto: {NomeProjeto}");
        Console.WriteLine($"Consultor: {NomeConsultor}");
        Console.WriteLine($"Notas: Qualidade: {NotaQualidade}, Prazo: {NotaPrazo}, Satisfacao: {NotaSatisfacao}");
        Console.WriteLine($"Media: {CalcularMedia().ToString("F2", CultureInfo.InvariantCulture)}");
    }
}

class Program
{
    static void Main()
    {
        string linhaProjeto = Console.ReadLine(); 
        string nomeProjeto = linhaProjeto.Substring(9); 

        string linhaConsultor = Console.ReadLine(); 
        string nomeConsultor = linhaConsultor.Substring(11); 
        
        string linhaNotas = Console.ReadLine(); 
        string notasApenas = linhaNotas.Substring(7); 
        string[] partes = notasApenas.Split(", "); 

        // Criação do objeto Projeto com os dados extraídos
        Projeto projeto = new Projeto
        {
            NomeProjeto = nomeProjeto,
            NomeConsultor = nomeConsultor,
            NotaQualidade = int.Parse(partes[0]),
            NotaPrazo = int.Parse(partes[1]),
            NotaSatisfacao = int.Parse(partes[2])
        };

        projeto.ExibirInformacoes();
    }
}