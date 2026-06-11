using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAPP3C.holamundo
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {

        }

        private void btn_sumar_Click(object sender, EventArgs e)
        {

            try
            {
                float valor1 = float.Parse(txt_valor1.Text.Trim());
                //MessageBox.Show("El valor capturado es: " + valor1);--muestra mensaje
                float valor2=float.Parse(txt_valor2.Text.Trim());
                float resultado = valor1 + valor2;
                lbl_resultado.Text = "El resultado es: " + resultado.ToString();

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Se presento el error: " + ex.Message);
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_resultado_Click(object sender, EventArgs e)
        {
        
            
        }
    }
}
