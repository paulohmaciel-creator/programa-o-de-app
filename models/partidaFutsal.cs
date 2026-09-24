using System;

namespace LigaDaTurma.Models
{
    public class PartidaFutsal : Partida
    {
        public int GolsMandante { get; private set; }
        public int GolsVisitante { get; private set; }

        public PartidaFutsal(Equipe mandante, Equipe visitante, int golsMandante, int golsVisitante)
            : base(mandante, visitante, "Futsal")
        {
            if (golsMandante < 0 || golsVisitante < 0)
                throw new ArgumentException("O número de gols não pode ser negativo.");

            GolsMandante = golsMandante;
            GolsVisitante = golsVisitante;
        }

        public override string ObterResultado()
        {
            if (GolsMandante > GolsVisitante)
                return $"Vitória de {EquipeMandante.Nome}";
            if (GolsVisitante > GolsMandante)
                return $"Vitória de {EquipeVisitante.Nome}";
            return "Empate";
        }

        public override string GerarCartao()
        {
            return $@"
+-------------------------------------------------------------+
|                 CARTÃO DE RESULTADO - FUTSAL                |
+-------------------------------------------------------------+
  Partida #{Id} | Modalidade: {Modalidade}
  Placar:    {EquipeMandante.Nome} {GolsMandante} x {GolsVisitante} {EquipeVisitante.Nome}
  Resultado: {ObterResultado()}
+-------------------------------------------------------------+";
        }
    }
}