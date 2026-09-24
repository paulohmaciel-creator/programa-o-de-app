using System;
using System.Collections.Generic;
using LigaDaTurma.Models;

namespace LigaDaTurma.Services
{
    public class CampeonatoService
    {
        public List<Equipe> Equipes { get; } = new();
        public Historico HistoricoPartidas { get; } = new();
        public Festival? FestivalAtual { get; private set; }

        public void CadastrarEquipe(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da equipe não pode ser vazio.");

            Equipes.Add(new Equipe(nome));
        }

        public void RegistrarPartidaFutsal(Equipe equipeMandante, Equipe equipeVisitante, int golsMandante, int golsVisitante)
        {
            var partida = new PartidaFutsal(equipeMandante, equipeVisitante, golsMandante, golsVisitante);
            HistoricoPartidas.AdicionarPartida(partida);
        }

        public void RegistrarPartidaeSports(Equipe equipeMandante, Equipe equipeVisitante, int mapasMandante, int mapasVisitante)
        {
            var partida = new PartidaESports(equipeMandante, equipeVisitante, mapasMandante, mapasVisitante);
            HistoricoPartidas.AdicionarPartida(partida);
        }

        public void CadastrarFestival(string nomeFestival, string local, string data, string horario)
        {
            FestivalAtual = new Festival(nomeFestival, local, data, horario);
        }
    }
}