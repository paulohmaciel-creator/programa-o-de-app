using System;

class Program
{
    static void Main(string[] args)
    {
        var ligaService = new LigaService();

        while (true)
        {
            Console.WriteLine("Escolha a modalidade da equipe (Futsal ou Esport) ou 'sair' para encerrar:");
            string? modalidade = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(modalidade))
            {
                Console.WriteLine("Modalidade inválida. Tente novamente.");
                continue;
            }

            if (modalidade.Trim().Equals("sair", StringComparison.OrdinalIgnoreCase))
                break;

            modalidade = modalidade.Trim();
            if (!modalidade.Equals("Futsal", StringComparison.OrdinalIgnoreCase) &&
                !modalidade.Equals("Esport", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Modalidade inválida. Digite apenas Futsal ou Esport.");
                continue;
            }

            Console.WriteLine("Digite o nome da equipe:");
            string? nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido. Tente novamente.");
                continue;
            }

            try
            {
                ligaService.CadastrarEquipe(nome, modalidade);
                Console.WriteLine($"Equipe cadastrada: {nome.Trim()} - {modalidade}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("\nEquipes cadastradas:");
        foreach (var equipe in ligaService.ListarEquipes())
        {
            Console.WriteLine($"- {equipe.Nome} ({equipe.Modalidade})");
        }
    }
}