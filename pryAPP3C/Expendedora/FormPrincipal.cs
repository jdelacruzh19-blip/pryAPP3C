using MaquinaExpendedora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAPP3C.Expendedora
{
    public partial class FormPrincipal : Form
    {
       
       
        private List<Producto> _productos;        // Lista con todos los productos
        private Producto _productoSeleccionado;   // Producto que el usuario elige

       
        public FormPrincipal()
        {
            InitializeComponent();
            InicializarProductos();      
            CargarProductosEnComboBox();
            ActualizarVitrina();         
            ConfigurarEventos();        
        }


        private void InicializarProductos()
        {
            _productos = new List<Producto>
            {
                new Producto("Papas Fritas", 1500, 10),
                new Producto("Chocolate", 2000, 8),
                new Producto("Gaseosa", 2500, 12),
                new Producto("Galletas", 1800, 6)
            };
        }
        private void CargarProductosEnComboBox()
        {
            cmbProductos.DataSource = null;
            cmbProductos.DataSource = _productos;
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "Nombre";
        }

        private void ActualizarVitrina()
        {
            if (_productos.Count >= 4)
            {
                // Producto 1: Papas Fritas
                ActualizarPanelProducto(
                    panelProducto1,
                    lblNombre1,
                    lblPrecio1,
                    label2,    
                    _productos[0]
                );

                // Producto 2: Chocolate
                ActualizarPanelProducto(
                    panelProducto2,
                    lblNombre2,
                    lblPrecio2,
                    lblStock2,
                    _productos[1]
                );

                // Producto 3: Gaseosa
                ActualizarPanelProducto(
                    panelProdcuto3,  
                    lblNombre3,
                    lblPrecio3,
                    lblStock3,
                    _productos[2]
                );

                // Producto 4: Galletas
                ActualizarPanelProducto(
                    panelProducto4,
                    lblNombre4,
                    lblPrecio4,
                    lblStock4,
                    _productos[3]
                );
            }
        }
        private void ActualizarPanelProducto(
            Panel panel,
            Label lblNombre,
            Label lblPrecio,
            Label lblStock,
            Producto producto)
        {

            lblNombre.Text = producto.Nombre;
            lblPrecio.Text = $"${producto.Precio:N0}";

            int existencia = producto.ObtenerExistencia();
            lblStock.Text = $"STOCK: {existencia}";

            // Cambiar colores según si hay stock o no
            if (existencia > 0)
            {
                lblStock.ForeColor = Color.Green;
                panel.BackColor = Color.FromArgb(240, 248, 255); 
            }
            else
            {
                lblStock.ForeColor = Color.Red;
                panel.BackColor = Color.FromArgb(255, 240, 240); 
            }
        }

        private void ConfigurarEventos()
        {
          
            this.cmbProductos.SelectedIndexChanged +=
                new EventHandler(cmbProductos_SelectedIndexChanged);
            this.btnComprar.Click +=  
                new EventHandler(brnComprar_Click);

            // Cuando haces clic en ABASTECER
            this.btnAbastecer.Click +=
                new EventHandler(btnAbastecer_Click);

            // Cuando haces clic en SALIR
            this.btnSalir.Click +=
                new EventHandler(btnSalir_Click);
        }


        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem is Producto producto)
            {
                // Guardar el producto elegido
                _productoSeleccionado = producto;

                // Mostrar sus datos en los cuadros de detalles
                txtNombreProducto.Text = producto.Nombre;
                txtPrecioProducto.Text = $"${producto.Precio:N0}";

                int existencia = producto.ObtenerExistencia();
                txtStockDisponible.Text = existencia.ToString();
                txtStockDisponible.ForeColor = existencia > 0 ? Color.Green : Color.Red;

                // Si no hay stock, desactivar el botón Comprar
                btnComprar.Enabled = existencia > 0;

                // Ajustar la cantidad máxima según el stock
                nudCantidad.Maximum = existencia > 0 ? existencia : 1;
            }
        }

        private void brnComprar_Click(object sender, EventArgs e)
        {
            // Verificar que hay un producto seleccionado
            if (_productoSeleccionado == null)
            {
                MessageBox.Show(
                    "Primero selecciona un producto",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int cantidad = (int)nudCantidad.Value;

    
            string resultado = _productoSeleccionado.Comprar(cantidad);

            if (resultado.StartsWith("Compra realizada"))
            {
                decimal total = cantidad * _productoSeleccionado.Precio;

                MessageBox.Show(
                    $"Producto: {_productoSeleccionado.Nombre}\n" +
                    $"Cantidad: {cantidad}\n" +
                    $"{resultado}\n" +
                    $"Stock restante: {_productoSeleccionado.ObtenerExistencia()}",
                    "¡Compra Exitosa!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Actualizar todo en pantalla
                ActualizarDespuesDeOperacion();
            }
            else
            {
                // Algo salió mal
                MessageBox.Show(
                    $"Producto: {_productoSeleccionado.Nombre}\n" +
                    $"Error: {resultado}",
                    "Error de Compra",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnAbastecer_Click(object sender, EventArgs e)
        {
            // Verificar que hay un producto seleccionado
            if (_productoSeleccionado == null)
            {
                MessageBox.Show(
                    "Primero selecciona un producto para abastecer",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Cuántas unidades quiere agregar
            int cantidad = (int)nudCantidadAbastecer.Value;

            // USAR TU MÉTODO ABASTECER ORIGINAL
            string resultado = _productoSeleccionado.Abastecer(cantidad);

            MessageBox.Show(
                $"Producto: {_productoSeleccionado.Nombre}\n" +
                $"Cantidad agregada: {cantidad}\n" +
                $"Nuevo stock: {_productoSeleccionado.ObtenerExistencia()}\n" +
                $"{resultado}",
                "Abastecimiento Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Actualizar todo en pantalla
            ActualizarDespuesDeOperacion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Preguntar si está seguro
            DialogResult resultado = MessageBox.Show(
                "¿Seguro que quieres salir?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); // Cerrar la aplicación
            }
        }

        private void ActualizarDespuesDeOperacion()
        {
            // Actualizar los paneles de la vitrina
            ActualizarVitrina();

            // Refrescar el ComboBox
            CargarProductosEnComboBox();

            // Volver a seleccionar el mismo producto
            if (_productoSeleccionado != null)
            {
                cmbProductos.SelectedItem = _productoSeleccionado;
            }

            // Actualizar los detalles
            if (_productoSeleccionado != null)
            {
                int existencia = _productoSeleccionado.ObtenerExistencia();
                txtStockDisponible.Text = existencia.ToString();
                txtStockDisponible.ForeColor = existencia > 0 ? Color.Green : Color.Red;
                btnComprar.Enabled = existencia > 0;
                nudCantidad.Maximum = existencia > 0 ? existencia : 1;
            }

            // Dejar los números como estaban al inicio
            nudCantidad.Value = 1;
            nudCantidadAbastecer.Value = 5;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
           
        }


        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void lblNombre2_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
