using System;

public class Menu
{
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

            opcao = int.Parse(Console.ReadLine()!);

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    // Cadastrar equipe
                    break;

                case 2:
                    // Consultar equipes
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