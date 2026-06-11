using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebidasCalientesOfrias.Cafeteria
{
    internal class BebidaFria : Bebida
    {
        private float hielos;
        public float Hielos
        {
            get { return hielos; }
            set { hielos = value; }
        }
        public BebidaFria(string _nombre, string _tamaño, float _precio, int _hielos): base(_nombre, _tamaño, _precio)
        {
            Hielos = _hielos;
        }
        public override string Preparar()
        {
            return "Preparando un: " + Nombre +
                   " Helado con cantidad de hielos: " +
                   Hielos + " de tamaño: " + Tamaño;
        }

        public override string Listar()
        {
            return "Preparando un/a bebida: " + nombre + " Fria";

        }
    }
}
