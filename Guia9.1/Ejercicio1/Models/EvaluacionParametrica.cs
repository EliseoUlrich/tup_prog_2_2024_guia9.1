using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public class EvaluacionParametrica:Evaluacion
    {
        public double ValorMinimo { get; private set; }
        public double ValorMaximo { get; private set; }
        public string Unidad { get; private set; }
        public double ValorTolerado { get; private set; }
        public double ValorMedido { get { return ValorMedido; } set { ValorMedido = value; } }

        public EvaluacionParametrica(double valorMinimo, double valorMaximo, double valorTolerado, string unidad, string n, string d) : base(n, d)
        {
            ValorMaximo = valorMaximo;
            ValorTolerado = valorTolerado;
            ValorMinimo = valorMinimo;
            Unidad = unidad;
        }
        public override TipoAprobacion Evaluar()
        {
            double valor70 = ValorMaximo * (1 - ValorTolerado / 100);
            double valor130 = ValorMinimo * (1 + ValorTolerado / 100);
            if (ValorMedido < valor70)
            {
                return TipoAprobacion.NoAprobado;
            }
            else if (ValorMedido < ValorMinimo)
            {
                return TipoAprobacion.Parcial;
            }
            else if (ValorMedido <= ValorMaximo)
            {
                return TipoAprobacion.Aprobado;
            }
            else if (ValorMedido < valor130)
            {
                return TipoAprobacion.Aprobado;
            }
            return TipoAprobacion.Aprobado;
        }
        public override string ToString()
        {
            string nombre = Nombre.Length > 20 ? Nombre.Substring(0, 17) + "..." : Nombre.PadRight(20, '_');
            string descripcion = Descripcion.Length > 20 ? Descripcion.Substring(0, 17) + "..." : Descripcion.PadRight(20, '_');
            return $"{nombre} - {descripcion} - {Evaluar()}\r\n";
        }
    }
    
}
