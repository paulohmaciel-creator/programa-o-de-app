using System;
using LigaDaTurma.Interfaces;

namespace LigaDaTurma.Models
{
    public abstract class Partida : ICartao
    {
        private static int _contadorId = 1;

        public int Id { get; private set; }
        public Equipe EquipeMandante { get; private set; }
        public Equipe EquipeVisitante { get; private set; }
        public string Modalidade { get; protected set; }

        protected Partida(Equipe equipeMandante, Equipe equipeVisitante, string modalidade)
        {
            if (equipeMandante == null || equipeVisitante == null)
                throw new ArgumentNullException("As equipes da partida não podem ser nulas.");

            if (equipeMandante.Nome.Equals(equipeVisitante.Nome, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Uma equipe não pode jogar contra si mesma.");

            Id = _contadorId++;
            EquipeMandante = equipeMandante;
            EquipeVisitante = equipeVisitante;
            Modalidade = modalidade;
        }

        public abstract string ObterResultado();
        public abstract string GerarCartao();
    }
}