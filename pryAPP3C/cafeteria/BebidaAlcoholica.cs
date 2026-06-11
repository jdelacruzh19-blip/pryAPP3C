using BebidasCalientesOfrias.Cafeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryAPP3C.cafeteria
{
    internal class BebidaAlcoholica:Bebida
    {
        protected float gradosAlcohol;
        public float GradosAlcohol
        {
            get { return gradosAlcohol; }
            set { gradosAlcohol = value; }
        }

        public BebidaAlcoholica(string _nombre, string _tamaño, float _precio, float _gradosAlcohol) : base(_nombre, _tamaño, _precio)
        {
            gradosAlcohol = _gradosAlcohol;
        }

        public override string Preparar()
        {
            return "Preparando: " + Nombre + " de tamaño : " + Tamaño + " con grados de alcohol: " + gradosAlcohol;
        }

        public override string Listar()
        {
            return "Preparando un/a bebida: " + nombre;

        }
    }
}
