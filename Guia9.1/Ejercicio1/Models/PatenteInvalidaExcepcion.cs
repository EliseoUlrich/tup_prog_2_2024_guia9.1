using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class PatenteInvalidaExcepcion : ApplicationException
    {
        public PatenteInvalidaExcepcion() : base("Patente invalida") { }
        public PatenteInvalidaExcepcion(string message) : base(message) { }
        public PatenteInvalidaExcepcion(string m, Exception e) : base(m, e) { }


    }
}