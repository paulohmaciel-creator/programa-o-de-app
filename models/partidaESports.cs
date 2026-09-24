using System;

namespace LigaDaTurma.Models
{
    public class PartidaESports : Partida
    {
        public int MapasMandante { get; private set; }
        public int MapasVisitante { get; private set; }

        public PartidaESports(Equipe mandante, Equipe visitante, int mapasMandante, int mapasVisitante)
            : base(mandante, visitante, "eSports (MD3)")
        {
            if (mapasMandante < 0 || mapasVisitante < 0)
                throw new ArgumentException("O número de mapas não pode ser negativo.");

            bool placarValido = (mapasMandante == 2 && (mapasVisitante == 0 || mapasVisitante == 1)) ||
                                (mapasVisitante == 2 && (mapasMandante == 0 || mapasMandante == 1));

            if (!placarValido)
                throw new ArgumentException("Placar inválido para MD3! O vencedor deve ter exatamente 2 vitórias (ex: 2x0 ou 2x1).");

            MapasMandante = mapasMandante;
            MapasVisitante = mapasVisitante;
        }

        public override string ObterResultado()
        {
            if (MapasMandante > MapasVisitante)
                return $"Vitória de {EquipeMandante.Nome}";
            return $"Vitória de {EquipeVisitante.Nome}";
        }

        public override string GerarCartao()
        {
            return $@"
+-------------------------------------------------------------+
|                 CARTÃO DE RESULTADO - ESPORTS               |
+-------------------------------------------------------------+
  Partida #{Id} | Modalidade: {Modalidade}
  Placar:    {EquipeMandante.Nome} {MapasMandante} x {MapasVisitante} {EquipeVisitante.Nome}
  Resultado: {ObterResultado()}
+-------------------------------------------------------------+";
        }
    }
}