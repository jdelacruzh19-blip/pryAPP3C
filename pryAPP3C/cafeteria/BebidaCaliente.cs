using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebidasCalientesOfrias.Cafeteria
{
    internal class BebidaCaliente:Bebida
    {
        protected float temperatura;
        public float Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }

        public BebidaCaliente(string _nombre, string _tamaño, float _precio, float _temperatura) : base(_nombre, _tamaño, _precio)
        {
            temperatura = _temperatura;
        }
        public override string Preparar()
        {
            return "Preparando: " + Nombre + " de tamaño : " + Tamaño + " con temperatura : " + temperatura;
        }

        public override string Listar()
        {
            return "Preparando un/a bebida: " + nombre + " Caliente";
                
        }
    }
}
