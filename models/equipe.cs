using System;

public class Equipe
{
    public string Nome { get; set; }
    public string Modalidade { get; set; }

    public Equipe(string nome, string modalidade)
    {
        Nome = nome;
        Modalidade = modalidade;
    }
}