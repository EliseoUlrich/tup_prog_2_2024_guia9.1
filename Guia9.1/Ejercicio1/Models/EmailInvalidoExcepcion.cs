using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class EmailInvalidoExcepcion : ApplicationException
    {
        public EmailInvalidoExcepcion() : base("Email invalido") { }
        public EmailInvalidoExcepcion(string message) : base(message) { }
        public EmailInvalidoExcepcion(string m, Exception e) : base(m, e) { }
    }
}
