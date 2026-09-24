using System;

List<Equipe> equipes = new();

Console.WriteLine("Digite o nome da equipe:");
string? nome = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(nome))
{
    equipes.Add(new Equipe(nome));
    Console.WriteLine($"Equipe cadastrada: {nome}");
}public class Equipe
{
    public string Nome { get; set; }

    public Equipe(string nome)
    {
        Nome = nome;
    }
}