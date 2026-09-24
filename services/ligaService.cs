using System;
using System.Collections.Generic;

public class LigaService
{
    private readonly List<Equipe> _equipes = new();

    public void CadastrarEquipe(string nome, string modalidade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome da equipe inválido.");

        if (string.IsNullOrWhiteSpace(modalidade))
            throw new ArgumentException("Modalidade inválida.");

        _equipes.Add(new Equipe(nome.Trim(), modalidade.Trim()));
    }

    public List<Equipe> ListarEquipes()
    {
        return _equipes;
    }
}
