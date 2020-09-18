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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt; 


        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                string obtener = "SELECT *FROM productos WHERE Codigo_Producto=@codigo";

                MySqlCommand cmde = new MySqlCommand(obtener, cn);
                cmde.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));
                string insertar = "INSERT INTO productos( Codigo_Producto, Nombre_Producto,Presentacion_Producto,Marca_Producto,Precio_Producto,Stock_Producto) values(@codigo,@nombre,@presentacion,@marca,@precio,@stock)";
                MySqlCommand cmd = new MySqlCommand(insertar, cn);
                MySqlDataReader leer = cmde.ExecuteReader();

                if (leer.Read()) {
                    MessageBox.Show("El codigo que has ingresado ya exite no es pobible ingresar el producto");
                } else {
                    leer.Close();
                    cmd.Parameters.AddWithValue("@codigo", Int64.Parse(codigo.Text));
                    cmd.Parameters.AddWithValue("@nombre", nombre.Text);
                    cmd.Parameters.AddWithValue("@presentacion", presentacion.Text);
                    cmd.Parameters.AddWithValue("@marca",marca.Text);
                    cmd.Parameters.AddWithValue("@precio", Int64.Parse(precio.Text));                 
                    cmd.Parameters.AddWithValue("@stock", Int64.Parse(stock.Text));

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Los datos se agregaron correctamente");

                    codigo.Clear();
                    nombre.Clear();
                    presentacion.Clear();
                    marca.Clear();
                    precio.Clear();
                    stock.Clear();
                }
                
            }
            catch (FormatException ex)
            {

                MessageBox.Show("Has introducido un caracter no valido en alguna casilla.Por favor intentalo de nuevo ");
            }
            finally {
                cn.Close();
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            consulta frm = new consulta();

            frm.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Actualizar frm = new Actualizar();

            frm.Show();
        }

        public void cargarProductos(DataGridView dgv) {

            da = new MySqlDataAdapter("SELECT *FROM productos",cn);
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Tabla ta = new Tabla();
            ta.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Eliminar elim = new Eliminar();

            elim.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
