using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Equipe> equipes = new();

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

            nome = nome.Trim();
            equipes.Add(new Equipe(nome, modalidade));
            Console.WriteLine($"Equipe cadastrada: {nome} - {modalidade}");
        }

        Console.WriteLine("\nEquipes cadastradas:");
        foreach (var equipe in equipes)
        {
            Console.WriteLine($"- {equipe.Nome} ({equipe.Modalidade})");
        }
    }
}