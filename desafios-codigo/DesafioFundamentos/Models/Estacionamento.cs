namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {


        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"           
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string? placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                this.veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso!");
                return;
            }

            Console.WriteLine("Placa inválida! O veículo não foi adicionado.");

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string? placa = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida! Tente novamente.");
                return;
            }

            placa = placa.ToUpper().Trim();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                if (!int.TryParse(Console.ReadLine(), out int totalHorasPermanencia) || totalHorasPermanencia < 0)
                {
                    Console.WriteLine("Valor inválido para horas. Operação cancelada.");
                    return;
                }

                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal        

                decimal valorTotal = precoInicial + precoPorHora * totalHorasPermanencia;

                // TODO: Remover a placa digitada da lista de veículos
                string veiculoRemover = veiculos.First(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase));

                veiculos.Remove(veiculoRemover);


                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento                  

            if (veiculos.Any())
            {
                Console.WriteLine($"Veículos estacionados ({veiculos.Count}):");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados         

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

        }
    }
}
