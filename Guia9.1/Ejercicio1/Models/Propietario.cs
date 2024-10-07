using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ejercicio1
{
    public class Propietario
    {
        private int dni;
        public int DNI
        {
            get { return dni; }
            set
            {
                if (value < 1000000)
                {
                    throw new DniInvalidoExcepcion();
                }
                dni = value;
            }
        }
        public string ApellidosNombres { get { return ApellidosNombres; } set { ApellidosNombres = value; } }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                Match a = Regex.Match(value, @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");
                if (!a.Success)
                {
                    throw new EmailInvalidoExcepcion();
                }
                email = value;
            }
        }
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
