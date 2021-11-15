using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Modelos.Entidades
{
    public class Tickets
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreTipos { get; set; }
        public string NombreEstados { get; set; }
    }
}
