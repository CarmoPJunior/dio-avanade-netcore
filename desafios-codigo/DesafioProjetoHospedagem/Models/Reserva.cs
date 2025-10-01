namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("A lista de hóspedes não pode ser nula ou vazia.", nameof(hospedes));
            }

            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte foi definida para o cadastro dos hóspedes.");
            }

            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido           
            bool capacidadeCompativel = Suite.Capacidade >= hospedes.Count;

            if (capacidadeCompativel)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new InvalidOperationException(
                                    $"A suíte escolhida comporta até {Suite.Capacidade} hóspedes, " +
                                    $"mas foi informado {hospedes.Count}.");
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)           
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte foi definida para o cálculo da diária.");
            }

            if (DiasReservados <= 0)
            {
                throw new InvalidOperationException("O número de dias reservados deve ser maior que zero.");
            }
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}