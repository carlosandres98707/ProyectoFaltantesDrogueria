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
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        private void button1_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            try {
                string obtener = "SELECT *FROM productos WHERE Codigo_Producto=@codigo";

                MySqlCommand cmde = new MySqlCommand(obtener, cn);
                cmde.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));
                string eliminar = "DELETE from productos WHERE Codigo_Producto=@codigo";
                MySqlDataReader leer = cmde.ExecuteReader();
                if (leer.Read())
                {
                    leer.Close();
                    MySqlCommand cmd = new MySqlCommand(eliminar, cn);

                    cmd.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto eliminado correctamente");
                    codigo.Clear();
                }
                else
                {

                    MessageBox.Show("No es posible eliminar el producto.Codigo mal escrito o no existe");
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Loa valores ingresados no pueden ser caracteres");

            } finally {
                cn.Close();

            }
          
            
           
            
            
        }

        private void Eliminar_Load(object sender, EventArgs e)
        {

        }

        private void sal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fo = new Form1();
            fo.Show();
        }
    }
}
