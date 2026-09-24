using System;
using LigaDaTurma.Interfaces;

namespace LigaDaTurma.Models
{
    public class Festival : ICartao
    {
        public string NomeFestival { get; private set; }
        public string Local { get; private set; }
        public string Data { get; private set; }
        public string Horario { get; private set; }

        public Festival(string nomeFestival, string local, string data, string horario)
        {
            if (string.IsNullOrWhiteSpace(nomeFestival) || string.IsNullOrWhiteSpace(local) ||
                string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(horario))
            {
                throw new ArgumentException("Todos os campos do festival devem ser preenchidos.");
            }

            NomeFestival = nomeFestival.Trim();
            Local = local.Trim();
            Data = data.Trim();
            Horario = horario.Trim();
        }

        public string GerarCartao()
        {
            return $@"
+-------------------------------------------------------------+
|                  CONVITE DO FESTIVAL                        |
+-------------------------------------------------------------+
  Evento:  {NomeFestival}
  Local:   {Local}
  Data:    {Data}
  Horario: {Horario}
+-------------------------------------------------------------+";
        }
    }
}