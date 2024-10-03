﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            verificaciones = new List<Evaluacion>();
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
        public override string ToString()
        {
            DateTime FechaRevalidacion = Fecha.AddDays(20);
            if (Aprobacion == TipoAprobacion.Parcial) {return $"{Patente} - {Aprobacion} - {Fecha} - {FechaRevalidacion}"; }
            return $"{Patente} - {Aprobacion} - {Fecha}";
        }
    }
}
