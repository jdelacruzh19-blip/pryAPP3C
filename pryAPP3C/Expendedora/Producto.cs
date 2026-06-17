using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    internal class Producto
    {
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }

        // Encapsulamiento del stock
        private int Existencia;

        public Producto(string nombre, decimal precio, int existencia)
        {
            Nombre = nombre;
            Precio = precio;
            Existencia = existencia;
        }

        // Método comprar
        public string Comprar(int cantidad)
        {
            if (cantidad > Existencia)
            {
                return "No hay suficientes productos.";
            }

            if (cantidad <= 0)
            {
                return "Cantidad inválida.";
            }

            decimal total = cantidad * Precio;

            Existencia = Existencia - cantidad;

            return "Compra realizada. Total a pagar: $" + total;
        }

        // Método abastecer
        public string Abastecer(int cantidad)
        {
            Existencia = Existencia + cantidad;

            return "Producto abastecido.";
        }

        // Método mostrar
        public string Mostrar()
        {
            return Nombre +
                   " | Precio: $" + Precio +
                   " | Existencia: " + Existencia;
        }
        public int ObtenerExistencia()
        {
            return Existencia;
        }
    }

}
