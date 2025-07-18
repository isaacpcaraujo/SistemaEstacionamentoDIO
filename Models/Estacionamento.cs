namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private static readonly Estacionamento instancia = new Estacionamento(0, 0);
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        private Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Implementando um singleton em Estacionamento
        public static Estacionamento Instancia
        {
            get
            {
                return instancia;
            }
        }


        public void AdicionarVeiculo()
        {
            Console.WriteLine("--- Adicionar Novo Veículo ---");

            Console.Write("Digite o modelo do veículo: ");
            string modeloVeiculo = Console.ReadLine().ToUpper();
            Console.Write("Digite a cor do veículo: ");
            string corVeiculo = Console.ReadLine().ToUpper();
            Console.Write("Digite a placa do veículo: ");
            string placaVeiculo = Console.ReadLine().ToUpper();

            if (string.IsNullOrEmpty(placaVeiculo))
            {
                Console.WriteLine("A placa não pode ser vazia. Veículo não adicionado!");
                return;
            }

            if (veiculos.Any(v => v.Placa.Equals(placaVeiculo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"O veículo com a placa '{placaVeiculo}' já está estacionado.");
                return;
            }

            Veiculo novoVeiculo = new Veiculo(modeloVeiculo, corVeiculo, placaVeiculo);
            this.veiculos.Add(novoVeiculo);

            Console.WriteLine($"Veículo '{modeloVeiculo} {corVeiculo}' com placa '{placaVeiculo}' adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaVeiculo = Console.ReadLine().ToUpper();

            Veiculo veiculoEncontrado = veiculos.First(v => v.Placa.Equals(placaVeiculo, StringComparison.OrdinalIgnoreCase));

            // Verifica se o veículo existe
            if (veiculoEncontrado != null)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                // Calculo do valor total
                decimal valorTotal = this.precoInicial + this.precoPorHora * horas;

                // Remove o carro estacionado
                veiculos.Remove(veiculoEncontrado);

                Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: R$ {valorTotal}");
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
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"- Placa: {veiculo.Placa}, Modelo: {veiculo.Modelo}, Cor: {veiculo.Cor}");
                } 

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}