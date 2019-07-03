using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace PyPWeb.Clases
{
    public class PicoPlacaHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placa">alfanumérico longitud 7 sin guiones ni espacios(PYC0678)</param>
        /// <param name="fecha">2019-07-02</param>
        /// <param name="hora">16:55</param>
        /// <returns></returns>
        public string[] PuedeCircular(string placa, string fecha, string hora)
        {
            if(placa.Length!=7)
                return new string[] { "Error: numero incorrecto de digitos en placa" };
            else
            {
                var ultimoDigitoPlaca = placa[placa.Length - 1].ToString();

                foreach (var item in placa.ToCharArray())
                {
                    if (!char.IsLetterOrDigit(item))
                        return new string[] { "Error: no caracteres especiales en placa" };
                }

                if(!int.TryParse(ultimoDigitoPlaca,out var ultimoDigitoPlacaParseado))
                    return new string[] { "Error: ultimo dígito de placa" };

                if (!DateTime.TryParse(fecha,out var fechaParseada))
                    return new string[] { "Error: parseo fecha" };

                if (!TimeSpan.TryParse(hora,out var horaParseada))
                    return new string[] { "Error: parseo hora" };

                if (EsPicoPlacaFecha(ultimoDigitoPlacaParseado, fechaParseada))
                    return EsHoraPicoPlaca(horaParseada) ? new string[] { "NO" } : new string[] { "SI" };
                else
                    return new string[] { "SI" };
            }
        }

        private bool EsHoraPicoPlaca(TimeSpan hora)
        {
            //mañana 7:00 a 9:30
            //tarde 16:00 a 19:30
            var mananaInicio = new TimeSpan(7, 0, 0);
            var mananaFin = new TimeSpan(9, 30, 0);
            var tardeInicio = new TimeSpan(16, 0, 0);
            var tardeFin = new TimeSpan(19, 30, 0);

            return ((hora > mananaInicio && hora < mananaFin) || (hora > tardeInicio && hora < tardeFin));
        }
        
        private bool EsPicoPlacaFecha(int ultimoDigitoPlaca, DateTime fecha)
        {
            DayOfWeek diaSemanaPlaca;
            //asigna el dia correcto en base a la placa
            switch (ultimoDigitoPlaca)
            {
                case 1:
                    diaSemanaPlaca = DayOfWeek.Monday;
                    break;
                case 2:
                    diaSemanaPlaca = DayOfWeek.Monday;
                    break;
                case 3:
                    diaSemanaPlaca = DayOfWeek.Tuesday;
                    break;
                case 4:
                    diaSemanaPlaca = DayOfWeek.Tuesday;
                    break;
                case 5:
                    diaSemanaPlaca = DayOfWeek.Wednesday;
                    break;
                case 6:
                    diaSemanaPlaca = DayOfWeek.Wednesday;
                    break;
                case 7:
                    diaSemanaPlaca = DayOfWeek.Thursday;
                    break;
                case 8:
                    diaSemanaPlaca = DayOfWeek.Thursday;
                    break;
                case 9:
                    diaSemanaPlaca = DayOfWeek.Friday;
                    break;
                case 0:
                    diaSemanaPlaca = DayOfWeek.Friday;
                    break;
                default:
                    diaSemanaPlaca = DayOfWeek.Sunday;
                    break;
            }

            if (fecha.DayOfWeek == DayOfWeek.Sunday || fecha.DayOfWeek == DayOfWeek.Saturday)
                return false;

            return (diaSemanaPlaca == fecha.DayOfWeek);
        }
    }
}
