using System;
using System.Globalization;


// Classe que representa um consultor
class Consultor
{
    public string Nome { get; set; }
    public Agendamento Agendamento { get; set; }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"{Nome}:");

        if (Agendamento == null)
        {
            Console.WriteLine("Nenhum agendamento cadastrado");
        }
        else
        {
            Agendamento.Exibir();
        }
    }
}

class Agendamento
{


    // TODO: Crie a Classe que representa um agendamento

    //TODO: Nome do cliente
    //TODO: Data do agendamento
    //TODO: Descrição do serviço

    // TODO: Implemente o método para exibir os dados formatados

    // TODO: Exiba no formato: "dd/MM/yyyy - Cliente: Descricao"

    public string NomeCliente { get; set; }
    public string DescricaoServico { get; set; }
    public DateTime DataAgendamento { get; set; }

    public Agendamento()
    {
    }

    public Agendamento(string nomeCliente, string descricaoServico, DateTime dataAgendamento)
    {
        NomeCliente = nomeCliente;
        DescricaoServico = descricaoServico;
        DataAgendamento = dataAgendamento;
    }


    public void Exibir()
    {
        Console.WriteLine($"{DataAgendamento:dd/MM/yyyy} - {NomeCliente}: {DescricaoServico}");
    }

}



class Program
{
    static void Main()
    {

        string linhaConsultor = Console.ReadLine();

        string nomeConsultor = linhaConsultor.Replace("Consultor:", "").Trim();

        Console.ReadLine();

        string linhaAgendamento = Console.ReadLine();


        var consultor = new Consultor { Nome = nomeConsultor };

        if (!string.IsNullOrWhiteSpace(linhaAgendamento))
        {

            string[] partes = linhaAgendamento.Split(',');

            var agendamento = new Agendamento
            {
                NomeCliente = partes[0].Trim(),
                DataAgendamento = DateTime.ParseExact(partes[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DescricaoServico = partes[2].Trim()
            };

            consultor.Agendamento = agendamento;
        }

        consultor.ExibirInformacoes();
    }
}