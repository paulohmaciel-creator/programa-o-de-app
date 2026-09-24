using System;

public class Menu
{
2    private static readonly LigaService _ligaService = new();

    public static void Exibir()
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.WriteLine("===== LIGA DA TURMA =====");
            Console.WriteLine("1 - Cadastrar equipe");
            Console.WriteLine("2 - Consultar equipes");
            Console.WriteLine("3 - Registrar partida");
            Console.WriteLine("4 - Consultar histórico");
            Console.WriteLine("5 - Cadastrar festival");
            Console.WriteLine("6 - Gerar convite");
            Console.WriteLine("7 - Gerar cartão de partida");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string? entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("Opção inválida. Digite um número válido.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o nome da equipe:");
                    string? nome = Console.ReadLine();

                    Console.WriteLine("Escolha a modalidade da equipe (Futsal ou Esport):");
                    string? modalidade = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(modalidade))
                    {
                        Console.WriteLine("Nome e modalidade são obrigatórios.");
                        break;
                    }

                    modalidade = modalidade.Trim();
                    if (!modalidade.Equals("Futsal", StringComparison.OrdinalIgnoreCase) &&
                        !modalidade.Equals("Esport", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Modalidade inválida. Digite apenas Futsal ou Esport.");
                        break;
                    }

                    try
                    {
                        _ligaService.CadastrarEquipe(nome, modalidade);
                        Console.WriteLine($"Equipe cadastrada: {nome.Trim()} - {modalidade}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 2:
                    Console.WriteLine("Equipes cadastradas:");
                    var equipes = _ligaService.ListarEquipes();

                    if (equipes.Count == 0)
                    {
                        Console.WriteLine("Nenhuma equipe cadastrada.");
                        break;
                    }

                    foreach (var equipe in equipes)
                    {
                        Console.WriteLine($"- {equipe.Nome} ({equipe.Modalidade})");
                    }
                    break;

                case 3:
                    // Registrar partida
                    break;

                case 4:
                    // Consultar histórico
                    break;

                case 5:
                    // Cadastrar festival
                    break;

                case 6:
                    // Gerar convite
                    break;

                case 7:
                    // Gerar cartão de partida
                    break;

                case 0:
                    Console.WriteLine("Encerrando...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }

        } while (opcao != 0);
    }
}