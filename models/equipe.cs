using System;

namespace LigaDaTurma.Models
{
    public class Equipe
    {
        public string Nome { get; private set; }

        public Equipe(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da equipe não pode ser vazio.");

            Nome = nome.Trim();
        }

        public override string ToString() => Nome;
    }
}