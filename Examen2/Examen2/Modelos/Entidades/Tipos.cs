using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Modelos.Entidades
{
    public class Tipos
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
        public object TipoSoporte { get; internal set; }
    }
}
