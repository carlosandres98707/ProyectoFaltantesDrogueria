using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ProyectoFaltantes
{
    public partial class consulta : Form
    {
        public consulta()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        private void consultar_Click(object sender, EventArgs e)
        {
           

            cn.Open();

            try
            {
                string obtener = "SELECT *FROM productos WHERE Codigo_Producto=@codigo";

                MySqlCommand cmd = new MySqlCommand(obtener, cn);

                cmd.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));
                MySqlDataReader leer = cmd.ExecuteReader();
                float iva = 0.19f;
                float resultadosiniva;
                float precios;
                float resultadofinal;
                if (leer.Read())
                {

                    codigo.Text = leer["Codigo_Producto"].ToString();
                    nombre.Text = leer["Nombre_Producto"].ToString();
                    presentacion.Text = leer["Presentacion_Producto"].ToString();
                    marca.Text = leer["Marca_Producto"].ToString();
                    precio.Text = leer["Precio_Producto"].ToString();
                    precios = float.Parse(precio.Text);
                    resultadosiniva = precios * iva;
                    resultadofinal = precios - resultadosiniva;
                    stock.Text = leer["Stock_Producto"].ToString();
                    siniva.Text = resultadofinal.ToString();
                    MessageBox.Show("Los datos se consultaron exitosamente");
                }
                else
                {
                    MessageBox.Show("Codigo erroneo o no existe");
                }
            }
            catch (Exception es) {
                MessageBox.Show("Loa valores ingresados no pueden ser caracteres");
            } finally {


                cn.Close();
            }
           
            

           


        }

        private void sal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consulta_Load(object sender, EventArgs e)
        {

        }

        private void sal_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fo = new Form1();
            fo.Show();
        }

        private void nombre_Click(object sender, EventArgs e)
        {

        }
    }
}

