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
    public partial class Actualizar : Form
    {
        public Actualizar()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        private void actualiza_Click(object sender, EventArgs e)
        {
            cn.Open();
            try {
                string obtener = "SELECT *FROM productos WHERE Codigo_Producto=@codigo";

                MySqlCommand cmde = new MySqlCommand(obtener, cn);
                cmde.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));
                string actualizar = "UPDATE productos set Nombre_Producto=@nombre,Presentacion_Producto=@presentacion,Marca_Producto=@marca,Precio_Producto=@precio,Stock_Producto=@stock where  Codigo_Producto=@codigo";



                MySqlDataReader leer = cmde.ExecuteReader();
                if (leer.Read())
                {

                    leer.Close();
                    MySqlCommand cmd = new MySqlCommand(actualizar, cn);

                    cmd.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));
                    cmd.Parameters.AddWithValue("@nombre", nombre.Text);
                    cmd.Parameters.AddWithValue("@presentacion", presentacion.Text);
                    cmd.Parameters.AddWithValue("@marca",marca.Text);
                    cmd.Parameters.AddWithValue("@precio", int.Parse(precio.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(stock.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Producto modificado correctamente");
                }
                else
                {

                    MessageBox.Show("No ha sido posible modificar el producto.Codigo no existente");
                }

            }
            catch (Exception ex) {
                MessageBox.Show("No es posible actualizar.Error en las cajas de texto");

            } finally { 
            cn.Close();


            }
                        

            
        }

        private void sal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fo = new Form1();
            fo.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
