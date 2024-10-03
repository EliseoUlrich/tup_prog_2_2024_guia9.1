using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Propietario
    {
        public int DNI { get { return DNI; } set { DNI = value; }   } 
        public string ApellidosNombres { get { return ApellidosNombres; } set { ApellidosNombres = value; } }
        public string Email { get { return Email; } set { Email = value; } }
        public Propietario(int dni, string apellidosNombres, string email)
        {
            DNI = dni;
            ApellidosNombres = apellidosNombres;
            Email = email;
        }
        public override string ToString()
        { return $"Apellidos y Nombres: {ApellidosNombres} - DNI: {DNI} - Email: {Email}"; }
    }   
}
