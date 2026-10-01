using System;
using System.Globalization;
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

            string dataFormatada = data.Trim();
            if (!DateTime.TryParseExact(dataFormatada, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataValidada))
            {
                throw new ArgumentException("A data deve estar no formato mm/dd/aaaa.");
            }

            string horarioFormatado = horario.Trim();
            if (!TimeOnly.TryParseExact(horarioFormatado, "HH:mm", out var horarioValidado) ||
                horarioValidado > new TimeOnly(23, 59))
            {
                throw new ArgumentException("Hora inválida. Digite um horário entre 00:00 e 23:59.");
            }

            Data = dataValidada.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Horario = horarioFormatado;
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