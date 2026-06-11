using BebidasCalientesOfrias.Cafeteria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pryAPP3C.cafeteria;
using System.Drawing.Text;



namespace pryAPP3C.cafeteria
{
    public partial class FormCafeteria : Form
    {
        private List<Bebida> bebidas;
        public FormCafeteria()
        {
            InitializeComponent();  
            bebidas= new List<Bebida> ();
        }


        
        private void rdb_caliente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_caliente.Checked == true)
            {
                lbl_opcion.Text = "Ingrese la temperatura";
            }
            else if (rdb_fria.Checked == true)
            {
                lbl_opcion.Text = "Cantidad de Hielos";
            }
            else
            {
                lbl_opcion.Text = "Cantidad de alcohol(Grados)";
            }
        }

        private void FormCafeteria_Load(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            string nombre=txt_nombre.Text;
            float precio = float.Parse(txt_precio.Text.Trim());
            string tamano = cmb_tamaño.Text;
            int extra= int.Parse(txt_extra.Text.Trim());



            if (rdb_caliente.Checked == true)
            {
                bebidas.Add(new BebidaCaliente(nombre, tamano, precio, extra));

            }
            else if (rdb_fria.Checked == true)
            {
                bebidas.Add(new BebidaFria(nombre, tamano, precio, extra));
            }
            else
            {
                bebidas.Add(new BebidaAlcoholica(nombre, tamano, precio, extra));
            }

            MessageBox.Show("Bebida agregada con exito");
            


            if (bebidas[bebidas.Count - 1] is BebidaFria fria)
            {
                lsbLista.Items.Add(fria.Listar());
            }
            else if (bebidas[bebidas.Count - 1] is BebidaCaliente caliente)
            {
                lsbLista.Items.Add(caliente.Listar());
            }
            else if (bebidas[bebidas.Count - 1] is BebidaAlcoholica alcoholica)
            {
                lsbLista.Items.Add(alcoholica.Listar());
            }

            Limpiarcajas();

            lbl_descripcion.Text = bebidas[bebidas.Count - 1].Preparar();
        }


        private void Limpiarcajas()
        {
            txt_nombre.Clear();
            txt_precio.Clear();
            txt_extra.Clear();
            cmb_tamaño.SelectedItem = 0;
        }

        private void lsbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_descripcion.Text = bebidas[lsbLista.SelectedIndex].Preparar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_tamaño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
