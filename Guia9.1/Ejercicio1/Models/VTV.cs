using Ejercicio1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class VTV : IComparable
    {
        public string Patente { get; private set; }
        public DateTime Fecha { get { return DateTime.Today; } }
        
        public TipoAprobacion Aprobacion
        {
            get
            {
                int min = 0;
                for (int i = 0; i < CantidadVerificaciones; i++)
                {
                    Evaluacion e = this[i];
                    int valor = (int)e.Evaluar();
                    if (i == 0 || valor < min) min = valor;
                }
                return (TipoAprobacion)min;
            }
        }
        public Propietario Propietario { get; private set; }


        private List<Evaluacion> verificaciones;
        public Evaluacion this[int idx]
        {
            get
            {
                return verificaciones[idx];
            }
        }
        public int CantidadVerificaciones
        {
            get
            {
                return verificaciones.Count;
            }
        }
        public VTV(string patente, Propietario propietario)
        {
            Patente = patente;
            Propietario = propietario;
            string pat = patente.Replace("-", "").Trim().ToUpper();
            Match a = Regex.Match(pat, @"^[A-Z]{2}\d{3}[A-Z]{2}$");
            Match b = Regex.Match(pat, @"^[A-Z]{3}\d{3}$");
            DateTime Fecha = DateTime.Today;
            if (!a.Success && !b.Success)
            {
                throw new PatenteInvalidaExcepcion();
            }
            verificaciones = new List<Evaluacion> {new EvaluacionSimple("Bocina","Funcionamiento correcto"),
            new EvaluacionParametrica(0.30,1,30,"Porcentaje","Prueba de frenos delanteros","Porcentaje de diferencia de frenado entre ejes"),
            new EvaluacionParametrica(0.30,1,30,"Porcentaje","Prueba de frenos traseros","Porcentaje de diferencia de frenado entre ejes"),
            new EvaluacionParametrica(0.0,0.5,30,"Grado","Alineación","Convergencia en grados"),
            new EvaluacionParametrica(10000,15000,30,"Candela","Luces de corto alcante","Intensidad lumínica"),
            new EvaluacionParametrica(30000,40000,30,"Candela","Luces de largo alcante","Intensidad lumínica")};
        }
        public string[] EmitirComprobante()
        {
            string[] comprobante = new string[CantidadVerificaciones + 1];
            comprobante[0] = Propietario.ToString();
            for (int i = 1; i < CantidadVerificaciones; i++)
            {
                comprobante[i] = verificaciones[i - 1].ToString();
            }
            return comprobante;
        }
        public int CompareTo(object obj)
        {
            Propietario a = obj as Propietario;
            if (a != null)
            {
                return Propietario.DNI.CompareTo(a.DNI);
            }
            return -1;
        }
        private DateTime FechaRevalidacion()
        {
            DateTime fecha = Fecha;
            int i = 0;
            while (i < 20)
            { 
                if (fecha.DayOfWeek != DayOfWeek.Sunday || fecha.DayOfWeek != DayOfWeek.Saturday)
                {
                    i++;
                }
                fecha = fecha.AddDays(1);
            }
            return fecha;
        }
        
        public override string ToString()
        {
            string a = $"{Patente}-{Aprobacion}-{Fecha}\r\n";
            if (Aprobacion == TipoAprobacion.Aprobado)
            {
                return $"{a}Fecha Vencimiento: {Fecha.AddYears(1)}";
            }
            if (Aprobacion == TipoAprobacion.Parcial)
            {

                return $"{a}Fecha Revalidación: {FechaRevalidacion()}";
            }
            return a;
        }
    }
}
