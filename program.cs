using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o nome da equipe:");
        string? nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome da equipe inválido.");
            return;
        }

        var equipe = new Equipe(nome);
        Console.WriteLine($"Equipe cadastrada: {equipe.Nome}");
    }
}