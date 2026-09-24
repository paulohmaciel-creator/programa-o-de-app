using System.Collections.Generic;
using System.Linq;

namespace LigaDaTurma.Models
{
    public class Historico
    {
        private readonly List<Partida> _partidas = new List<Partida>();

        public IReadOnlyList<Partida> Partidas => _partidas.AsReadOnly();

        public void AdicionarPartida(Partida partida)
        {
            if (partida != null)
            {
                _partidas.Add(partida);
            }
        }

        public Partida? ObterPorId(int id)
        {
            return _partidas.FirstOrDefault(p => p.Id == id);
        }
    }
}