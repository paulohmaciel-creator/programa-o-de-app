using System;

public class Equipe
{
    public string Nome { get; set; } = string.Empty;
    public string Modalidade { get; set; } = string.Empty;

    public Equipe()
    {
    }

    public Equipe(string nome, string modalidade)
    {
        Nome = nome;
        Modalidade = modalidade;
    }
}