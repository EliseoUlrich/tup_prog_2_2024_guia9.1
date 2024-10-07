using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class DniInvalidoExcepcion : ApplicationException
    {
        public DniInvalidoExcepcion() : base("Dni inválido") { }
        public DniInvalidoExcepcion(string mensaje) : base(mensaje) { }
        public DniInvalidoExcepcion(string mensaje, Exception excepcion) : base(mensaje, excepcion) { }
    }
}
