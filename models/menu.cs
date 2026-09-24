using System;
using LigaDaTurma.Models;
using LigaDaTurma.Services;

namespace LigaDaTurma
{
    public class Menu
    {
        private static readonly CampeonatoService _service = new CampeonatoService();

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
                Console.WriteLine("6 - Gerar convite do festival");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                // int.TryParse evita que o programa feche se o usuário digitar letras
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1; // Valor genérico para cair no default
                }

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        CadastrarEquipe();
                        break;

                    case 2:
                        ConsultarEquipes();
                        break;

                    case 3:
                        RegistrarPartida();
                        break;

                    case 4:
                        ConsultarHistorico();
                        break;

                    case 5:
                        CadastrarFestival();
                        break;

                    case 6:
                        GerarConvite();
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

        // ==========================================
        // MÉTODOS AUXILIARES DE CADA OPÇÃO
        // ==========================================

        private static void CadastrarEquipe()
        {
            Console.WriteLine("--- CADASTRAR EQUIPE ---");
            Console.Write("Digite o nome da equipe: ");
            string nome = Console.ReadLine()!;

            try
            {
                _service.CadastrarEquipe(nome);
                Console.WriteLine($"Equipe '{nome.Trim()}' cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static void ConsultarEquipes()
        {
            Console.WriteLine("--- EQUIPES CADASTRADAS ---");
            if (_service.Equipes.Count == 0)
            {
                Console.WriteLine("Nenhuma equipe cadastrada até o momento.");
                return;
            }

            for (int i = 0; i < _service.Equipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_service.Equipes[i].Nome}");
            }
        }

        private static void RegistrarPartida()
        {
            if (_service.Equipes.Count < 2)
            {
                Console.WriteLine("É necessário ter pelo menos 2 equipes cadastradas para registrar uma partida.");
                return;
            }

            Console.WriteLine("--- REGISTRAR PARTIDA ---");
            Console.WriteLine("Escolha a Modalidade:");
            Console.WriteLine("1 - Futsal");
            Console.WriteLine("2 - eSports (MD3)");
            Console.Write("Opção: ");
            string modalidade = Console.ReadLine()!;

            if (modalidade != "1" && modalidade != "2")
            {
                Console.WriteLine("Modalidade inválida!");
                return;
            }

            Console.WriteLine("\nSelecione a Equipe 1 (Mandante):");
            Equipe? eq1 = SelecionarEquipe();
            if (eq1 == null) return;

            Console.WriteLine("\nSelecione a Equipe 2 (Visitante):");
            Equipe? eq2 = SelecionarEquipe();
            if (eq2 == null) return;

            try
            {
                if (modalidade == "1")
                {
                    Console.Write($"Gols do {eq1.Nome}: ");
                    int g1 = int.Parse(Console.ReadLine()!);
                    Console.Write($"Gols do {eq2.Nome}: ");
                    int g2 = int.Parse(Console.ReadLine()!);

                    _service.RegistrarPartidaFutsal(eq1, eq2, g1, g2);
                    Console.WriteLine("Partida de Futsal registrada com sucesso!");
                }
                else
                {
                    Console.Write($"Mapas vencidos pelo {eq1.Nome}: ");
                    int m1 = int.Parse(Console.ReadLine()!);
                    Console.Write($"Mapas vencidos pelo {eq2.Nome}: ");
                    int m2 = int.Parse(Console.ReadLine()!);

                    _service.RegistrarPartidaeSports(eq1, eq2, m1, m2);
                    Console.WriteLine("Partida de eSports registrada com sucesso!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite apenas números inteiros válidos para o placar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static Equipe? SelecionarEquipe()
        {
            for (int i = 0; i < _service.Equipes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_service.Equipes[i].Nome}");
            }
            Console.Write("Escolha o número da equipe: ");

            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= _service.Equipes.Count)
            {
                return _service.Equipes[idx - 1];
            }

            Console.WriteLine("Seleção inválida.");
            return null;
        }

        private static void ConsultarHistorico()
        {
            Console.WriteLine("--- HISTÓRICO DE PARTIDAS ---");
            var partidas = _service.HistoricoPartidas.Partidas;

            if (partidas.Count == 0)
            {
                Console.WriteLine("Nenhuma partida registrada até o momento.");
                return;
            }

            foreach (var p in partidas)
            {
                Console.WriteLine($"[ID: {p.Id}] {p.Modalidade} | {p.EquipeMandante.Nome} vs {p.EquipeVisitante.Nome} | Resultado: {p.ObterResultado()}");
            }
        }

        private static void CadastrarFestival()
        {
            Console.WriteLine("--- CADASTRAR FESTIVAL ---");
            Console.Write("Nome do Festival: ");
            string nome = Console.ReadLine()!;
            Console.Write("Local: ");
            string local = Console.ReadLine()!;
            Console.Write("Data (ex: 25/10/2026): ");
            string data = Console.ReadLine()!;
            Console.Write("Horário (ex: 14h): ");
            string horario = Console.ReadLine()!;

            try
            {
                _service.CadastrarFestival(nome, local, data, horario);
                Console.WriteLine("Dados do festival cadastrados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static void GerarConvite()
        {
            Console.WriteLine("--- CONVITE DO FESTIVAL ---");
            if (_service.FestivalAtual == null)
            {
                Console.WriteLine("Os dados do festival ainda não foram cadastrados!");
                return;
            }

            Console.WriteLine(_service.FestivalAtual.GerarCartao());
        }

        private static void GerarCartaoPartida()
        {
            Console.WriteLine("--- CARTÃO DE PARTIDA ---");
            var partidas = _service.HistoricoPartidas.Partidas;

            if (partidas.Count == 0)
            {
                Console.WriteLine("Nenhuma partida registrada até o momento.");
                return;
            }

            foreach (var p in partidas)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Modalidade}: {p.EquipeMandante.Nome} vs {p.EquipeVisitante.Nome}");
            }

            Console.Write("\nDigite o ID da partida para gerar o cartão: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var partida = _service.HistoricoPartidas.ObterPorId(id);
                if (partida != null)
                {
                    Console.WriteLine(partida.GerarCartao());
                }
                else
                {
                    Console.WriteLine("Partida não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}